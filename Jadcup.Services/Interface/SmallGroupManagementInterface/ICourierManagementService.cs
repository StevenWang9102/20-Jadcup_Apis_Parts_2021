using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.CourierModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface ICourierManagementService
    {
        Task<TaskResponse<List<GetCourierDto>>> GetAll();
        Task<TaskResponse<GetCourierDto>> GetById(sbyte id);
        Task<TaskResponse<GetCourierDto>> Update(UpdateCourierDto request);
        Task<TaskResponse<bool>> Add(AddCourierDto request);
        Task<TaskResponse<bool>> Delete(sbyte id);
    }
}