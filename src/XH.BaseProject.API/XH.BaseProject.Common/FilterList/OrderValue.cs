using System;
using System.Collections.Generic;
using System.Text;

namespace XH.BaseProject.Common.FilterList
{
    public class OrderValue
    {
        public string PropertyName { get; set; }
        public OrderTypes Type { get; set; } = OrderTypes.asc;
        public int Index { get; set; }
    }
}
