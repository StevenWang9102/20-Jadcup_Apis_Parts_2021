using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.CourierModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class CourierManagementService : ICourierManagementService
    {
        private readonly ICrud<Courier, GetCourierDto, UpdateCourierDto> _crud;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<Courier> _courierRepo;

        public CourierManagementService(ICrud<Courier, GetCourierDto, UpdateCourierDto> crud, IMapper mapper, IGenericMySqlAccessRepository<Courier> genericMySqlAccessRepository)
        {
            _crud = crud;
            _mapper = mapper;
            _courierRepo = genericMySqlAccessRepository;
        }
        public async Task<TaskResponse<bool>> Add(AddCourierDto request)
        {
            Courier dbCourier = await _courierRepo.GetQueryable().FirstOrDefaultAsync(s => s.CourierName == request.CourierName);
            return await _crud.AddToTableAsync(dbCourier, request);
        }

        public async Task<TaskResponse<bool>> Delete(sbyte id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }

        public async Task<TaskResponse<List<GetCourierDto>>> GetAll()
        {
            return await _crud.GetAll();
        }

        public async Task<TaskResponse<GetCourierDto>> GetById(sbyte id)
        {
            return await _crud.GetById(id);
        }

        public async Task<TaskResponse<GetCourierDto>> Update(UpdateCourierDto request)
        {
            Courier dbCourier = await _courierRepo.GetAsync(request.CourierId);
            bool duplicated = (await _courierRepo.GetQueryable().AnyAsync(b => b.CourierName == request.CourierName)) && dbCourier.CourierName.ToUpper() != request.CourierName.ToUpper();

            return await _crud.UpdateEntry(dbCourier, request, duplicated);
        }
    }
}