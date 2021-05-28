using System.Threading.Tasks;
using Jadcup.Services.Interface.ShelfService;
using Jadcup.Services.Model.ShelfModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.ShelfController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShelfController : Controller
    {
        private readonly IShelfManagementService _shelfManagementService;
        public ShelfController(IShelfManagementService shelfManagementService)
        {
            _shelfManagementService = shelfManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllShelf()
        {
            return Ok(await _shelfManagementService.GetAll());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetShelfByCodeOrById(short? shelfId, string code)
        {
            return Ok(await _shelfManagementService.GetSingle(shelfId, code));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddShelf(AddShelfDto request)
        {
            return Ok(await _shelfManagementService.Add(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateShelf(UpdateShelfDto request)
        {
            return Ok(await _shelfManagementService.Update(request));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteShelf(short id)
        {
            return Ok(await _shelfManagementService.Delete(id));
        }
    }
}