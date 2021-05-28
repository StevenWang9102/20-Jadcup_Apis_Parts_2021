using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SalesVisitService;
using System;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.SalesVistModel;
using Jadcup.Common.Context;
using Microsoft.EntityFrameworkCore;
using Jadcup.Common.Error;


namespace Jadcup.Services.Service.SalesVisitService
{
    public class SalesVisitService : ISalesVisitService
    {
        private readonly IGenericMySqlAccessRepository<SalesVisitPlan> _salesVisitRepo;
        private readonly IMapper _mapper;
        public SalesVisitService(IGenericMySqlAccessRepository<SalesVisitPlan> salesRepo, IMapper mapper)
        {
            _mapper = mapper;
            _salesVisitRepo = salesRepo;
        }

        public async Task<TaskResponse<short>> Add(AddSaleVistDto request)
        {
            TaskResponse<short> response = new TaskResponse<short>();

            Guid id = Guid.NewGuid();
            var stringID = id.ToString();

            request.PlanId = stringID;

            SalesVisitPlan newVisit = _mapper.Map<SalesVisitPlan>(request);

            _salesVisitRepo.Insert(newVisit);
            await _salesVisitRepo.SaveAsync();

            return response;
        }

        public async Task<TaskResponse<List<GetSalesVisitDto>>> GetAll()
        {
            TaskResponse<List<GetSalesVisitDto>> response = new TaskResponse<List<GetSalesVisitDto>>();
            
            List<SalesVisitPlan> salesVisits = await _salesVisitRepo.GetQueryable()
                .Include(c => c.Employee)
                .Include(c => c.Customer)
                .ToListAsync();

            response.Data = salesVisits.Select(c => _mapper.Map<GetSalesVisitDto>(c)).ToList();
            return response;
        }

        public async Task<TaskResponse<GetSalesVisitDto>> GetById(string id)
        {
            TaskResponse<GetSalesVisitDto> response = new TaskResponse<GetSalesVisitDto>();

            SalesVisitPlan salesVisit = await _salesVisitRepo.GetQueryable()
                .Include(c => c.Employee)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(c => c.PlanId == id);

            response.Data = _mapper.Map<GetSalesVisitDto>(salesVisit);
            return response;
        }


        public async Task<TaskResponse<bool>> Update(UpdateSalesVisit request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            SalesVisitPlan targetVisit = await _salesVisitRepo.GetAsync(request.PlanId);

            _mapper.Map(request, targetVisit);
            _salesVisitRepo.UpdateT(targetVisit);

            await _salesVisitRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> Delete(string id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            SalesVisitPlan targetVisit = await _salesVisitRepo.GetAsync(id);

            if (targetVisit == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }
            
            _salesVisitRepo.Delete(targetVisit);
            await _salesVisitRepo.SaveAsync();

            response.Data = true;
            return response;
        }
    }
}
