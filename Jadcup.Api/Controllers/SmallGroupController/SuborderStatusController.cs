using System.Threading.Tasks;
using Jadcup.Services.Interface.SuborderStatusService;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuborderStatusController : Controller
    {
        private readonly ISuborderStatusManagementService _suborderStatusManagementService;
        public SuborderStatusController(ISuborderStatusManagementService suborderStatusManagementService)
        {
            _suborderStatusManagementService = suborderStatusManagementService;

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllSuborderStatus()
        {
            return Ok(await _suborderStatusManagementService.GetAll());
        }
    }
}