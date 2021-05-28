using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class WorkingArrangement
    {
        public int? CreatedBy { get; set; }
        public short? MachineId { get; set; }
        public int ArrangementId { get; set; }
        public DateTime? WorkingDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? Operator { get; set; }
        public ulong? Maintenance { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Machine Machine { get; set; }
        public virtual Employee OperatorNavigation { get; set; }
    }
}
