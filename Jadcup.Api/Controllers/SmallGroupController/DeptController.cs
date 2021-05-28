using System.Threading.Tasks;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.DepartmentModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SmallGroupController
{
    [ApiController]
    [Route("api/[controller]")]

    public class DeptController : Controller
    {
        private readonly IDeptManagementService _deptManagementService;
        public DeptController(IDeptManagementService deptManagementService)
        {
            _deptManagementService = deptManagementService;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddDepartment(AddDepartmentDto request)
        {
            return Ok(await _deptManagementService.Add(request));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteDepartment(short id)
        {
            return Ok(await _deptManagementService.Delete(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllDepartment()
        {
            return Ok(await _deptManagementService.GetAll());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllDepartmentWithStandard()
        {
            return Ok(await _deptManagementService.GetAllDepartmentWithStandard());
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetDepartmentById(short id)
        {
            return Ok(await _deptManagementService.GetById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentDto request)
        {
            return Ok(await _deptManagementService.Update(request));
        }
    }
}