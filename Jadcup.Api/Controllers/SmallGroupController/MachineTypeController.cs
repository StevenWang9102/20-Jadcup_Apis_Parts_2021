using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.MachineTypeModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]
    public class MachineTypeController : Controller
    {
        private readonly IMachineTypeManagementService _machineTypeManagementService;

        public MachineTypeController(IMachineTypeManagementService machineTypeManagementService)
        {
            _machineTypeManagementService = machineTypeManagementService;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllMachineType()
        {
            return Ok(await _machineTypeManagementService.GetAll());
        }


    }
}