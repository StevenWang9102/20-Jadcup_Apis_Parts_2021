using System.Threading.Tasks;
using Jadcup.Services.Interface.TicketProcessService;
using Jadcup.Services.Model.TicketProcessModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.TicketProcessController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketProcessController : Controller
    {
        private readonly ITicketProcessManagementService _ticketProcessManagementService;

        public TicketProcessController(ITicketProcessManagementService ticketProcessManagementService)
        {
            _ticketProcessManagementService = ticketProcessManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllTicketProcess(string ticketId, ulong? processed)
        {
            return Ok(await _ticketProcessManagementService.GetAll(ticketId, processed));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTicketProcessById(string id)
        {
            return Ok(await _ticketProcessManagementService.GetById(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddTicketProcess(AddTicketProcessDto request)
        {
            return Ok(await _ticketProcessManagementService.Add(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ProcessTicketProcess(UpdateTicketProcessDto request)
        {
            return Ok(await _ticketProcessManagementService.Process(request));
        }
        
        ///<summary>
        ///processed ticket process cannot be deleted. 
        ///</summary>
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteTicketProcess(string id)
        {
            return Ok(await _ticketProcessManagementService.Delete(id));
        }

    }
}