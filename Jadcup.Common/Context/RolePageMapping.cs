using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class RolePageMapping
    {
        public short MappingId { get; set; }
        public short? RoleId { get; set; }
        public short? PageId { get; set; }

        public virtual Page Page { get; set; }
        public virtual Role Role { get; set; }
    }
}
