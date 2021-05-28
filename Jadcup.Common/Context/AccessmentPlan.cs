using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class AccessmentPlan
    {
        public AccessmentPlan()
        {
            Accessment = new HashSet<Accessment>();
        }

        public string AccessmentPlanId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public ulong? Active { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Accessment> Accessment { get; set; }
    }
}
