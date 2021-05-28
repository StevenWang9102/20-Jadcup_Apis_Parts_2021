using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.SuborderStatusModel;

namespace Jadcup.Services.Interface.SuborderStatusService
{
    public interface ISuborderStatusManagementService
    {
         Task<TaskResponse<List<GetSuborderStatusDto>>> GetAll();
    }
}