using System;
using System.Linq;
using System.Reflection;

namespace XH.BaseProject.Common.Heplers
{
    public class MapIfNull : Attribute { }
    public class IgnoreMap : Attribute { }

    public static class MapHelper
    {
        public static TResult Mapper<Tin, TResult>(Tin input)
        {
            return (TResult)Mapper<Tin>(input, typeof(TResult));
        }

        public static TResult Mapper<Tin, TResult>(Tin input, ref TResult output)
        {
            output = (TResult)Mapper(input, typeof(TResult), output);
            return output;
        }

        private static object Mapper<Tin>(Tin input, Type typeResult, object result = null)
        {
            if (input == null) return null;
            if (result == null)
                result = Activator.CreateInstance(typeResult);
            var destPro = result.GetType().GetProperties();
            foreach (PropertyInfo p in input.GetType().GetProperties())
            {
                try
                {
                    var des = destPro.Where(d => d.Name == p.Name).FirstOrDefault();
                    if (des == null || des.CanWrite == false) continue;

                    if ((des.CustomAttributes.Any(x => x.AttributeType == typeof(MapIfNull)) && des.GetValue(result) != null)
                        || des.CustomAttributes.Any(x => x.AttributeType == typeof(IgnoreMap)))
                    {
                        continue;
                    }

                    if (des.PropertyType == p.PropertyType)
                    {
                        des.SetValue(result, p.GetValue(input));
                    }
                    else if (Nullable.GetUnderlyingType(des.PropertyType) == p.PropertyType)
                    {
                        des.SetValue(result, p.GetValue(input));
                    }
                    else if (des.PropertyType == Nullable.GetUnderlyingType(p.PropertyType))
                    {
                        var val = p.GetValue(input);
                        if (val == null) val = Activator.CreateInstance(Nullable.GetUnderlyingType(p.PropertyType));
                        des.SetValue(result, val);
                    }
                    else if (des.PropertyType.IsClass && p.PropertyType.IsClass)
                    {
                        des.SetValue(result, Mapper(p.GetValue(input), des.PropertyType));
                    }
                    else if (des.PropertyType == typeof(string))
                    {
                        des.SetValue(result, p.GetValue(input)?.ToString());
                    }
                }
                catch (Exception) { }
            }

            return result;
        }
    }

}
