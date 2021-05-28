using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class WorkOrder
    {
        public WorkOrder()
        {
            Suborder = new HashSet<Suborder>();
        }

        public string OrderProductId { get; set; }
        public string WorkOrderId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public short? ProductId { get; set; }
        public int? CreatedEmployeeId { get; set; }
        public string Comments { get; set; }
        public string ApprovedComments { get; set; }
        public int? ApprovedEmployeeId { get; set; }
        public int? OrderTypeId { get; set; }
        public ulong? Urgent { get; set; }
        public DateTime? RequiredDate { get; set; }
        public int Quantity { get; set; }
        public sbyte? WorkOrderStatusId { get; set; }
        public sbyte? WorkOrderSourceId { get; set; }
        public string WorkOrderNo { get; set; }

        public virtual Employee CreatedEmployee { get; set; }
        public virtual OrderProduct OrderProduct { get; set; }
        public virtual OrderType OrderType { get; set; }
        public virtual Product Product { get; set; }
        public virtual WorkOrderSource WorkOrderSource { get; set; }
        public virtual WorkOrderStatus WorkOrderStatus { get; set; }
        public virtual ICollection<Suborder> Suborder { get; set; }
    }
}
