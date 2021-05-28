using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup2;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface.CustomerGrpManagementService
{
    public interface ICustomerGrp2ManagementService
    {
        Task<TaskResponse<List<GetGroup2Dto>>> GetAllGroup2();
        Task<TaskResponse<GetGroup2Dto>> GetGroup2ById(short id);
        Task<TaskResponse<GetGroup2Dto>> UpdateGroup2(UpdateGroup2Dto updatedGroup2);
        Task<TaskResponse<bool>> AddGroup2(AddGroup2Dto Group2);
        Task<TaskResponse<bool>> DeleteGroup2(short id);
    }
}