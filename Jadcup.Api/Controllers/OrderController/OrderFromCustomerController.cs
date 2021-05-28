using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Jadcup.Services.Model.OrderModel;
using Jadcup.Services.Interface.OrderService;
using Jadcup.Common.Response;
using Jadcup.Common.Model;

namespace Jadcup.Api.Controllers.OrderController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderFromCustomerController : Controller
    {
        private readonly IOrderFromCustomerManagementService _iOrderFromCustomerManagementService;

        public OrderFromCustomerController(IOrderFromCustomerManagementService iOrderFromCustomerManagementService)
        {
            _iOrderFromCustomerManagementService = iOrderFromCustomerManagementService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddOrders(AddOrderDto2 request)
        {
            return Ok(await _iOrderFromCustomerManagementService.AddById(request));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrdersFromCustomer()
        {
            return Ok(await _iOrderFromCustomerManagementService.GetAll());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrdersById(int id)
        {
            return Ok(await _iOrderFromCustomerManagementService.GetById(id));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteOrders(string id)
        {
            return Ok(await _iOrderFromCustomerManagementService.DeleteById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateWebOrder(UpdateOrderDto3 request)
        {
            return Ok(await _iOrderFromCustomerManagementService.Update(request));
        }
    }
}
