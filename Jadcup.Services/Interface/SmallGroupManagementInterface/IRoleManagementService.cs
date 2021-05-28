using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.RoleModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface IRoleManagementService
    {
        Task<TaskResponse<List<GetRoleDto>>> GetAll();
        Task<TaskResponse<GetRoleDto>> GetById(short id);
        Task<TaskResponse<GetRoleDto>> Update(UpdateRoleDto request);
        Task<TaskResponse<bool>> Add(AddRoleDto request);
        Task<TaskResponse<bool>> Delete(short id);
    }
}