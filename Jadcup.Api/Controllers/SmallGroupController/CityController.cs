using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.CityModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    /// <summary>
    /// City Name management related to Customer and Order table
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : Controller
    {
        private readonly ICityManagementService _cityManagementService;
        public CityController(ICityManagementService cityManagementService)
        {
            _cityManagementService = cityManagementService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddCity(AddCityDto city)
        {
            return Ok(await _cityManagementService.AddCity(city));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCity(short id)
        {
            return Ok(await _cityManagementService.DeleteCity(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCity()
        {
            return Ok(await _cityManagementService.GetAllCities());
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetCityById(short id)
        {
            return Ok(await _cityManagementService.GetCityById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCity(UpdateCityDto updatedCity)
        {
            return Ok(await _cityManagementService.UpdateCity(updatedCity));
        }
    }
}