using Jadcup.Services.Interface.SalesVisitService;
using Jadcup.Services.Model.SalesVistModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jadcup.Api.Controllers.SalesVisitController
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesVisitController : Controller
    {
        private readonly ISalesVisitService _salesVisitService;
        public SalesVisitController(ISalesVisitService salesVisitService)
        {
            _salesVisitService = salesVisitService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllSalesVisit()
        {
            return Ok(await _salesVisitService.GetAll());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSalesVisitId(string id)
        {
            return Ok(await _salesVisitService.GetById(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddSaleVisit(AddSaleVistDto request)
        {
            return Ok(await _salesVisitService.Add(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateSalesVisit(UpdateSalesVisit request)
        {
            return Ok(await _salesVisitService.Update(request));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteSaleVisit(string id)
        {
            return Ok(await _salesVisitService.Delete(id));
        }
    }
}
