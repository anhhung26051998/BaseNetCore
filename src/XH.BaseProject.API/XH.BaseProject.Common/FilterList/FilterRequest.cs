using System;
using System.Collections.Generic;
using System.Text;

namespace XH.BaseProject.Common.FilterList
{
        public class FilterRequest
        {
            private int _page = 1;

            public int Page
            {
                get { return _page; }
                set
                {
                    _page = value;
                    if (value <= 0)
                    {
                        _page = 1;
                    }
                }
            }

            private int _limit = 10;

            public int Limit
            {
                get { return _limit; }
                set
                {
                    _limit = value;
                    if (value <= 0)
                    {
                        _limit = 1;
                    }
                }
            }

            public bool IsFull { get; set; } = false;

            public string Keyword { get; set; }

            public string Summary { get; set; }

            public bool Tree { get; set; } = false;

            public List<FilterValue> Filters { get; set; }

            public List<OrderValue> Orders { get; set; }

            public FilterRequest()
            {
                Filters = new List<FilterValue>();
                Orders = new List<OrderValue>();
            }
        }   
}
