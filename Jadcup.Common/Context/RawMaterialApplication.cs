using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class RawMaterialApplication
    {
        public RawMaterialApplication()
        {
            ApplicationDetails = new HashSet<ApplicationDetails>();
        }

        public string ApplicationId { get; set; }
        public int? ApplyEmployeeId { get; set; }
        public int? WarehouseEmployeeId { get; set; }
        public DateTime? AppliedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public short? RawMaterialId { get; set; }
        public decimal? ApplyQuantity { get; set; }
        public decimal? RecievedQuantity { get; set; }
        public ulong? Active { get; set; }
        public ulong? Processed { get; set; }

        public virtual Employee ApplyEmployee { get; set; }
        public virtual RawMaterial RawMaterial { get; set; }
        public virtual Employee WarehouseEmployee { get; set; }
        public virtual ICollection<ApplicationDetails> ApplicationDetails { get; set; }
    }
}
