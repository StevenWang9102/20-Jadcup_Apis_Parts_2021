using System.Threading.Tasks;
using Jadcup.Services.Interface.SupplierRawMaterialService;
using Jadcup.Services.Model.SupplierRawMaterialModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SupplierRawMaterialController
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierRawMaterialController : Controller
    {
        private readonly ISupplierRawMaterialManagementService _supplierRawMaterialManagementService;
        public SupplierRawMaterialController(ISupplierRawMaterialManagementService supplierRawMaterialManagementService)
        {
            _supplierRawMaterialManagementService = supplierRawMaterialManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllSupplierRawMaterial(short? supplierId, short? rawMaterialId)
        {
            return Ok(await _supplierRawMaterialManagementService.GetAll(supplierId, rawMaterialId));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRawMaterialBySupplierId(short supplierId)
        {
            return Ok(await _supplierRawMaterialManagementService.GetRawMaterialBySupplierId(supplierId));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSupplierByRawMaterialId(short rawMaterialId)
        {
            return Ok(await _supplierRawMaterialManagementService.GetSupplierByRawMaterialId(rawMaterialId));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddSupplierRawMaterial(AddSupplierRawMaterialDto request)
        {
            return Ok(await _supplierRawMaterialManagementService.Add(request));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteSupplierRawMaterial(DeleteSupplierRawMaterialDto request)
        {
            return Ok(await _supplierRawMaterialManagementService.Delete(request));
        }
    }
}