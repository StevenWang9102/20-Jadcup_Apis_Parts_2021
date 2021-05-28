using System.Threading.Tasks;
using Jadcup.Services.Interface.AssessmentService;
using Jadcup.Services.Interface.CellService;
using Jadcup.Services.Model.AssessmentModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.AssessmentController
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssessmentController : Controller
    {
        private readonly IAssessmentService _assessmentService;
        public AssessmentController(IAssessmentService assessmentService)
        {
            _assessmentService = assessmentService;
        }

        // ---------------------------------- Standard ------------------------------
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAssessmentStandard()
        {
            return Ok(await _assessmentService.GetAllAssessmentStandard());
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddAssessmentStandard(AddStandardDto request)
        {
            return Ok(await _assessmentService.AddAssessmentStandard(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAssessmentStandard(UpdateStandardDto request)
        {
            return Ok(await _assessmentService.Update(request));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteAssessmentStandard(string id)
        {
            return Ok(await _assessmentService.DeleteAssessmentStandard(id));
        }

        // ----------------------------- Standard Details ------------------------------
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAssessmentStandardDetails()
        {
            return Ok(await _assessmentService.GetAllAssessmentStandardDetails());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddAssessmentStandardDetails(AddStandardDetailsDto request)
        {
            return Ok(await _assessmentService.AddAssessmentStandardDetails(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAssessmentStandardDetails(UpdateStandardDetailsDto request)
        {
            return Ok(await _assessmentService.UpdateAssessmentStandardDetails(request));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteAssessmentStandardDetails(string id)
        {
            return Ok(await _assessmentService.DeleteAssessmentStandardDetails(id));
        }

        // ----------------------------- Assessment Plan ------------------------------
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAssessmentPlan()
        {
            return Ok(await _assessmentService.GetAllAssessmentPlan());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddAssessmentPlan(AddAssessmentPlanDto request)
        {
            return Ok(await _assessmentService.AddAssessmentPlan(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAssessmentPlan(UpdateAssessmentPlanDto request)
        {
            return Ok(await _assessmentService.UpdateAssessmentPlan(request));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteAssessmentPlan(string id)
        {
            return Ok(await _assessmentService.DeleteAssessmentPlan(id));
        }

        // ----------------------------- Assessment ------------------------------

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOneAssessment(string? id)
        {
            return Ok(await _assessmentService.GetOneAssessment(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddOneAssessment(AddOneAssessmentDto request)
        {
            return Ok(await _assessmentService.AddOneAssessment(request));
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateOneAssessment(UpdateOneAssessmentDto request)
        {
            return Ok(await _assessmentService.UpdateOneAssessment(request));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteOneAssessment(string id)
        {
            return Ok(await _assessmentService.DeleteOneAssessment(id));
        }

        // ----------------------------- Assessment Details ------------------------------

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAssessmentDetails()
        {
            return Ok(await _assessmentService.GetAssessmentDetails());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddAssessmentDetails(AddAssessmentDetailsDto request)
        {
            return Ok(await _assessmentService.AddAssessmentDetails(request));
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAssessmentDetails(UpdateAssessmentDetailDto request)
        {
            return Ok(await _assessmentService.UpdateAssessmentDetails(request));
        }

        
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteOneAssessmentDetails(string id)
        {
            return Ok(await _assessmentService.DeleteOneAssessmentDetails(id));
        }
    }
}