using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class SuborderLog
    {
        public int Quantity { get; set; }
        public string Comment { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string SuborderLogId { get; set; }
        public string SuborderId { get; set; }
        public int? OperEmployeeId { get; set; }
        public string RawMaterialBoxId { get; set; }
        public short? MachineId { get; set; }
        public string BoxId { get; set; }
        public string RawMaterialBoxId2 { get; set; }

        public virtual Box Box { get; set; }
        public virtual Machine Machine { get; set; }
        public virtual Employee OperEmployee { get; set; }
        public virtual RawMaterialBox RawMaterialBox { get; set; }
        public virtual RawMaterialBox RawMaterialBoxId2Navigation { get; set; }
        public virtual Suborder Suborder { get; set; }
    }
}
