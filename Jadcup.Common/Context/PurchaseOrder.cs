using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            PoDetail = new HashSet<PoDetail>();
            UnloadingInspection = new HashSet<UnloadingInspection>();
        }

        public int PoId { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ulong? Active { get; set; }
        public int? CreatedEmployeeId { get; set; }
        public short? SuplierId { get; set; }
        public string PoNo { get; set; }
        public short? PoStatusId { get; set; }

        public virtual Employee CreatedEmployee { get; set; }
        public virtual PoStatus PoStatus { get; set; }
        public virtual Suplier Suplier { get; set; }
        public virtual ICollection<PoDetail> PoDetail { get; set; }
        public virtual ICollection<UnloadingInspection> UnloadingInspection { get; set; }
    }
}
