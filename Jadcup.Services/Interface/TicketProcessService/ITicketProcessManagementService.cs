using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.TicketProcessModel;

namespace Jadcup.Services.Interface.TicketProcessService
{
    public interface ITicketProcessManagementService
    {
        Task<TaskResponse<List<GetTicketProcessDto>>> GetAll(string ticketId, ulong? processed);
        Task<TaskResponse<GetTicketProcessDto>> GetById(string id);
        Task<TaskResponse<string>> Add(AddTicketProcessDto request);
        Task<TaskResponse<bool>> Process(UpdateTicketProcessDto request);
        Task<TaskResponse<bool>> Delete(string id);
    }
}