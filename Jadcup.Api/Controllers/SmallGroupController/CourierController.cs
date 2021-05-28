using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.CourierModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]

    public class CourierController : Controller
    {
        private readonly ICourierManagementService _courierManagementService;
        public CourierController(ICourierManagementService courierManagementService)
        {
            _courierManagementService = courierManagementService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddCourier(AddCourierDto request)
        {
            return Ok(await _courierManagementService.Add(request));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCourier(sbyte id)
        {
            return Ok(await _courierManagementService.Delete(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCourier()
        {
            return Ok(await _courierManagementService.GetAll());
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetCourierById(sbyte id)
        {
            return Ok(await _courierManagementService.GetById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCourier(UpdateCourierDto request)
        {
            return Ok(await _courierManagementService.Update(request));
        }
    }
}