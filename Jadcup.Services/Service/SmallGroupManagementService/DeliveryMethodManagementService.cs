using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.DeliveryMethodModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class DeliveryMethodManagementService : IDeliveryMethodManagementService
    {
        private readonly ICrud<DeliveryMethod, GetDeliveryMethodDto, UpdateDeliveryMethodDto> _crud;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<DeliveryMethod> _deliveryMethodRepo;

        public DeliveryMethodManagementService(ICrud<DeliveryMethod, GetDeliveryMethodDto, UpdateDeliveryMethodDto> crud, IMapper mapper, IGenericMySqlAccessRepository<DeliveryMethod> genericMySqlAccessRepository)
        {
            _crud = crud;
            _mapper = mapper;
            _deliveryMethodRepo = genericMySqlAccessRepository;
        }
        public async Task<TaskResponse<bool>> Add(AddDeliveryMethodDto request)
        {
            DeliveryMethod dbDeliveryMethod = await _deliveryMethodRepo.GetQueryable().FirstOrDefaultAsync(s => s.DeliveryMethodName == request.DeliveryMethodName);
            return await _crud.AddToTableAsync(dbDeliveryMethod, request);
        }

        public async Task<TaskResponse<bool>> Delete(short id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }

        public async Task<TaskResponse<List<GetDeliveryMethodDto>>> GetAll()
        {
            return await _crud.GetAll();
        }

        public async Task<TaskResponse<GetDeliveryMethodDto>> GetById(short id)
        {
            return await _crud.GetById(id);
        }

        public async Task<TaskResponse<GetDeliveryMethodDto>> Update(UpdateDeliveryMethodDto request)
        {
            DeliveryMethod dbDeliveryMethod = await _deliveryMethodRepo.GetAsync(request.DeliveryMethodId);
            bool duplicated = (await _deliveryMethodRepo.GetQueryable().AnyAsync(b => b.DeliveryMethodName == request.DeliveryMethodName)) && dbDeliveryMethod.DeliveryMethodName.ToUpper() != request.DeliveryMethodName.ToUpper();

            return await _crud.UpdateEntry(dbDeliveryMethod, request, duplicated);
        }
    }
}