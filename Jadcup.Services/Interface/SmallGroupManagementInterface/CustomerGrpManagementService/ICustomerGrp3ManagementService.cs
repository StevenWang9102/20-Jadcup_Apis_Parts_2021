using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup3;
namespace Jadcup.Services.Interface.SmallGroupManagementInterface.CustomerGrpManagementService
{
    public interface ICustomerGrp3ManagementService
    {
        Task<TaskResponse<List<GetGroup3Dto>>> GetAllGroup3();
        Task<TaskResponse<GetGroup3Dto>> GetGroup3ById(short id);
        Task<TaskResponse<GetGroup3Dto>> UpdateGroup3(UpdateGroup3Dto updatedGroup3);
        Task<TaskResponse<bool>> AddGroup3(AddGroup3Dto Group3);
        Task<TaskResponse<bool>> DeleteGroup3(short id);
    }
} 