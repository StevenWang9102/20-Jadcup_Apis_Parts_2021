using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.OrderService;
using Jadcup.Services.Interface.TicketService;
using Jadcup.Services.Model.ReturnItemModel;
using Jadcup.Services.Model.Ticket;
using Jadcup.Services.Model.TicketProcessModel;
using Jadcup.Services.Model.TicketTypeModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.TicketService
{
    public class TicketManagementService : ITicketManagementService
    {
        private readonly IGenericMySqlAccessRepository<Ticket> _ticketRepo;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<TicketProcess> _ticketProcessRepo;
        private readonly IOrderManagementService _orderManagementService;
        private readonly IGenericMySqlAccessRepository<Orders> _orderRepo;
        private readonly IGenericMySqlAccessRepository<CustomerCredit> _customerCreditRepo;
        private readonly IGenericMySqlAccessRepository<CreditTransaction> _creditTransactionRepo;
        private readonly IGenericMySqlAccessRepository<ReturnItem> _returnItemRepo;
        private readonly IGenericMySqlAccessRepository<TicketType> _ticketTypeRepo;

        public TicketManagementService(
            IGenericMySqlAccessRepository<Ticket> ticketRepo,
            IMapper mapper,
            IGenericMySqlAccessRepository<TicketProcess> ticketProcessRepo,
            IOrderManagementService orderManagementService,
            IGenericMySqlAccessRepository<Orders> orderRepo,
            IGenericMySqlAccessRepository<CustomerCredit> customerCreditRepo,
            IGenericMySqlAccessRepository<CreditTransaction> creditTransactionRepo,
            IGenericMySqlAccessRepository<ReturnItem> returnItemRepo,
            IGenericMySqlAccessRepository<TicketType> ticketTypeRepo)
        {
            _ticketProcessRepo = ticketProcessRepo;
            _orderManagementService = orderManagementService;
            _orderRepo = orderRepo;
            _customerCreditRepo = customerCreditRepo;
            _creditTransactionRepo = creditTransactionRepo;
            _returnItemRepo = returnItemRepo;
            _ticketTypeRepo = ticketTypeRepo;
            _mapper = mapper;
            _ticketRepo = ticketRepo;
        }
        public async Task<TaskResponse<bool>> Add(AddTicketDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Ticket ticket = _mapper.Map<Ticket>(request);
            ticket.CreatedAt = DateTime.UtcNow;
            ticket.Closed = 0;
            ticket.TicketId = Guid.NewGuid().ToString();

            _ticketRepo.Insert(ticket);

            TicketProcess ticketProcess = _mapper.Map<TicketProcess>(request.TicketProcess);
            ticketProcess.ProcessId = Guid.NewGuid().ToString();
            ticketProcess.TicketId = ticket.TicketId;
            ticketProcess.CreatedAt = DateTime.UtcNow;
            ticketProcess.Processed = 0;

            _ticketProcessRepo.Insert(ticketProcess);
            await _ticketRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> Close(UpdateTicketDto2 request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();


            using var transaction = _ticketRepo.GetContext().Database.BeginTransaction();
            try
            {
                Ticket ticket = await _ticketRepo.GetAsync(request.TicketId);
                if (ticket == null)
                {
                    throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
                }

                _mapper.Map(request, ticket);
                _ticketRepo.UpdateT(ticket);

                if (request.ReturnCredit != null)
                {
                    CustomerCredit customerCredit = await _customerCreditRepo.GetQueryable().FirstOrDefaultAsync(c => c.CustomerId == ticket.CustomerId);
                    if (customerCredit == null)
                    {
                        customerCredit = new CustomerCredit
                        {
                            CustomerId = ticket.CustomerId.Value,
                            Credit = 0,
                        };
                        _customerCreditRepo.Insert(customerCredit);
                        await _customerCreditRepo.SaveAsync();
                    }

                    CreditTransaction creditTransaction = new CreditTransaction
                    {
                        CreatedAt = DateTime.UtcNow,
                        TransactionId = Guid.NewGuid().ToString(),
                        Amount = ticket.ReturnCredit.Value,
                        TicketId = ticket.TicketId,
                        CustomerId = customerCredit.CustomerId,
                        Notes = "Ticket Return Credit."
                    };

                    _creditTransactionRepo.Insert(creditTransaction);

                    customerCredit.Credit += ticket.ReturnCredit.Value;
                    customerCredit.UpdatedAt = DateTime.UtcNow;
                    _customerCreditRepo.UpdateT(customerCredit);
                }

                if (request.Redelivery == 1)
                {
                    ticket.RedeliveryOrderId = await _orderManagementService.AddFullOrder(request.RedeliveryOrder,true);
                    Orders RedeliveryOrder = await _orderRepo.GetAsync(ticket.RedeliveryOrderId);
                    RedeliveryOrder.OrderSourceId = 3;

                    _orderRepo.UpdateT(RedeliveryOrder);
                    _ticketRepo.UpdateT(ticket);
                }

                await _ticketRepo.SaveAsync();
                transaction.Commit();
                response.Data = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage(ex.ToString()));
            }

            return response;
        }

        public async Task<TaskResponse<List<GetTicketDto>>> GetAll(ulong? closed, DateTime? start, DateTime? end, string orderId)
        {
            TaskResponse<List<GetTicketDto>> response = new TaskResponse<List<GetTicketDto>>();
            List<GetTicketDto> results = new List<GetTicketDto>();

            List<Ticket> tickets = await _ticketRepo.GetQueryable()
             .Where(t => closed == null || t.Closed == closed)
             .Where(t => start == null || t.CreatedAt >= start)
             .Where(t => end == null || t.CreatedAt <= end)
             .Where(t => orderId == null || t.OrderId == orderId)
             .Include(t => t.Customer)
             .Include(t => t.Employee)
             .Include(t => t.TicketTypeNavigation)
             .ToListAsync();

            foreach (Ticket ticket in tickets)
            {
                GetTicketDto dto = _mapper.Map<GetTicketDto>(ticket);

                List<ReturnItem> ReturnItems = await _returnItemRepo.GetQueryable().Where(r => r.TicketId == ticket.TicketId).ToListAsync();
                dto.ReturnItem = ReturnItems.Select(r => _mapper.Map<GetReturnItemDto>(r)).ToList();

                List<TicketProcess> processes = await _ticketProcessRepo.GetQueryable().Where(p => p.TicketId == ticket.TicketId).ToListAsync();
                dto.TicketProcess = processes.Select(p => _mapper.Map<GetTicketProcessDto>(p)).ToList();

                results.Add(dto);
            }

            response.Data = results;
            return response;
        }
        public async Task<TaskResponse<List<GetTicketDto>>> GetByEmployeeId(ulong? closed, DateTime? start, DateTime? end, int EmployeeId)
        {
            TaskResponse<List<GetTicketDto>> response = new TaskResponse<List<GetTicketDto>>();
            List<GetTicketDto> results = new List<GetTicketDto>();

            List<Ticket> tickets = await _ticketRepo.GetQueryable()
             .Where(t => closed == null || t.Closed == closed)
             .Where(t => start == null || t.CreatedAt >= start)
             .Where(t => end == null || t.CreatedAt <= end)
            //  .Where(t => orderId == null || t.OrderId == orderId)
             .Include(t => t.Customer)
             .Include(t => t.Employee)
             .Include(t => t.TicketTypeNavigation)
             .Where(t => t.TicketProcess.Where(tp => tp.AssignedEmployeeId ==EmployeeId).Count()>0)
             .ToListAsync();

            foreach (Ticket ticket in tickets)
            {
                GetTicketDto dto = _mapper.Map<GetTicketDto>(ticket);

                List<ReturnItem> ReturnItems = await _returnItemRepo.GetQueryable().Where(r => r.TicketId == ticket.TicketId).ToListAsync();
                dto.ReturnItem = ReturnItems.Select(r => _mapper.Map<GetReturnItemDto>(r)).ToList();

                List<TicketProcess> processes = await _ticketProcessRepo.GetQueryable().Where(p => p.TicketId == ticket.TicketId).ToListAsync();
                dto.TicketProcess = processes.Select(p => _mapper.Map<GetTicketProcessDto>(p)).ToList();

                dto.Awaiting = processes.FirstOrDefault(p =>p.AssignedEmployeeId == EmployeeId && p.Processed==0)!=null;
                results.Add(dto);
            }

            response.Data = results;
            return response;
        }
        public async Task<TaskResponse<bool>> Delete(string id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Ticket ticket = await _ticketRepo.GetAsync(id);
            if (ticket == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }
            if (ticket.Closed == 1)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage("Closed Ticket Cannot Be Deleted."));
            }

            using var transaction = _ticketRepo.GetContext().Database.BeginTransaction();
            try
            {
                List<TicketProcess> processes = await _ticketProcessRepo.GetQueryable().Where(p => p.TicketId == ticket.TicketId).ToListAsync();
                _ticketProcessRepo.DeleteRange(processes);
                await _ticketProcessRepo.SaveAsync();

                _ticketRepo.Delete(ticket);
                await _ticketRepo.SaveAsync();

                transaction.Commit();
                response.Data = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage(ex.ToString()));
            }

            return response;
        }

        public async Task<TaskResponse<GetTicketDto>> GetById(string id)
        {
            TaskResponse<GetTicketDto> response = new TaskResponse<GetTicketDto>();

            Ticket ticket = await _ticketRepo.GetQueryable()
            .Include(t => t.Customer)
            .Include(t => t.Employee)
            .Include(t => t.TicketTypeNavigation)
            .FirstOrDefaultAsync(t => t.TicketId == id);

            if (ticket == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            GetTicketDto dto = _mapper.Map<GetTicketDto>(ticket);

            List<ReturnItem> ReturnItems = await _returnItemRepo.GetQueryable().Where(r => r.TicketId == ticket.TicketId).ToListAsync();
            dto.ReturnItem = ReturnItems.Select(r => _mapper.Map<GetReturnItemDto>(r)).ToList();

            List<TicketProcess> processes = await _ticketProcessRepo.GetQueryable().Where(p => p.TicketId == ticket.TicketId).ToListAsync();
            dto.TicketProcess = processes.Select(p => _mapper.Map<GetTicketProcessDto>(p)).ToList();

            response.Data = dto;
            return response;
        }

        public async Task<TaskResponse<bool>> Update(UpdateTicketDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Ticket ticket = await _ticketRepo.GetAsync(request.TicketId);
            if (ticket == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _mapper.Map(request, ticket);
            _ticketRepo.UpdateT(ticket);
            await _ticketRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetTicketTypeDto>>> GetAllTicketType()
        {
            TaskResponse<List<GetTicketTypeDto>> response = new TaskResponse<List<GetTicketTypeDto>>();

            List<TicketType> types = await _ticketTypeRepo.GetAllAsync();

            response.Data = types.Select(t => _mapper.Map<GetTicketTypeDto>(t)).ToList();
            return response;
        }
    }
}