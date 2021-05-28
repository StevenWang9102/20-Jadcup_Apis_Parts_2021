using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface.CustomerGrpManagementService;
using Microsoft.AspNetCore.Mvc;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup2;

namespace Jadcup.Api.Controllers.SmallGroupController.CustomerGrpController
{

    [ApiController]
    [Route("api/[controller]")]

    public class CustomerGrp2Controller : Controller
    {
        private readonly ICustomerGrp2ManagementService _customerGrp2ManagementService;
        public CustomerGrp2Controller(ICustomerGrp2ManagementService customerGrp2ManagementService)
        {
            _customerGrp2ManagementService = customerGrp2ManagementService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddGroup2(AddGroup2Dto Group2)
        {
            return Ok(await _customerGrp2ManagementService.AddGroup2(Group2));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteGroup2(short id)
        {
            return Ok(await _customerGrp2ManagementService.DeleteGroup2(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllGroup2()
        {
            return Ok(await _customerGrp2ManagementService.GetAllGroup2());
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetGroup2ById(short id)
        {
            return Ok(await _customerGrp2ManagementService.GetGroup2ById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateGroup2(UpdateGroup2Dto updatedGroup2)
        {
            return Ok(await _customerGrp2ManagementService.UpdateGroup2(updatedGroup2));
        }
    }
}