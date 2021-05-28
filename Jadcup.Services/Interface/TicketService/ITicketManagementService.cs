using Jadcup.Common.Model;
using Jadcup.Services.Model.Ticket;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Jadcup.Services.Model.TicketTypeModel;

namespace Jadcup.Services.Interface.TicketService
{
    public interface ITicketManagementService
    {
        Task<TaskResponse<bool>> Add(AddTicketDto request);
        Task<TaskResponse<List<GetTicketDto>>> GetAll(ulong? closed, DateTime? start, DateTime? end, string orderId);
        Task<TaskResponse<List<GetTicketDto>>> GetByEmployeeId(ulong? closed, DateTime? start, DateTime? end, int EmployeeId);
        Task<TaskResponse<GetTicketDto>> GetById(string id);
        Task<TaskResponse<bool>> Update(UpdateTicketDto request);
        Task<TaskResponse<bool>> Close(UpdateTicketDto2 request);
        Task<TaskResponse<bool>> Delete(string id);
        Task<TaskResponse<List<GetTicketTypeDto>>> GetAllTicketType();
    }
}

