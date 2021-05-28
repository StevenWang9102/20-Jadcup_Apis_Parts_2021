using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.PageModel;
using Jadcup.Services.Model.RolePageModel;

namespace Jadcup.Services.Interface.RolePageService
{
    public interface IRolePageService
    {
         Task<TaskResponse<List<GetRolePageDto>>> GetAll(); 
         Task<TaskResponse<GetRolePageDto>> GetById(short id);
         Task<TaskResponse<int>> Add(AddRolePageDto request);
         Task<TaskResponse<bool>> Delete(short id);
         Task<TaskResponse<List<GetPageDto>>> GetPageByRoleId(short id);
         Task<TaskResponse<List<GetRolePageDto>>> GetByRoleId(short id);
    }
}