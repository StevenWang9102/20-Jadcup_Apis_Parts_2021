using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]

    public class DispatchingStatusController : Controller
    {
        private readonly IDispatchingStatusManagementService _dispatchingStatusManagementService;
        public DispatchingStatusController(IDispatchingStatusManagementService dispatchingStatusManagementService)
        {
            _dispatchingStatusManagementService = dispatchingStatusManagementService;

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllDispatchingStatus()
        {
            return Ok(await _dispatchingStatusManagementService.GetAll());
        }
    }
}