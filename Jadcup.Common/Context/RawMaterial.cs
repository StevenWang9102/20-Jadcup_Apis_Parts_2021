using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class RawMaterial
    {
        public RawMaterial()
        {
            BaseProductRawMaterial = new HashSet<BaseProduct>();
            BaseProductRawMaterialId2Navigation = new HashSet<BaseProduct>();
            PoDetail = new HashSet<PoDetail>();
            RawMaterialApplication = new HashSet<RawMaterialApplication>();
            RawMaterialBox = new HashSet<RawMaterialBox>();
            SuplierRawMaterial = new HashSet<SuplierRawMaterial>();
        }

        public short RawMaterialId { get; set; }
        public string RawMaterialCode { get; set; }
        public string RawMaterialName { get; set; }
        public decimal? AlarmLimit { get; set; }
        public ulong? Active { get; set; }

        public virtual ICollection<BaseProduct> BaseProductRawMaterial { get; set; }
        public virtual ICollection<BaseProduct> BaseProductRawMaterialId2Navigation { get; set; }
        public virtual ICollection<PoDetail> PoDetail { get; set; }
        public virtual ICollection<RawMaterialApplication> RawMaterialApplication { get; set; }
        public virtual ICollection<RawMaterialBox> RawMaterialBox { get; set; }
        public virtual ICollection<SuplierRawMaterial> SuplierRawMaterial { get; set; }
    }
}
