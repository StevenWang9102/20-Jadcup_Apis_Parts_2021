using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Services.Interface.SupplierService;
using Jadcup.Services.Model.QualificationModel;
using Jadcup.Services.Model.SupplierModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SupplierController
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : Controller
    {
        private readonly ISupplierManagementService _supplierManagementService;
        public SupplierController(ISupplierManagementService supplierManagementService)
        {
            _supplierManagementService = supplierManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllSupplier(ulong? active)
        {
            return Ok(await _supplierManagementService.GetAll(active));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSupplierById(short id)
        {
            return Ok(await _supplierManagementService.GetById(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddSupplier(AddSupplierDto request)
        {
            return Ok(await _supplierManagementService.Add(request));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddSupplierAndQualifications(AddSupplierDto2 request)
        {
            return Ok(await _supplierManagementService.AddFull(request));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddQualification(List<AddQualificationDto> request)
        {
            return Ok(await _supplierManagementService.AddQualification(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateSupplier(UpdateSupplierDto request)
        {
            return Ok(await _supplierManagementService.Update(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateQualification(UpdateQualificationDto request)
        {
            return Ok(await _supplierManagementService.UpdateQualification(request));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteSupplier(short id)
        {
            return Ok(await _supplierManagementService.Delete(id));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteQualification(short id)
        {
            return Ok(await _supplierManagementService.DeleteQualification(id));
        }
    }
}