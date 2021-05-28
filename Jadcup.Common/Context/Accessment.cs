using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Accessment
    {
        public Accessment()
        {
            AccessmentDetail = new HashSet<AccessmentDetail>();
        }

        public string AccessmentId { get; set; }
        public string Item { get; set; }
        public decimal TotalMarks { get; set; }
        public sbyte Status { get; set; }
        public string AccessmentPlanId { get; set; }
        public string AcceStandardId { get; set; }
        public ulong? Active { get; set; }
        public int? EmployeeId { get; set; }

        public virtual AccessmentStandards AcceStandard { get; set; }
        public virtual AccessmentPlan AccessmentPlan { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<AccessmentDetail> AccessmentDetail { get; set; }
    }
}
