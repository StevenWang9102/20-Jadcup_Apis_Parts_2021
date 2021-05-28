using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.WorkOrderSourceModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface IWorkOrderSourceManagementService
    {
         Task<TaskResponse<List<GetWorkOrderSourceDto>>> GetAll();
    }
}