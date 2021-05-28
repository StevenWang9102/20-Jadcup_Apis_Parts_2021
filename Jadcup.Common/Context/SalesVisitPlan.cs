using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class SalesVisitPlan
    {
        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? NextVisitTime { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string PlanId { get; set; }
        public DateTime? Active { get; set; }
        public DateTime? Completed { get; set; }
        public DateTime? Notes { get; set; }
        public DateTime? Result { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
