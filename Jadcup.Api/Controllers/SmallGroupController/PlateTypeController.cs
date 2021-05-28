using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.PlateTypeModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlateTypeController : Controller
    {
        private readonly IPlateTypeManagementService _plateTypeManagementService;

        public PlateTypeController(IPlateTypeManagementService plateTypeManagementService)
        {
            _plateTypeManagementService = plateTypeManagementService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddPlateType(AddPlateTypeDto request)
        {
            return Ok(await _plateTypeManagementService.Add(request));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePlateType(short id)
        {
            return Ok(await _plateTypeManagementService.Delete(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPlateType()
        {
            return Ok(await _plateTypeManagementService.GetAll());
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetPlateTypeById(short id)
        {
            return Ok(await _plateTypeManagementService.GetById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePlateType(UpdatePlateTypeDto request)
        {
            return Ok(await _plateTypeManagementService.Update(request));
        }
    }
}