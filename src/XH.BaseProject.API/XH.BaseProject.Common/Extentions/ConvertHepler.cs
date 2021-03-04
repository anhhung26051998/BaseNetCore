using System;
namespace XH.BaseProject.Common.Extentions
{
    public static class ConvertHepler
    {
        public static long ToLong(this object obj, long defaultValue = 0)
        {
            return obj.ToLongOrNull() ?? defaultValue;
        }

        public static long? ToLongOrNull(this object obj, long? defaultValue = 0)
        {
            try
            {
                string str = obj?.ToString() ?? "";
                return Int64.Parse(str);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static int ToInt(this object obj, int defaultValue = 0)
        {
            return obj.ToIntOrNull() ?? defaultValue;
        }

        public static int? ToIntOrNull(this object obj, int? defaultValue = null)
        {
            try
            {
                string str = obj?.ToString() ?? "";
                return Int32.Parse(str);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static short ToShort(this object obj, short defaultValue = 0)
        {
            return obj.ToShortOrNull() ?? defaultValue;
        }

        public static short? ToShortOrNull(this object obj, short? defaultValue = null)
        {
            try
            {
                string str = obj?.ToString() ?? "";
                return Int16.Parse(str);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static bool ToBool(this object obj, bool defaultValue = false)
        {
            return obj.ToBoolOrNull() ?? defaultValue;
        }

        public static bool? ToBoolOrNull(this object obj, bool? defaultValue = null)
        {
            try
            {
                string str = obj?.ToString() ?? "";
                return str == "true" || str == "True" || str.ToLong() > 0;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static Guid ToGuid(this object obj, Guid defaultValue = new Guid())
        {
            return obj.ToGuidOrNull() ?? defaultValue;
        }

        public static Guid? ToGuidOrNull(this object obj, Guid? defaultValue = null)
        {
            try
            {
                var str = obj?.ToString() ?? "";
                return new Guid(str);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static DateTime ToDateTime(this object obj, DateTime defaultValue = new DateTime())
        {
            return obj.ToDateTimeOrNull() ?? defaultValue;
        }

        public static DateTime? ToDateTimeOrNull(this object obj, DateTime? defaultValue = null)
        {
            try
            {
                var str = obj?.ToString() ?? "";
                return DateTime.Parse(str);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
    }
}
