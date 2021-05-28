using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Zone
    {
        public Zone()
        {
            Shelf = new HashSet<Shelf>();
        }

        public sbyte ZoneId { get; set; }
        public string ZoneCode { get; set; }
        public ulong? Active { get; set; }

        public virtual ICollection<Shelf> Shelf { get; set; }
    }
}
