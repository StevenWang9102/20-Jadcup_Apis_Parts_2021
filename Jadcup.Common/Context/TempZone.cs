using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class TempZone
    {
        public int TempZoneId { get; set; }
        public short? PlateId { get; set; }
        public ulong? Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public sbyte? ZoneType { get; set; }

        public virtual Plate Plate { get; set; }
        public virtual ZoneType ZoneTypeNavigation { get; set; }
    }
}
