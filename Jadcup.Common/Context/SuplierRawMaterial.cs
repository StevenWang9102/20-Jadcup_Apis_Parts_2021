using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class SuplierRawMaterial
    {
        public short SuplierId { get; set; }
        public short? RawMaterialId { get; set; }
        public int SuplierRawMaterialId { get; set; }

        public virtual RawMaterial RawMaterial { get; set; }
        public virtual Suplier Suplier { get; set; }
    }
}
