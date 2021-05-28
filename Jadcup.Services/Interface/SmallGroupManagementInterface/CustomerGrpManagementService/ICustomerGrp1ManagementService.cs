using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup1;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface.CustomerGrpManagementService
{
    public interface ICustomerGrp1ManagementService
    {
        Task<TaskResponse<List<GetGroup1Dto>>> GetAllGroup1();
        Task<TaskResponse<GetGroup1Dto>> GetGroup1ById(short id);
        Task<TaskResponse<GetGroup1Dto>> UpdateGroup1(UpdateGroup1Dto updatedGroup1);
        Task<TaskResponse<bool>> AddGroup1(AddGroup1Dto Group1);
        Task<TaskResponse<bool>> DeleteGroup1(short id);
    }
}