using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderStatusController : Controller
    {
        private readonly IOrderStatusManagementService _orderStatusManagementService;
        public OrderStatusController(IOrderStatusManagementService orderStatusManagementService)
        {
            _orderStatusManagementService = orderStatusManagementService;

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllOrderStatus()
        {
            return Ok(await _orderStatusManagementService.GetAll());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrderStatusById(sbyte id)
        {
            return Ok(await _orderStatusManagementService.GetById(id));
        }
    }
}