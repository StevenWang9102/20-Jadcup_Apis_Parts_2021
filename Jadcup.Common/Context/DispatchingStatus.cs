using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class DispatchingStatus
    {
        public DispatchingStatus()
        {
            Dispatching = new HashSet<Dispatching>();
        }

        public sbyte Status { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Dispatching> Dispatching { get; set; }
    }
}
