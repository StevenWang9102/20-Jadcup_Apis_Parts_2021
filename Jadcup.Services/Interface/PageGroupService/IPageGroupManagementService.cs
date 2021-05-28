using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.PageGroupModel;
using Jadcup.Services.Model.PageModel;

namespace Jadcup.Services.Interface.PageGroupService
{
    public interface IPageGroupManagementService
    {

        Task<TaskResponse<List<GetPageGroupDto>>> GetAll();
        Task<TaskResponse<GetPageGroupDto>> GetById(short id);
        Task<TaskResponse<GetPageGroupDto>> Update(UpdatePageGroupDto request);
        Task<TaskResponse<bool>> Add(AddPageGroupDto request);
        Task<TaskResponse<bool>> Delete(short id);
        Task<TaskResponse<List<PageGroupPageDto>>> GetPageByGroupId(short id);

    }
}