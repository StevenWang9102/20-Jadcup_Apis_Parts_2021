using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.DispatchingStatusModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface IDispatchingStatusManagementService
    {
        Task<TaskResponse<List<GetDispatchingStatusDto>>> GetAll();
    }
}