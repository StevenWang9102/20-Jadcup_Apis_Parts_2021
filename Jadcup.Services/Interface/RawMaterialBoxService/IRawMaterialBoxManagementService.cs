using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.RawMaterialBoxModel;

namespace Jadcup.Services.Interface.RawMaterialBoxService
{
    public interface IRawMaterialBoxManagementService
    {
        Task<TaskResponse<List<GetRawMaterialBoxDto2>>> GetLocationByRawMaterialId(short rawMaterialId);
        Task<TaskResponse<List<GetRawMaterialBoxDto>>> GetAll(string inspectionId, ulong? active);
        Task<TaskResponse<GetRawMaterialBoxDto>> GetSingle(string id, string boxCode);
        Task<TaskResponse<GetRawMaterialBoxAndBoxDto>> AddList(List<AddRawMaterialBoxDto> request);
        Task<TaskResponse<bool>> Update(UpdateRawmaterialBoxDto request);
        Task<TaskResponse<bool>> Delete(string barCode);
        Task<TaskResponse<bool>> AddToPallet(short plateId, string barCode);
        Task<TaskResponse<bool>> UpdatePallet(short plateId, string barCode);
        Task<TaskResponse<bool>> Obsolete(string id);
        Task<TaskResponse<bool>> MoveBox(string rawMaterialBoxId, short newPlateId);
        Task<TaskResponse<GetRawMaterialBoxAndBoxDto>> GetByInspection(string inspectionId);
        Task<TaskResponse<bool>> AddListToPlate(List<AddPoBoxesToStockDto> request);
        Task<TaskResponse<bool>> UpdateStockQuantity(string id, decimal quanity);
        Task<TaskResponse<GetRawMaterialBoxAndBoxDto>> GenerateMaterialProductBox(string inspectionId, short rawMaterialId, short productQuantityPerBox, int boxCount);
    }
}