using System.Threading.Tasks;
using Jadcup.Services.Interface.PageGroupService;
using Jadcup.Services.Model.PageGroupModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.PageGroupGroupController
{
    [ApiController]
    [Route("api/[controller]")]

    public class PageGroupController : Controller
    {
        private readonly IPageGroupManagementService _pageGroupManagementService;
        public PageGroupController(IPageGroupManagementService pageGroupManagementService)
        {
            _pageGroupManagementService = pageGroupManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPageGroup()
        {
            return Ok(await _pageGroupManagementService.GetAll());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPageGroupById(short id)
        {
            return Ok(await _pageGroupManagementService.GetById(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddPageGroup(AddPageGroupDto request)
        {
            return Ok(await _pageGroupManagementService.Add(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePageGroup(UpdatePageGroupDto request)
        {
            return Ok(await _pageGroupManagementService.Update(request));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePageGroup(short id)
        {
            return Ok(await _pageGroupManagementService.Delete(id));
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetPageByGroupId(short id)
        {
            return Ok(await _pageGroupManagementService.GetPageByGroupId(id));
        }
    }
}