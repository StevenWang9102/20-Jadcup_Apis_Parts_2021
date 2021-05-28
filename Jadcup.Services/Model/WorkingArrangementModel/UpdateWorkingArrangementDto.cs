using System;

namespace Jadcup.Services.Model.WorkingArrangementModel
{
    public class UpdateWorkingArrangementDto
    {
        public int? CreatedBy { get; set; }
        public short? MachineId { get; set; }
        public int ArrangementId { get; set; }
        public DateTime? WorkingDate { get; set; }
        public int? Operator { get; set; }
        public ulong? Maintenance { get; set; }
    }
}