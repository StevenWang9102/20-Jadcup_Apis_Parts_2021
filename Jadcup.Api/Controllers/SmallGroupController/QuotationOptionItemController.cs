using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.QuotationOptionItemModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotationOptionItemController : Controller
    {
        private readonly IQuotationOptionItemManagementService _quotationOptionItemManagementService;

        public QuotationOptionItemController(IQuotationOptionItemManagementService quotationOptionItemManagementService)
        {
            _quotationOptionItemManagementService = quotationOptionItemManagementService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddQuotationOptionItem(AddQuotationOptionItemDto request)
        {
            return Ok(await _quotationOptionItemManagementService.Add(request));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteQuotationOptionItem(int id)
        {
            return Ok(await _quotationOptionItemManagementService.Delete(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllQuotationOptionItem()
        {
            return Ok(await _quotationOptionItemManagementService.GetAll());
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetQuotationOptionItemById(int id)
        {
            return Ok(await _quotationOptionItemManagementService.GetById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateQuotationOptionItem(UpdateQuotationOptionItemDto request)
        {
            return Ok(await _quotationOptionItemManagementService.Update(request));
        }
    }
}