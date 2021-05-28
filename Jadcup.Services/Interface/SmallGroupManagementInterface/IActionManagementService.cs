using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.ActionModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface IActionManagementService
    {
         Task<TaskResponse<List<GetActionDto>>> GetAll();
    }
}