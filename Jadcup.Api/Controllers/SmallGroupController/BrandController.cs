using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.BrandModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    /// <summary>
    /// Brand Type management related to Customer table
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : Controller
    {
        private readonly IBrandManagementService _brandManagementService;
        public BrandController(IBrandManagementService brandManagementService)
        {
            _brandManagementService = brandManagementService;

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddBrand(AddBrandDto brand)
        {
            return Ok(await _brandManagementService.AddBrand(brand));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteBrand(short id)
        {
            return Ok(await _brandManagementService.DeleteBrand(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllBrand()
        {
            return Ok(await _brandManagementService.GetAllBrands());
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetBrandById(short id)
        {
            return Ok(await _brandManagementService.GetBrandById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updatedBrand)
        {
            return Ok(await _brandManagementService.UpdateBrand(updatedBrand));
        }
    }
}