using System;
using System.Threading.Tasks;
using Jadcup.Services.Interface.OrderService;
using Jadcup.Services.Model.OrderModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.OrderController
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesOrderController : Controller
    {
        private readonly IOrderManagementService _orderManagementService;
        public SalesOrderController(IOrderManagementService orderManagementService)
        {
            _orderManagementService = orderManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllOrder(sbyte? orderStatusId, DateTime? start, DateTime? end)
        {
            return Ok(await _orderManagementService.GetAll(orderStatusId, start, end));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByCust(int customerId)
        {
            return Ok(await _orderManagementService.GetByCust(customerId));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrderById(string id)
        {
            return Ok(await _orderManagementService.GetById(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDispachableOrder()
        {
            return Ok(await _orderManagementService.GetDispatchable());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddOrder(AddOrderDto2 request)
        {
            return Ok(await _orderManagementService.AddAll(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateOrder(UpdateOrderDto request)
        {
            return Ok(await _orderManagementService.Update(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateFullOrder(UpdateOrderDto2 request)
        {
            return Ok(await _orderManagementService.UpdateAll(request));
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateOrderStatus(string id, sbyte statusId)
        {
            return Ok(await _orderManagementService.UpdateStatus(id, statusId));
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> FinishDispatch(string id)
        {
            return Ok(await _orderManagementService.FinishDispatch(id));
        }
  
        [HttpPut("[action]")]
        public async Task<IActionResult> ApproveOrder(string id)
        {
            return Ok(await _orderManagementService.ApproveOrder(id));
        } 
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            return Ok(await _orderManagementService.Delete(id));
        }

    }
}