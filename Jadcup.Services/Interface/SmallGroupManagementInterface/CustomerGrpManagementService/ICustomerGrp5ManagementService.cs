using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup5;
namespace Jadcup.Services.Interface.SmallGroupManagementInterface.CustomerGrpManagementService
{
    public interface ICustomerGrp5ManagementService
    {
        Task<TaskResponse<List<GetGroup5Dto>>> GetAllGroup5();
        Task<TaskResponse<GetGroup5Dto>> GetGroup5ById(short id);
        Task<TaskResponse<GetGroup5Dto>> UpdateGroup5(UpdateGroup5Dto updatedGroup5);
        Task<TaskResponse<bool>> AddGroup5(AddGroup5Dto Group5);
        Task<TaskResponse<bool>> DeleteGroup5(short id);
    }
} 