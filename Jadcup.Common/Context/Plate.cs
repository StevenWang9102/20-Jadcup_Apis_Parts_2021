using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Plate
    {
        public Plate()
        {
            PlateBox = new HashSet<PlateBox>();
            ShelfPlate = new HashSet<ShelfPlate>();
            TempZone = new HashSet<TempZone>();
        }

        public short PlateId { get; set; }
        public string PlateCode { get; set; }
        public ulong Active { get; set; }
        public short? PlateTypeId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public ulong? Package { get; set; }

        public virtual PlateType PlateType { get; set; }
        public virtual ICollection<PlateBox> PlateBox { get; set; }
        public virtual ICollection<ShelfPlate> ShelfPlate { get; set; }
        public virtual ICollection<TempZone> TempZone { get; set; }
    }
}
