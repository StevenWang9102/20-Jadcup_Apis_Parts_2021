using System.Threading.Tasks;
using Jadcup.Services.Interface.WorkOrderStockService;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.StockMonitorController
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockMonitorController : Controller
    {
        private readonly IWorkOrderStockManagementService _workOrderStockManagementService;
        public StockMonitorController(IWorkOrderStockManagementService workOrderStockManagementService)
        {
            _workOrderStockManagementService = workOrderStockManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllStockInfo(bool? low)
        {
            return Ok(await _workOrderStockManagementService.GetAll(low));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetStockInfoByProductId(short productId)
        {
            return Ok(await _workOrderStockManagementService.GetByProductId(productId));
        }
    }
}