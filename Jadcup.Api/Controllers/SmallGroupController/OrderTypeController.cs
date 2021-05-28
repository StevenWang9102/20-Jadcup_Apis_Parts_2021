using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderTypeController : Controller
    {
        private readonly IOrderTypeManagementService _orderTypeManagementService;
        public OrderTypeController(IOrderTypeManagementService orderTypeManagementService)
        {
            _orderTypeManagementService = orderTypeManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllOrderType()
        {
            return Ok(await _orderTypeManagementService.GetAll());
        }
    }
}