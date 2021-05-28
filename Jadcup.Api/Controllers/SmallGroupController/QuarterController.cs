using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.HumanResource.Quarter;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]

    public class QuarterController : Controller
    {
        private readonly IQuarterManagementService _quarterManagementService;
        public QuarterController(IQuarterManagementService quarterManagementService)
        {
            _quarterManagementService = quarterManagementService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddQuarter(AddQuarterDto request)
        {
            return Ok(await _quarterManagementService.Add(request));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteQuarter(short id)
        {
            return Ok(await _quarterManagementService.Delete(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllQuarter()
        {
            return Ok(await _quarterManagementService.GetAll());
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetQuarterById(short id)
        {
            return Ok(await _quarterManagementService.GetById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateQuarter(UpdateQuarterDto request)
        {
            return Ok(await _quarterManagementService.Update(request));
        }
    }
}