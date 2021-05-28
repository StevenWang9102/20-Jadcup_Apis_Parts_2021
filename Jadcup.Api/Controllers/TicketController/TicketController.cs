using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Jadcup.Services.Interface.TicketService;
using Jadcup.Services.Model.Ticket;

namespace Jadcup.Api.Controllers.TicketController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly ITicketManagementService _iTicketManagementService;

        public TicketController(ITicketManagementService iTicketManagementService)
        {
            _iTicketManagementService = iTicketManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllTicketType()
        {
            return Ok(await _iTicketManagementService.GetAllTicketType());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetTicketByEmployeeId(ulong? closed, DateTime? start, DateTime? end, int employeeId)
        {
            return Ok(await _iTicketManagementService.GetByEmployeeId(closed, start, end, employeeId));
        }        

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllTicket(ulong? closed, DateTime? start, DateTime? end, string orderId)
        {
            return Ok(await _iTicketManagementService.GetAll(closed, start, end, orderId));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTicketById(string id)
        {
            return Ok(await _iTicketManagementService.GetById(id));
        }

        /// <summary>
        ///processId for ticket process is not required here
        /// </summary>
        [HttpPost("[action]")]
        public async Task<IActionResult> AddTicket(AddTicketDto request)
        {
            return Ok(await _iTicketManagementService.Add(request));
        }

        /// <summary>
        ///Input: if redelivery = 1, fill RedeliveryOrder field to generate redeliveryorder; else RedeliveryOrder field is not required
        /// </summary>
        [HttpPut("[action]")]
        public async Task<IActionResult> CloseTicket(UpdateTicketDto2 request)
        {
            return Ok(await _iTicketManagementService.Close(request));
        }

        /// <summary>
        ///Closed ticket and all other fields of a ticket cannot be updated. If required, delete/add new tickets to fix mannual errors. Ticket processes can be edited by its own controllers
        /// </summary>
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateTicket(UpdateTicketDto request)
        {
            return Ok(await _iTicketManagementService.Update(request));
        }

        /// <summary>
        ///Use with care. Closed ticket or ticket with returnitems cannot be deleted. All related ticket processes will be deleted.
        /// </summary>
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteTicket(string id)
        {
            return Ok(await _iTicketManagementService.Delete(id));
        }

    }
}
