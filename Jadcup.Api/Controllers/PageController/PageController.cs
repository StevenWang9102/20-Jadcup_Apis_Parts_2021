using System.Threading.Tasks;
using Jadcup.Services.Interface.IPageService;
using Jadcup.Services.Model.PageModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.PageController
{
    [ApiController]
    [Route("api/[controller]")]
    public class PageController : Controller
    {
        private readonly IPageManagementService _pageManagementService;
        public PageController(IPageManagementService pageManagementService)
        {
            _pageManagementService = pageManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPage()
        {
            return Ok(await _pageManagementService.GetAll());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPageById(short id)
        {
            return Ok(await _pageManagementService.GetById(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddPage(AddPageDto request)
        {
            return Ok(await _pageManagementService.Add(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePage(UpdatePageDto request)
        {
            return Ok(await _pageManagementService.Update(request));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePage(short id)
        {
            return Ok(await _pageManagementService.Delete(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPagesByPageGroupId(short id)
        {
            return Ok(await _pageManagementService.GetByGroup(id));
        }
    }
}