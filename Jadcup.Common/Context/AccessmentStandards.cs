using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class AccessmentStandards
    {
        public AccessmentStandards()
        {
            Accessment = new HashSet<Accessment>();
            AccessmentStandardsDetail = new HashSet<AccessmentStandardsDetail>();
            Dept = new HashSet<Dept>();
        }

        public string AcceStandardId { get; set; }
        public string Name { get; set; }
        public ulong? Active { get; set; }

        public virtual ICollection<Accessment> Accessment { get; set; }
        public virtual ICollection<AccessmentStandardsDetail> AccessmentStandardsDetail { get; set; }
        public virtual ICollection<Dept> Dept { get; set; }
    }
}
