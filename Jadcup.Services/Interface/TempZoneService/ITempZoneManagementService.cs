using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.StockLogModel;
using Jadcup.Services.Model.TempZoneModel;
using Jadcup.Services.Model.ZoneTypeModel;
namespace Jadcup.Services.Interface.TempZoneService
{
    public interface ITempZoneManagementService
    {
         Task<TaskResponse<List<GetTempZoneDto>>> GetAll(short? plateId, ulong? active, sbyte? zoneType);
         Task<TaskResponse<bool>> Add(List<AddStockLogDto> request, short plateId);
         Task<TaskResponse<List<GetZoneTypeDto>>> GetZoneType();
         Task<TaskResponse<bool>> Delete(short plateId);
         Task<TaskResponse<bool>> MovePlateToShelf(short plateId, short cellId);
         Task<TaskResponse<bool>> Clear();
         Task<TaskResponse<bool>> MovePlateToTempZone(short plateId,sbyte zoneTypeId);
         Task<TaskResponse<bool>> MovePlateFromZone2ToZone1(short plateId);
    }
}