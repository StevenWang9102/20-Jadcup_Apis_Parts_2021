using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.PackagingTypeModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackagingTypeController : Controller
    {
        private readonly IPackagingTypeManagementService _packagingTypeManagementService;

        public PackagingTypeController(IPackagingTypeManagementService packagingTypeManagementService)
        {
            _packagingTypeManagementService = packagingTypeManagementService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddPackagingType(AddPackagingTypeDto request)
        {
            return Ok(await _packagingTypeManagementService.Add(request));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePackagingType(short id)
        {
            return Ok(await _packagingTypeManagementService.Delete(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPackagingType()
        {
            return Ok(await _packagingTypeManagementService.GetAll());
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetPackagingTypeById(short id)
        {
            return Ok(await _packagingTypeManagementService.GetById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePackagingType(UpdatePackagingTypeDto request)
        {
            return Ok(await _packagingTypeManagementService.Update(request));
        }
    }
}