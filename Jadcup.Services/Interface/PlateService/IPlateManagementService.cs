using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.BoxModel;
using Jadcup.Services.Model.PlateModel;

namespace Jadcup.Services.Interface.PlateService
{
    public interface IPlateManagementService
    {
        Task<TaskResponse<List<GetPlateDto>>> GetAll(short? plateTypeId);
        Task<TaskResponse<List<GetPlateDto>>> GetInUsing(short? plateTypeId);
        
        Task<TaskResponse<GetPlateDto>> GetById(short id);
        Task<TaskResponse<GetPlateDto>> GetByCode(string code);
        Task<TaskResponse<GetPlateDto>> GetByBoxId(string boxId);
        Task<TaskResponse<GetPlateDto>> GetByRawMaterialBox(string rawMaterialBoxId);
        Task<TaskResponse<List<GetBoxDto2>>> GetBoxByPlateId(short id);
        Task<TaskResponse<bool>> Update(UpdatePlateDto request);
        Task<TaskResponse<short>> AddNormalPlate(short? plateTypeId, string plateCode);
        Task<TaskResponse<short>> AddTemporaryPlate(short plateTypeId);
        Task<TaskResponse<bool>> Delete(short id);
        Task<TaskResponse<List<GetPlateDto>>> GetAvailable(ulong? package);
        Task<TaskResponse<List<GetPlateDto>>> GetEmptyAvailable(ulong? package);            
        Task<TaskResponse<bool>> UpdatePackage(short plateId, ulong pakage);
    }
}