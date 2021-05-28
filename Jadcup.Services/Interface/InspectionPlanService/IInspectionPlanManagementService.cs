using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.InspectionPlanModel;
using Jadcup.Services.Model.InspectionLogModel;
using Jadcup.Services.Model.MachineModel;
using Jadcup.Services.Model.StandardModel;

namespace Jadcup.Services.Interface.InspectionPlanService
{
    public interface IInspectionPlanManagementService
    {
        Task<TaskResponse<bool>> Add(AddInspectionPlanDto request);
        Task<TaskResponse<List<GetInspectionPlanDto>>> GetAllPlan(DateTime? start, DateTime? end, short? machineId);
        Task<TaskResponse<bool>> UpdatePlan(UpdateInspectionPlanDto request);
        Task<TaskResponse<bool>> Delete(int planId);
        Task<TaskResponse<List<GetInspectionLogDto>>> GetAllLog(DateTime? start, DateTime? end, short? machineId, int? planId);
        Task<TaskResponse<bool>> UpdateLog(UpdateInspectionLogDto request);
        Task<TaskResponse<List<GetMachineDto>>> GetMachineWithPlan(DateTime date);
        Task<TaskResponse<List<GetStandardDto>>> GetAllStandard();
        // Task<TaskResponse<bool>> AddLog(AddInspectionLogDto request);
        // Task<TaskResponse<InspectionPlanByPeriodicityDto>> GetInspectionPlanByPeriodicityDtoByMachineIdWithDate(short machineId, DateTime date);
        // Task<TaskResponse<List<GetInspectionLogDto>>> GetLogByMachineIdWithDate(short machineId, DateTime date);
    }
}
/* Possible test cases and explanations for all those APIs.
 * 
 * Add(AddInspectionPlanDto request) --- add a new InspectionPlan
 * {
        "StartDate" : "2021-05-01",
        "EndDate" : "2021-05-15",
        "StartTimeHour" : 8,
        "StartTimeMinute" : 0,
        "EndTimeHour" : 17,
        "EndTimeMinute" : 0,
        "MachineId" : 13,
        "StandardId" : 2,
        "Periodicity" : 60
    }
 *  StartTimeHour, StartTimeMinute mean the start time on everyday during date range,
 *  Same with EndTimeHour and EndTimeMinute
 *  ***Periodicity***, range(0, 1439), the unit is one minute.
 *  the interval can be 0, until 23h59m, which is 1439.
 *  Therefore, 60 means 1h.
 *  =================================================================================
 *  
 *  AddLog(AddInspectionLogDto request) --- add new InspectionLogs by passing a list
 *  {
        "MachineId" : 13,
        "PlanId" : 6,
        "PlanInspectDate" : "2021-05-10",
        "InspectionLogs" : [
            {
                "PlanInspectTimeHour" : 8,
                "PlanInspectTimeMinute" : 0,
                "PlanInspectTimeSecond" : 0,
                "InspectTimeHour" : 8,
                "InspectTimeMinute" : 5,
                "InspectTimeSecond" : 0,
                "Passed" : 0,
                "EmployeeId" : 36,
                "Comment" : "new log301"
            },
            {
                "PlanInspectTimeHour" : 9,
                "PlanInspectTimeMinute" : 1,
                "PlanInspectTimeSecond" : 0,
                "InspectTimeHour" : 9,
                "InspectTimeMinute" : 5,
                "InspectTimeSecond" : 0,
                "Passed" : 1,
                "EmployeeId" : 36,
                "Comment" : "new log302"
            },
            {
                "PlanInspectTimeHour" : 10,
                "PlanInspectTimeMinute" : 2,
                "PlanInspectTimeSecond" : 0,
                "InspectTimeHour" : 10,
                "InspectTimeMinute" : 5,
                "InspectTimeSecond" : 0,
                "Passed" : 1,
                "EmployeeId" : 36,
                "Comment" : "new log303"
            },
            {
                "PlanInspectTimeHour" : 11,
                "PlanInspectTimeMinute" : 3,
                "PlanInspectTimeSecond" : 0,
                "InspectTimeHour" : 11,
                "InspectTimeMinute" : 5,
                "InspectTimeSecond" : 0,
                "Passed" : 1,
                "EmployeeId" : 36,
                "Comment" : "new log304"
            }
        ]
    }
    =================================================================================

    GetInspectionPlanByPeriodicityDtoByMachineIdWithDate(short machineId, DateTime date)

    According to the period, we add it from start time (includsive) until end time (excludsive).
    The result is an array with these info.
    http://localhost:5020/api/InspectionPlan/GetInspectionPlanByMachineIdWithDate?machineId=13&date=2021-04-10
    =================================================================================

    GetLogByMachineIdWithDate(short machineId, DateTime date) --- Get log by date and machine
    http://localhost:5020/api/InspectionPlan/GetInspectionLogByMachineIdWithDate?machineId=11&date=2021-03-20
 */
