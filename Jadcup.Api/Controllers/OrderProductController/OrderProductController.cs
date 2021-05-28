using System.Threading.Tasks;
using Jadcup.Services.Interface.OrderProductService;
using Jadcup.Services.Model.OrderProductModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.OrderProductController
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderProductController : Controller
    {
        private readonly IOrderProductManagementService _orderProductManagementService;
        public OrderProductController(IOrderProductManagementService orderProductManagementService)
        {
            _orderProductManagementService = orderProductManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllOrderProduct()
        {
            return Ok(await _orderProductManagementService.GetAll());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrderProductById(string id)
        {
            return Ok(await _orderProductManagementService.GetById(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddOrderProduct(AddOrderProductDto request)
        {
            return Ok(await _orderProductManagementService.Add(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateOrderProduct(UpdateOrderProductDto request)
        {
            return Ok(await _orderProductManagementService.Update(request));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteOrderProduct(string id)
        {
            return Ok(await _orderProductManagementService.Delete(id));
        }
    }
}