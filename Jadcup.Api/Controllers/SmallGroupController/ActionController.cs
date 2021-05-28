using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActionController : Controller
    {
        private readonly IActionManagementService _actionManagementService;
        public ActionController(IActionManagementService actionManagementService)
        {
            _actionManagementService = actionManagementService;

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAction()
        {
            return Ok(await _actionManagementService.GetAll());
        }
    }
}