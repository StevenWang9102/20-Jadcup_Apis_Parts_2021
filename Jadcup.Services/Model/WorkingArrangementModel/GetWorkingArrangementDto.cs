using System;
using Jadcup.Common.Context;
using Jadcup.Services.Model.EmployeeModel;
using Jadcup.Services.Model.MachineModel;

namespace Jadcup.Services.Model.WorkingArrangementModel
{
    public class GetWorkingArrangementDto
    {
        public int? CreatedBy { get; set; }
        public short? MachineId { get; set; }
        public int ArrangementId { get; set; }
        public DateTime? WorkingDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? Operator { get; set; }
        public ulong? Maintenance { get; set; }        

        public GetEmployeeDto2 CreatedByNavigation { get; set; }
        public GetMachineDto Machine { get; set; }
        public GetEmployeeDto2 OperatorNavigation { get; set; }
    }
}