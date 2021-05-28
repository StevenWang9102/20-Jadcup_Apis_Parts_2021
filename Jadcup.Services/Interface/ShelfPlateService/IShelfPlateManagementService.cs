using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.CellModel;
using Jadcup.Services.Model.PlateModel;
using Jadcup.Services.Model.ShelfPlateModel;

namespace Jadcup.Services.Interface.ShelfPlateService
{
    public interface IShelfPlateManagementService
    {
         Task<TaskResponse<List<GetShelfPlateDto>>> GetAll(short? cellId, short? plateId, ulong? active);
         Task<TaskResponse<GetShelfPlateDto>> GetById(int id);
         Task<TaskResponse<int>> Add(AddShelfPlateDto request);
         Task<TaskResponse<bool>> Update(UpdateShelfPlateDto request);
         Task<TaskResponse<bool>> Delete(int id);
         Task<TaskResponse<int>> MovePlate(short plateId, short cellId);
         Task<TaskResponse<List<GetPlateDto>>> GetUnassignedPlate();
         Task<TaskResponse<List<GetCellDto>>> GetEmptyCell();
         Task<TaskResponse<bool>> MoveToTempZone(short plateId, sbyte? zoneType);
    }
}