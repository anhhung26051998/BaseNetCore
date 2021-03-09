using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using XH.BaseProject.Common.Heplers;

namespace XH.BaseProject.Common.FilterList
{
    public static class OrderBuilder
    {
        public static IOrderedQueryable<TSource> OrderByIf<TSource>(this IQueryable<TSource> source, bool condition, IList<OrderValue> orderValues)
        {
            if (condition)
                return source.OrderBy(orderValues);
            else
                return source.OrderBy(x => 1);
        }

        public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> list, IList<OrderValue> orderValues)
        {
            var props = typeof(TSource).GetProperties();

            if (orderValues == null || orderValues.Count <= 0)
            {
                orderValues.Add(new OrderValue()
                {
                    PropertyName = props.FirstOrDefault().Name,
                    Type = OrderTypes.asc,
                    Index = 0
                });
            }
            orderValues = orderValues
                .OrderBy(x => x.Index)
                .ToList();

            IOrderedQueryable<TSource> result = null;
            List<string> builder = new List<string>();
            for (int i = 0; i < orderValues.Count; i++)
            {
                var propertyName = orderValues[i].PropertyName;
                var prop = props.FirstOrDefault(x => x.Name.ToLowwerFirstChar() == propertyName.ToLowwerFirstChar());
                if (prop == null) continue;

                propertyName = prop.Name;
                Expression<Func<TSource, object>> expression = item => propertyName;

                if (orderValues[i].Type == OrderTypes.asc)
                {
                    result = (i == 0) ? list.OrderBy(expression) :
                        result.ThenBy(expression);
                }
                else
                {
                    result = (i == 0) ? list.OrderByDescending(expression) :
                        result.ThenByDescending(expression);
                }
            }

            if (result == null)
            {
                result = list.OrderBy(x => 1);
            }

            return result;
        }
    }
}
