using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerStatusController : Controller
    {
        private readonly ICustomerStatusManagementService _customerStatusManagementService;
        public CustomerStatusController(ICustomerStatusManagementService customerStatusManagementService)
        {
            _customerStatusManagementService = customerStatusManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCustomerStatus()
        {
            return Ok(await _customerStatusManagementService.GetAll());
        }
    }
}