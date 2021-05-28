using System.Threading.Tasks;
using Jadcup.Services.Interface.RolePageService;
using Jadcup.Services.Model.RolePageModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.RolePageMappingController
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolePageMappingController : Controller
    {
        private readonly IRolePageService _rolePageService;
        public RolePageMappingController(IRolePageService rolePageService)
        {
            _rolePageService = rolePageService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllRolePageMapping()
        {
            return Ok(await _rolePageService.GetAll());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRolePageMappingById(short id)
        {
            return Ok(await _rolePageService.GetById(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetMappingByRoleId(short id)
        {
            return Ok(await _rolePageService.GetByRoleId(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPageByRoleId(short id)
        {
            return Ok(await _rolePageService.GetPageByRoleId(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddRolePageMapping(AddRolePageDto request)
        {
            return Ok(await _rolePageService.Add(request));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteRolePageMapping(short id)
        {
            return Ok(await _rolePageService.Delete(id));
        }
    }
}