using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.RoleModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]

    public class RoleController : Controller
    {
        private readonly IRoleManagementService _roleManagementService;
        public RoleController(IRoleManagementService roleManagementService)
        {
            _roleManagementService = roleManagementService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddRole(AddRoleDto request)
        {
            return Ok(await _roleManagementService.Add(request));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteRole(short id)
        {
            return Ok(await _roleManagementService.Delete(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllRole()
        {
            return Ok(await _roleManagementService.GetAll());
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetRoleById(short id)
        {
            return Ok(await _roleManagementService.GetById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateRole(UpdateRoleDto request)
        {
            return Ok(await _roleManagementService.Update(request));
        }
    }
}