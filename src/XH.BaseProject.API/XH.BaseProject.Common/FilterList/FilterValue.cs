using System;
using System.Collections.Generic;
using System.Text;

namespace XH.BaseProject.Common.FilterList
{
    public class FilterValue
    {
        public string PropertyName { get; set; }
        public List<object> Values { get; set; }
        public FilterOperations Operator { get; set; }
        public bool HasAnd { get; set; }
        public FilterValue()
        {
            Values = new List<object>();
        }
    }
}
