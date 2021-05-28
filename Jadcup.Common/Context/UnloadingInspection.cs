using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class UnloadingInspection
    {
        public UnloadingInspection()
        {
            Box = new HashSet<Box>();
            RawMaterialBox = new HashSet<RawMaterialBox>();
        }

        public string InspectionId { get; set; }
        public string ContainerNo { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public DateTime? UnloadingDate { get; set; }
        public string UnloadingPeople { get; set; }
        public decimal SpendingHours { get; set; }
        public string ConditionOfProduct { get; set; }
        public string ConditionOfPackage { get; set; }
        public int ActualQty { get; set; }
        public string Notes { get; set; }
        public DateTime? TakeAwayDate { get; set; }
        public int? PoId { get; set; }

        public virtual PurchaseOrder Po { get; set; }
        public virtual ICollection<Box> Box { get; set; }
        public virtual ICollection<RawMaterialBox> RawMaterialBox { get; set; }
    }
}
