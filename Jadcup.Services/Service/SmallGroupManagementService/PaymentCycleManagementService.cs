using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.PaymentCycleModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class PaymentCycleManagementService : IPaymentCycleManagementService
    {
        private readonly ICrud<PaymentCycle, GetPaymentCycleDto, UpdatePaymentCycleDto> _crud;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<PaymentCycle> _paymentCycleRepo;

        public PaymentCycleManagementService(ICrud<PaymentCycle, GetPaymentCycleDto, UpdatePaymentCycleDto> crud, IMapper mapper, IGenericMySqlAccessRepository<PaymentCycle> genericMySqlAccessRepository)
        {
            _crud = crud;
            _mapper = mapper;
            _paymentCycleRepo = genericMySqlAccessRepository;
        }


        public async Task<TaskResponse<bool>> Add(AddPaymentCycleDto request)
        {
            PaymentCycle dbPaymentCycle = await _paymentCycleRepo.GetQueryable().FirstOrDefaultAsync(s => s.PaymentCycleName == request.PaymentCycleName);
            return await _crud.AddToTableAsync(dbPaymentCycle, request);
        }

        public async Task<TaskResponse<bool>> Delete(short id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }

        public async Task<TaskResponse<List<GetPaymentCycleDto>>> GetAll()
        {
            return await _crud.GetAll();
        }

        public async Task<TaskResponse<GetPaymentCycleDto>> GetById(short id)
        {
            return await _crud.GetById(id);
        }

        public async Task<TaskResponse<GetPaymentCycleDto>> Update(UpdatePaymentCycleDto request)
        {
            PaymentCycle dbPaymentCycle = await _paymentCycleRepo.GetAsync(request.PaymentCycleId);
            bool duplicated = (await _paymentCycleRepo.GetQueryable().AnyAsync(b => b.PaymentCycleName == request.PaymentCycleName)) && dbPaymentCycle.PaymentCycleName.ToUpper() != request.PaymentCycleName.ToUpper();

            return await _crud.UpdateEntry(dbPaymentCycle, request, duplicated);
        }
    }
}