using System.Threading.Tasks;
using Jadcup.Services.Interface.ShelfPlateService;
using Jadcup.Services.Model.ShelfPlateModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.ShelfPlateController
{
    [ApiController]
    [Route("api/[controller]")]

    public class ShelfPlateController : Controller
    {
        private readonly IShelfPlateManagementService _shelfPlateManagementService;

        public ShelfPlateController(IShelfPlateManagementService shelfPlateManagementService)
        {
            _shelfPlateManagementService = shelfPlateManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllShelfPlate(short? cellId, short? plateId, ulong? active)
        {
            return Ok(await _shelfPlateManagementService.GetAll(cellId, plateId, active));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetShelfPlateById(int id)
        {
            return Ok(await _shelfPlateManagementService.GetById(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEmptyCell()
        {
            return Ok(await _shelfPlateManagementService.GetEmptyCell());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUnassignedPlate()
        {
            return Ok(await _shelfPlateManagementService.GetUnassignedPlate());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddShelfPlate(AddShelfPlateDto request)
        {
            return Ok(await _shelfPlateManagementService.Add(request));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> MovePlateToAnotherCell(short plateId, short newCellId)
        {
            return Ok(await _shelfPlateManagementService.MovePlate(plateId, newCellId));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateShelfPlate(UpdateShelfPlateDto request)
        {
            return Ok(await _shelfPlateManagementService.Update(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> MovePlateFromShelfToTempZone(short plateId, sbyte? zoneType)
        {
            return Ok(await _shelfPlateManagementService.MoveToTempZone(plateId, zoneType));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteShelfPlate(int id)
        {
            return Ok(await _shelfPlateManagementService.Delete(id));
        }
    }
}