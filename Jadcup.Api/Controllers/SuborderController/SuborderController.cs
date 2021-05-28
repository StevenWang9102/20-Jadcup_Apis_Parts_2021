using System;
using System.Threading.Tasks;
using Jadcup.Services.Interface.SuborderService;
using Jadcup.Services.Model.SuborderLogModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.SuborderController
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuborderController : Controller
    {
        private readonly ISuborderManagementService _suborderManagementService;
        public SuborderController(ISuborderManagementService suborderManagementService)
        {
            _suborderManagementService = suborderManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllSuborder(sbyte? statusId, DateTime? start, DateTime? end)
        {
            return Ok(await _suborderManagementService.GetAll(statusId, start, end));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSuborderById(string id)
        {
            return Ok(await _suborderManagementService.GetById(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSuborderByMachineId(short id, DateTime? completeDate)
        {
            return Ok(await _suborderManagementService.GetByMachineId(id, completeDate,false));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSuborderByMachineId1(short id, DateTime? completeDate)
        {
            return Ok(await _suborderManagementService.GetByMachineId1(id, completeDate,false));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSuborderByDate( DateTime? completeDate)
        {
            return Ok(await _suborderManagementService.GetByDate( completeDate));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSuborderByDate2( DateTime? completeDate)
        {
            return Ok(await _suborderManagementService.GetByDate2( completeDate));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSuborderByDate3( DateTime? completeDate)
        {
            return Ok(await _suborderManagementService.GetByDate2( completeDate));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSuborderByWorkOrderId(string id)
        {
            return Ok(await _suborderManagementService.GetByWorkOrderId(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSuborderLog(string suborderId, int? operEmployeeId, string rawMaterialBoxId, short? machineId)
        {
            return Ok(await _suborderManagementService.GetSuborderLog(suborderId, operEmployeeId, rawMaterialBoxId, machineId));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> TakeSuborder(string id, AddSuborderLogDto request)
        {
            return Ok(await _suborderManagementService.TakeOrder(id, request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> PauseSuborder(string id)
        {
            return Ok(await _suborderManagementService.Pause(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UnpauseSuborder(string id)
        {
            return Ok(await _suborderManagementService.Unpause(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> FinishSuborder(string id, AddSuborderLogDto request)
        {
            return Ok(await _suborderManagementService.Finish(id, request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> PartlyCompleteSuborder(string id, AddSuborderLogDto request)
        {
            return Ok(await _suborderManagementService.PartlyFinish(id, request));
        }
    }
}