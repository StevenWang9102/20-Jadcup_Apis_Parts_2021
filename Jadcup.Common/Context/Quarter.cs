using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Quarter
    {
        public Quarter()
        {
            SalaryFactor = new HashSet<SalaryFactor>();
        }

        public short QuarterId { get; set; }
        public string QuarterName { get; set; }

        public virtual ICollection<SalaryFactor> SalaryFactor { get; set; }
    }
}
