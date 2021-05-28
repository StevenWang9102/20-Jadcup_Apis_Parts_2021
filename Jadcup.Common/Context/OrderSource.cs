using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class OrderSource
    {
        public OrderSource()
        {
            Orders = new HashSet<Orders>();
        }

        public sbyte OrderSourceId { get; set; }
        public string OrderSourceName { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
