using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class ReturnItem
    {
        public int ReturnedItemId { get; set; }
        public short? ProductId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public short? QuantityPerBox { get; set; }
        public string Comments { get; set; }
        public int? OperEmployeeId { get; set; }
        public string TicketId { get; set; }
        public int? SalesEmployeeId { get; set; }
        public sbyte? Processed { get; set; }
        public short? BoxQty { get; set; }

        public virtual Employee OperEmployee { get; set; }
        public virtual Product Product { get; set; }
        public virtual Employee SalesEmployee { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
