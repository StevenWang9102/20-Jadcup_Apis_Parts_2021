using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class InspectionPlan
    {
        public InspectionPlan()
        {
            InspectionLog = new HashSet<InspectionLog>();
        }

        public int PlanId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public short Periodicity { get; set; }
        public short? MachineId { get; set; }
        public short? StandardId { get; set; }

        public virtual Machine Machine { get; set; }
        public virtual Standard Standard { get; set; }
        public virtual ICollection<InspectionLog> InspectionLog { get; set; }
    }
}
