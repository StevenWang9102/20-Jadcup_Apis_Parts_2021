using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Box
    {
        public Box()
        {
            DispatchingDetails = new HashSet<DispatchingDetails>();
            PlateBox = new HashSet<PlateBox>();
            StockLog = new HashSet<StockLog>();
            SuborderLog = new HashSet<SuborderLog>();
        }

        public string BoxId { get; set; }
        public string BarCode { get; set; }
        public string SuborderId { get; set; }
        public sbyte? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int Quantity { get; set; }
        public short Sequence { get; set; }
        public short? ProductId { get; set; }
        public ulong? IsSemi { get; set; }
        public string InspectionId { get; set; }
        public string TicketId { get; set; }

        public virtual UnloadingInspection Inspection { get; set; }
        public virtual Product Product { get; set; }
        public virtual BoxStatus StatusNavigation { get; set; }
        public virtual Suborder Suborder { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual ICollection<DispatchingDetails> DispatchingDetails { get; set; }
        public virtual ICollection<PlateBox> PlateBox { get; set; }
        public virtual ICollection<StockLog> StockLog { get; set; }
        public virtual ICollection<SuborderLog> SuborderLog { get; set; }
    }
}
