using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class RawMaterialBox
    {
        public RawMaterialBox()
        {
            ApplicationDetails = new HashSet<ApplicationDetails>();
            PlateBox = new HashSet<PlateBox>();
            StockLog = new HashSet<StockLog>();
            SuborderLogRawMaterialBox = new HashSet<SuborderLog>();
            SuborderLogRawMaterialBoxId2Navigation = new HashSet<SuborderLog>();
        }

        public string InspectionId { get; set; }
        public string RawMaterialBoxId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public ulong? Active { get; set; }
        public decimal? Quantity { get; set; }
        public short? RawMaterialId { get; set; }
        public string BoxCode { get; set; }

        public virtual UnloadingInspection Inspection { get; set; }
        public virtual RawMaterial RawMaterial { get; set; }
        public virtual ICollection<ApplicationDetails> ApplicationDetails { get; set; }
        public virtual ICollection<PlateBox> PlateBox { get; set; }
        public virtual ICollection<StockLog> StockLog { get; set; }
        public virtual ICollection<SuborderLog> SuborderLogRawMaterialBox { get; set; }
        public virtual ICollection<SuborderLog> SuborderLogRawMaterialBoxId2Navigation { get; set; }
    }
}
