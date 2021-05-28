using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.DepartmentModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface IDeptManagementService
    {
        Task<TaskResponse<List<GetDepartmentDto>>> GetAll();
        Task<TaskResponse<List<GetDepartmentWithStandardDto>>> GetAllDepartmentWithStandard();
        Task<TaskResponse<GetDepartmentDto>> GetById(short id);
        Task<TaskResponse<GetDepartmentDto>> Update(UpdateDepartmentDto request);
        Task<TaskResponse<bool>> Add(AddDepartmentDto request);
        Task<TaskResponse<bool>> Delete(short id);
    }
}