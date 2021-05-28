using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class ZoneType
    {
        public ZoneType()
        {
            TempZone = new HashSet<TempZone>();
        }

        public sbyte ZoneType1 { get; set; }
        public string ZoneTypeName { get; set; }

        public virtual ICollection<TempZone> TempZone { get; set; }
    }
}
