using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.TicketProcessService;
using Jadcup.Services.Model.TicketProcessModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.TicketProcessService
{
    public class TicketProcessManagementService : ITicketProcessManagementService
    {
        private readonly IGenericMySqlAccessRepository<TicketProcess> _ticketProcessRepo;
        private readonly IMapper _mapper;

        public TicketProcessManagementService(IGenericMySqlAccessRepository<TicketProcess> ticketProcessRepo, IMapper mapper)
        {
            _ticketProcessRepo = ticketProcessRepo;
            _mapper = mapper;
        }
        public async Task<TaskResponse<string>> Add(AddTicketProcessDto request)
        {
            TaskResponse<string> response = new TaskResponse<string>();

            TicketProcess process = _mapper.Map<TicketProcess>(request);
            process.ProcessId = Guid.NewGuid().ToString();
            process.CreatedAt = DateTime.UtcNow;
            process.Processed = 0;

            _ticketProcessRepo.Insert(process);
            await _ticketProcessRepo.SaveAsync();

            response.Data = process.ProcessId;
            return response;
        }

        public async Task<TaskResponse<bool>> Delete(string id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            TicketProcess process = await _ticketProcessRepo.GetAsync(id);
            if (process == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }
            if (process.Processed == 1)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage("Processed TicketProcess Cannot be Deleted."));
            }

            _ticketProcessRepo.Delete(process);
            await _ticketProcessRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetTicketProcessDto>>> GetAll(string ticketId, ulong? processed)
        {
            TaskResponse<List<GetTicketProcessDto>> response = new TaskResponse<List<GetTicketProcessDto>>();

            List<TicketProcess> processes = await _ticketProcessRepo.GetQueryable()
                .Where(p => ticketId == null || p.TicketId == ticketId)
                .Where(p => p.Processed == processed || processed == null)
                .Include(p => p.AssignedEmployee)
                .ToListAsync();

            response.Data = processes.Select(p => _mapper.Map<GetTicketProcessDto>(p)).ToList();
            return response;
        }

        public async Task<TaskResponse<GetTicketProcessDto>> GetById(string id)
        {
            TaskResponse<GetTicketProcessDto> response = new TaskResponse<GetTicketProcessDto>();

            TicketProcess process = await _ticketProcessRepo.GetAsync(id);
            if (process == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            response.Data = _mapper.Map<GetTicketProcessDto>(process);
            return response;
        }

        public async Task<TaskResponse<bool>> Process(UpdateTicketProcessDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            TicketProcess process = await _ticketProcessRepo.GetAsync(request.ProcessId);
            if (process == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _mapper.Map(request, process);
            process.CompletedAt = DateTime.UtcNow;

            _ticketProcessRepo.UpdateT(process);
            await _ticketProcessRepo.SaveAsync();

            response.Data = true;
            return response;
        }
    }
}