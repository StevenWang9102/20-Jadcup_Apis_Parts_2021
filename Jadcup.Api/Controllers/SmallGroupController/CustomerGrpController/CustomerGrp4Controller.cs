using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface.CustomerGrpManagementService;
using Microsoft.AspNetCore.Mvc;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup4;

namespace Jadcup.Api.Controllers.SmallGroupController.CustomerGrpController
{

    [ApiController]
    [Route("api/[controller]")]

    public class CustomerGrp4Controller : Controller
    {
        private readonly ICustomerGrp4ManagementService _customerGrp4ManagementService;
        public CustomerGrp4Controller(ICustomerGrp4ManagementService customerGrp4ManagementService)
        {
            _customerGrp4ManagementService = customerGrp4ManagementService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddGroup4(AddGroup4Dto Group4)
        {
            return Ok(await _customerGrp4ManagementService.AddGroup4(Group4));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteGroup4(short id)
        {
            return Ok(await _customerGrp4ManagementService.DeleteGroup4(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllGroup4()
        {
            return Ok(await _customerGrp4ManagementService.GetAllGroup4());
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetGroup4ById(short id)
        {
            return Ok(await _customerGrp4ManagementService.GetGroup4ById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateGroup4(UpdateGroup4Dto updatedGroup4)
        {
            return Ok(await _customerGrp4ManagementService.UpdateGroup4(updatedGroup4));
        }
    }
}