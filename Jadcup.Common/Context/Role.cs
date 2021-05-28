using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Role
    {
        public Role()
        {
            Employee = new HashSet<Employee>();
            Notification = new HashSet<Notification>();
            RolePageMapping = new HashSet<RolePageMapping>();
        }

        public short RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Notification> Notification { get; set; }
        public virtual ICollection<RolePageMapping> RolePageMapping { get; set; }
    }
}
