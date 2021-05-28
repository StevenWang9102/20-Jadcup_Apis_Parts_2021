using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class OnlineUser
    {
        public short UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? CustomerId { get; set; }
        public ulong? Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Salt { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
