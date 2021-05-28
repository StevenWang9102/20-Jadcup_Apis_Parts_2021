using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class OrderProduct
    {
        public OrderProduct()
        {
            WorkOrder = new HashSet<WorkOrder>();
        }

        public string OrderId { get; set; }
        public short? ProductId { get; set; }
        public string OrderProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Price { get; set; }
        public short? MarginOfError { get; set; }
        public ulong? Delivered { get; set; }
        public int? DeliveredQuantity { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<WorkOrder> WorkOrder { get; set; }
    }
}
