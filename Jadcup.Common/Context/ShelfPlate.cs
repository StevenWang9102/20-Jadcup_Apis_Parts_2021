using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class ShelfPlate
    {
        public short? CellId { get; set; }
        public short? PlateId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ulong? Active { get; set; }
        public int ShelfPlateId { get; set; }

        public virtual Cell Cell { get; set; }
        public virtual Plate Plate { get; set; }
    }
}
