using Jadcup.Services.Interface.SalesReportService;
using Jadcup.Services.Interface.SalesVisitService;
using Jadcup.Services.Model.SalesVistModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Jadcup.Api.Controllers.SalesReportController
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesReportController : Controller
    {
        private readonly ISalesReportService _service;
        public SalesReportController(ISalesReportService salesService)
        {
            _service = salesService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSalesReportByCustomer(int? id, bool? isInvoice, DateTime? startDateTime, DateTime? endDateTime)
        {
            return Ok(await _service.GetSalesReportByCustomer(id, isInvoice, startDateTime, endDateTime));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSalesReportByEmplyee(int id, bool? isInvoice, DateTime? startDateTime, DateTime? endDateTime)
        {
            return Ok(await _service.GetSalesReportByEmplyee(id, isInvoice, startDateTime, endDateTime));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetNoSalesReportOfCustomerInThreeMonth()
        {
            return Ok(await _service.GetNoSalesReportOfCustomerInThreeMonth());
        }

    }
}
