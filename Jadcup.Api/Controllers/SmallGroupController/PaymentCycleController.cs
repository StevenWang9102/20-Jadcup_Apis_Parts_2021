using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.PaymentCycleModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentCycleController : Controller
    {
        private readonly IPaymentCycleManagementService _paymentCycleManagementService;
        public PaymentCycleController(IPaymentCycleManagementService paymentCycleManagementService)
        {
            _paymentCycleManagementService = paymentCycleManagementService;

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddPaymentCycle(AddPaymentCycleDto request)
        {
            return Ok(await _paymentCycleManagementService.Add(request));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePaymentCycle(short id)
        {
            return Ok(await _paymentCycleManagementService.Delete(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPaymentCycle()
        {
            return Ok(await _paymentCycleManagementService.GetAll());
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetPaymentCycleById(short id)
        {
            return Ok(await _paymentCycleManagementService.GetById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePaymentCycle(UpdatePaymentCycleDto request)
        {
            return Ok(await _paymentCycleManagementService.Update(request));
        }
    }
}