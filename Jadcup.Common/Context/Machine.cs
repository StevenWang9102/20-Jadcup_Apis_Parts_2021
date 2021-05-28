using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Machine
    {
        public Machine()
        {
            DailyReport = new HashSet<DailyReport>();
            InspectionLog = new HashSet<InspectionLog>();
            InspectionPlan = new HashSet<InspectionPlan>();
            ProductMachineMapping = new HashSet<ProductMachineMapping>();
            SuborderLog = new HashSet<SuborderLog>();
            WorkingArrangement = new HashSet<WorkingArrangement>();
        }

        public short MachineId { get; set; }
        public string MachineName { get; set; }
        public sbyte? Status { get; set; }
        public string Picture { get; set; }
        public short? MachineTypeId { get; set; }
        public int? SortingOrder { get; set; }

        public virtual MachineType MachineType { get; set; }
        public virtual ICollection<DailyReport> DailyReport { get; set; }
        public virtual ICollection<InspectionLog> InspectionLog { get; set; }
        public virtual ICollection<InspectionPlan> InspectionPlan { get; set; }
        public virtual ICollection<ProductMachineMapping> ProductMachineMapping { get; set; }
        public virtual ICollection<SuborderLog> SuborderLog { get; set; }
        public virtual ICollection<WorkingArrangement> WorkingArrangement { get; set; }
    }
}
