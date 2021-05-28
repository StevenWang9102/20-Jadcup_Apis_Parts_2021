using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.WorkOrderStatusModel;

namespace Jadcup.Services.Interface.WorkOrderStatusService
{
    public interface IWorkOrderStatusManagementService
    {
         Task<TaskResponse<List<GetWorkOrderStatusDto>>> GetAll();
    }
}