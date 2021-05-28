using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.PlateBoxModel;

namespace Jadcup.Services.Interface.PlateBoxService
{
    public interface IPlateBoxManagementService
    {
         Task<TaskResponse<List<GetPlateBoxDto>>> GetAll(string suborderId);
         Task<TaskResponse<GetPlateBoxDto>> GetById(int id);
         Task<TaskResponse<List<GetPlateBoxDto>>> GetBoxHistory(string boxId);
         Task<TaskResponse<List<GetPlateBoxDto>>> GetRawMaterialHistory(string rawMaterialBoxId);
         Task<TaskResponse<bool>> Update(UpdatePlateBoxDto request);
         Task<TaskResponse<bool>> UpdateList(List<UpdatePlateBoxDto2> request);
         Task<TaskResponse<int>> Add(AddPlateBoxDto request);
         Task<TaskResponse<bool>> AddList(List<AddPlateBoxDto> request);
         Task<TaskResponse<bool>> Delete(int id);
         Task<TaskResponse<bool>> AddListAndUpdateQuantity(List<AddPlateBoxDto2> request);
         Task<TaskResponse<bool>> AddAndUpdateList(AddAndUpdatePlateBoxDto request);
         Task<TaskResponse<bool>> MoveBox(List<MovePlateBoxDto> request);
    }
}