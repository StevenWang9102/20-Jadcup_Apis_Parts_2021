using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Services.Interface.TempZoneService;
using Jadcup.Services.Model.StockLogModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.TempZoneController
{
    [ApiController]
    [Route("api/[controller]")]
    public class TempZoneController : Controller
    {
        private readonly ITempZoneManagementService _tempZoneManagementService;
        public TempZoneController(ITempZoneManagementService tempZoneManagementService)
        {
            _tempZoneManagementService = tempZoneManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllTempZone(short? plateId, ulong? active, sbyte? zoneType)
        {
            return Ok(await _tempZoneManagementService.GetAll(plateId, active, zoneType));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetZoneType()
        {
            return Ok(await _tempZoneManagementService.GetZoneType());
        }        

        [HttpPost("[action]")]
        public async Task<IActionResult> AddTempZone(List<AddStockLogDto> request, short plateId)
        {
            return Ok(await _tempZoneManagementService.Add(request, plateId));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> MovePlateToShelf(short plateId, short cellId)
        {
            return Ok(await _tempZoneManagementService.MovePlateToShelf(plateId, cellId));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> MovePlateToTempZone(short plateId,sbyte zoneTypeId)
        {
            return Ok(await _tempZoneManagementService.MovePlateToTempZone(plateId,zoneTypeId));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> MovePlateFromZone2ToZone1(short plateId)
        {
            return Ok(await _tempZoneManagementService.MovePlateFromZone2ToZone1(plateId));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteTempZone(short plateId)
        {
            return Ok(await _tempZoneManagementService.Delete(plateId));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> ClearEmptyPlateFromTempZone()
        {
            return Ok(await _tempZoneManagementService.Clear());
        }
    }
}