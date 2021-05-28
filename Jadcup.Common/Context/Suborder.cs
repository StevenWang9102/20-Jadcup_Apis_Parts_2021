using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Suborder
    {
        public Suborder()
        {
            Box = new HashSet<Box>();
            SuborderLog = new HashSet<SuborderLog>();
        }

        public string SuborderId { get; set; }
        public string WorkOrderId { get; set; }
        public int? ReceivedQuantity { get; set; }
        public DateTime? CreatedAt { get; set; }
        public sbyte? SuborderStatusId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int? CompletedQuanity { get; set; }
        public string Comments { get; set; }
        public short? ActionId { get; set; }
        public sbyte? SequenceNo { get; set; }
        public int OrginalQuantity { get; set; }

        public virtual Action Action { get; set; }
        public virtual SuborderStatus SuborderStatus { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
        public virtual ICollection<Box> Box { get; set; }
        public virtual ICollection<SuborderLog> SuborderLog { get; set; }
    }
}
