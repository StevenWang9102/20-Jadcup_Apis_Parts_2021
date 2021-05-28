using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class OrderType
    {
        public OrderType()
        {
            ProductTypeAction = new HashSet<ProductTypeAction>();
            WorkOrder = new HashSet<WorkOrder>();
        }

        public int OrderTypeId { get; set; }
        public string OrderTypeName { get; set; }

        public virtual ICollection<ProductTypeAction> ProductTypeAction { get; set; }
        public virtual ICollection<WorkOrder> WorkOrder { get; set; }
    }
}
