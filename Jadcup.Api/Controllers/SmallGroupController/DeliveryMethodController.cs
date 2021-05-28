using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.DeliveryMethodModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]

    public class DeliveryMethodController : Controller
    {
        private readonly IDeliveryMethodManagementService _deliveryMethodManagementService;
        public DeliveryMethodController(IDeliveryMethodManagementService deliveryMethodManagementService)
        {
            _deliveryMethodManagementService = deliveryMethodManagementService;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddDeliveryMethod(AddDeliveryMethodDto request)
        {
            return Ok(await _deliveryMethodManagementService.Add(request));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteDeliveryMethod(short id)
        {
            return Ok(await _deliveryMethodManagementService.Delete(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllDeliveryMethod()
        {
            return Ok(await _deliveryMethodManagementService.GetAll());
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetDeliveryMethodById(short id)
        {
            return Ok(await _deliveryMethodManagementService.GetById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateDeliveryMethod(UpdateDeliveryMethodDto request)
        {
            return Ok(await _deliveryMethodManagementService.Update(request));
        }
    }
}