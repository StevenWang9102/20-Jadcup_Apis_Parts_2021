using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.HumanResource.Quarter;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface IQuarterManagementService
    {
        Task<TaskResponse<List<GetQuarterDto>>> GetAll();
        Task<TaskResponse<GetQuarterDto>> GetById(short id);
        Task<TaskResponse<GetQuarterDto>> Update(UpdateQuarterDto request);
        Task<TaskResponse<bool>> Add(AddQuarterDto request);
        Task<TaskResponse<bool>> Delete(short id);
    }
}