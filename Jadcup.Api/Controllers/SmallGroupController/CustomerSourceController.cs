using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.CustomerSourceModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerSourceController : Controller
    {
        private readonly ICustomerSourceManagementService _customerSourceManagementService;
        public CustomerSourceController(ICustomerSourceManagementService customerSourceManagementService)
        {
            _customerSourceManagementService = customerSourceManagementService;

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddCustomerSource(AddCustomerSourceDto request)
        {
            return Ok(await _customerSourceManagementService.Add(request));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCustomerSource(short id)
        {
            return Ok(await _customerSourceManagementService.Delete(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCustomerSource()
        {
            return Ok(await _customerSourceManagementService.GetAll());
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetCustomerSourceById(short id)
        {
            return Ok(await _customerSourceManagementService.GetById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCustomerSource(UpdateCustomerSourceDto request)
        {
            return Ok(await _customerSourceManagementService.Update(request));
        }
    }
}