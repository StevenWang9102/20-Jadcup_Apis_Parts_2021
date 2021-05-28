using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Orders>();
        }

        public sbyte OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
