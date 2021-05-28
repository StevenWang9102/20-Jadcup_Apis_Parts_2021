using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup4;
namespace Jadcup.Services.Interface.SmallGroupManagementInterface.CustomerGrpManagementService
{
    public interface ICustomerGrp4ManagementService
    {
        Task<TaskResponse<List<GetGroup4Dto>>> GetAllGroup4();
        Task<TaskResponse<GetGroup4Dto>> GetGroup4ById(short id);
        Task<TaskResponse<GetGroup4Dto>> UpdateGroup4(UpdateGroup4Dto updatedGroup4);
        Task<TaskResponse<bool>> AddGroup4(AddGroup4Dto Group4);
        Task<TaskResponse<bool>> DeleteGroup4(short id);
    }
} 