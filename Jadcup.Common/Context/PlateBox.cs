using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class PlateBox
    {
        public short? PlateId { get; set; }
        public string BoxId { get; set; }
        public int PlateBoxId { get; set; }
        public ulong? Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string RawMaterialBoxId { get; set; }

        public virtual Box Box { get; set; }
        public virtual Plate Plate { get; set; }
        public virtual RawMaterialBox RawMaterialBox { get; set; }
    }
}
