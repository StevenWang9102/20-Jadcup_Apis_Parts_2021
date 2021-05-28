
using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface.CustomerGrpManagementService;
using Microsoft.AspNetCore.Mvc;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup1;

namespace Jadcup.Api.Controllers.SmallGroupController.CustomerGrpController
{

    [ApiController]
    [Route("api/[controller]")]

    public class CustomerGrp1Controller : Controller
    {
        private readonly ICustomerGrp1ManagementService _customerGrp1ManagementService;
        public CustomerGrp1Controller(ICustomerGrp1ManagementService customerGrp1ManagementService)
        {
            _customerGrp1ManagementService = customerGrp1ManagementService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddGroup1(AddGroup1Dto Group1)
        {
            return Ok(await _customerGrp1ManagementService.AddGroup1(Group1));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteGroup1(short id)
        {
            return Ok(await _customerGrp1ManagementService.DeleteGroup1(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllGroup1()
        {
            return Ok(await _customerGrp1ManagementService.GetAllGroup1());
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetGroup1ById(short id)
        {
            return Ok(await _customerGrp1ManagementService.GetGroup1ById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateGroup1(UpdateGroup1Dto updatedGroup1)
        {
            return Ok(await _customerGrp1ManagementService.UpdateGroup1(updatedGroup1));
        }
    }
}