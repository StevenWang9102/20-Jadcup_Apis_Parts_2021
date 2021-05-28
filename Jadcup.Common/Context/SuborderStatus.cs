using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class SuborderStatus
    {
        public SuborderStatus()
        {
            Suborder = new HashSet<Suborder>();
        }

        public sbyte SuborderStatusId { get; set; }
        public string SuborderStatusName { get; set; }

        public virtual ICollection<Suborder> Suborder { get; set; }
    }
}
