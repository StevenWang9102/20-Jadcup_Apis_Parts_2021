using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.RawMaterialModel;

namespace Jadcup.Services.Interface.RawMaterialService
{
    public interface IRawMaterialManagementService
    {
        Task<TaskResponse<List<GetRawMaterialDto>>> GetAll();
        Task<TaskResponse<GetRawMaterialDto>> GetById(short id);
        Task<TaskResponse<GetRawMaterialDto>> Update(UpdateRawMaterialDto request);
        Task<TaskResponse<short>> Add(AddRawMaterialDto request);
        Task<TaskResponse<bool>> Delete(short id);
    }
}