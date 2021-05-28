using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.PoStatusModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface IPoStatusManagementService
    {
         Task<TaskResponse<List<GetPoStatusDto>>> GetAll();
    }
}