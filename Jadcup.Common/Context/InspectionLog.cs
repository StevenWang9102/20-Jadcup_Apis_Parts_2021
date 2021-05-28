using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class InspectionLog
    {
        public int LogId { get; set; }
        public DateTime? LogDate { get; set; }
        public TimeSpan? LogTime { get; set; }
        public short MachineId { get; set; }
        public int? PlanId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? InspectTime { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Comment { get; set; }
        public ulong Passed { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Machine Machine { get; set; }
        public virtual InspectionPlan Plan { get; set; }
    }
}
