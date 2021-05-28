using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkOrderSourceController : Controller
    {
        private readonly IWorkOrderSourceManagementService _workOrderSourceManagementService;
        public WorkOrderSourceController(IWorkOrderSourceManagementService workOrderSourceManagementService)
        {
            _workOrderSourceManagementService = workOrderSourceManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllWorkOrderSource()
        {
            return Ok(await _workOrderSourceManagementService.GetAll());
        }
    }
}