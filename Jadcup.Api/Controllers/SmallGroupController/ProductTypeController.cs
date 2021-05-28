using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.ProductTypeModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeManagementService _productTypeManagementService;

        public ProductTypeController(IProductTypeManagementService productTypeManagementService)
        {
            _productTypeManagementService = productTypeManagementService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddProductType(AddProductTypeDto request)
        {
            return Ok(await _productTypeManagementService.Add(request));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteProductType(short id)
        {
            return Ok(await _productTypeManagementService.Delete(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProductType()
        {
            return Ok(await _productTypeManagementService.GetAll());
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetProductTypeById(short id)
        {
            return Ok(await _productTypeManagementService.GetById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProductType(UpdateProductTypeDto request)
        {
            return Ok(await _productTypeManagementService.Update(request));
        }
    }
}