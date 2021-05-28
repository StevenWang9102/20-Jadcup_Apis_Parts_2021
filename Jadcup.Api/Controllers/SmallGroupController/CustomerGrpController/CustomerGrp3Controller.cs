using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface.CustomerGrpManagementService;
using Microsoft.AspNetCore.Mvc;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup3;

namespace Jadcup.Api.Controllers.SmallGroupController.CustomerGrpController
{

    [ApiController]
    [Route("api/[controller]")]

    public class CustomerGrp3Controller : Controller
    {
        private readonly ICustomerGrp3ManagementService _customerGrp3ManagementService;
        public CustomerGrp3Controller(ICustomerGrp3ManagementService customerGrp3ManagementService)
        {
            _customerGrp3ManagementService = customerGrp3ManagementService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddGroup3(AddGroup3Dto Group3)
        {
            return Ok(await _customerGrp3ManagementService.AddGroup3(Group3));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteGroup3(short id)
        {
            return Ok(await _customerGrp3ManagementService.DeleteGroup3(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllGroup3()
        {
            return Ok(await _customerGrp3ManagementService.GetAllGroup3());
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetGroup3ById(short id)
        {
            return Ok(await _customerGrp3ManagementService.GetGroup3ById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateGroup3(UpdateGroup3Dto updatedGroup3)
        {
            return Ok(await _customerGrp3ManagementService.UpdateGroup3(updatedGroup3));
        }
    }
}