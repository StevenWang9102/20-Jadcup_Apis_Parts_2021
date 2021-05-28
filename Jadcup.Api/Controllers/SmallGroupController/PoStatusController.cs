using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]

    public class PoStatusController : Controller
    {
        private readonly IPoStatusManagementService _poStatusManagementService;
        public PoStatusController(IPoStatusManagementService poStatusManagementService)
        {
            _poStatusManagementService = poStatusManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPoStatus()
        {
            return Ok(await _poStatusManagementService.GetAll());
        }
    }
}