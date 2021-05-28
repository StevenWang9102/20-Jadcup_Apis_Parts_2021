using System;

namespace Jadcup.Services.Model.WorkingArrangementModel
{
    public class AddWorkingArrangementDto
    {
        public int? CreatedBy { get; set; }
        public short? MachineId { get; set; }
        public DateTime? WorkingDate { get; set; }
        public int? Operator { get; set; }
        public ulong? Maintenance { get; set; }
    }
}