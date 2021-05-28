using System;
using System.Threading.Tasks;
using Jadcup.Services.Interface.ApplicationDetailsManagementService;
using Jadcup.Services.Model.ApplicationDetailsModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.ApplicationDetailsController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationDetailsController : Controller
    {
        private readonly IApplicationDetailsManagementService _applicationDetailsManagementService;
        public ApplicationDetailsController(IApplicationDetailsManagementService applicationDetailsManagementService)
        {
            _applicationDetailsManagementService = applicationDetailsManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllApplicationDetails(string applicationId, ulong? runout, DateTime? start, DateTime? end)
        {
            return Ok(await _applicationDetailsManagementService.GetAll(applicationId, runout, start, end));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetApplicationDetailsById(string id)
        {
            return Ok(await _applicationDetailsManagementService.GetById(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRemainingRawMaterialBoxByProductId(short productId)
        {
            return Ok(await _applicationDetailsManagementService.GetActiveRawMaterialBoxByProductId(productId));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddApplicationDetails(AddApplicationDetailsDto request)
        {
            return Ok(await _applicationDetailsManagementService.Add(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> MarkAsRunout(string id, ulong runout)
        {
            return Ok(await _applicationDetailsManagementService.MarkRunout(id, runout));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteApplicationDetails(string id)
        {
            return Ok(await _applicationDetailsManagementService.Delete(id));
        }
    }
}
