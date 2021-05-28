using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface.CustomerGrpManagementService;
using Microsoft.AspNetCore.Mvc;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup5;

namespace Jadcup.Api.Controllers.SmallGroupController.CustomerGrpController
{

    [ApiController]
    [Route("api/[controller]")]

    public class CustomerGrp5Controller : Controller
    {
        private readonly ICustomerGrp5ManagementService _customerGrp5ManagementService;
        public CustomerGrp5Controller(ICustomerGrp5ManagementService customerGrp5ManagementService)
        {
            _customerGrp5ManagementService = customerGrp5ManagementService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddGroup5(AddGroup5Dto Group5)
        {
            return Ok(await _customerGrp5ManagementService.AddGroup5(Group5));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteGroup5(short id)
        {
            return Ok(await _customerGrp5ManagementService.DeleteGroup5(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllGroup5()
        {
            return Ok(await _customerGrp5ManagementService.GetAllGroup5());
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetGroup5ById(short id)
        {
            return Ok(await _customerGrp5ManagementService.GetGroup5ById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateGroup5(UpdateGroup5Dto updatedGroup5)
        {
            return Ok(await _customerGrp5ManagementService.UpdateGroup5(updatedGroup5));
        }
    }
}