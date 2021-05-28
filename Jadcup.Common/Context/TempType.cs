using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class TempType
    {
        public TempType()
        {
            TempZone = new HashSet<TempZone>();
        }

        public sbyte ZoneType { get; set; }
        public string ZoneTypeName { get; set; }

        public virtual ICollection<TempZone> TempZone { get; set; }
    }
}
