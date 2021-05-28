using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public int CreaterId { get; set; }
        public DateTime CreatedAt { get; set; }
        public short RoleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? IsActive { get; set; }
        public string NotificationContext { get; set; }

        public virtual Employee Creater { get; set; }
        public virtual Role Role { get; set; }
    }
}
