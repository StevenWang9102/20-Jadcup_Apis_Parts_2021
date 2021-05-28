using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Dept
    {
        public Dept()
        {
            Employee = new HashSet<Employee>();
        }

        public short DeptId { get; set; }
        public string DeptName { get; set; }
        public string AcceStandardId { get; set; }

        public virtual AccessmentStandards AcceStandard { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
