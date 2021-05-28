using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.PageModel;

namespace Jadcup.Services.Interface.IPageService
{
    public interface IPageManagementService
    {
        Task<TaskResponse<List<GetPageDto>>> GetAll();
        Task<TaskResponse<GetPageDto>> GetById(short id);
        Task<TaskResponse<int>> Update(UpdatePageDto request);
        Task<TaskResponse<int>> Add(AddPageDto request);
        Task<TaskResponse<bool>> Delete(short id);
        Task<TaskResponse<List<GetPageDto>>> GetByGroup(short id);
    }
}