using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.HumanResource.Quarter;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class QuarterManagementService : IQuarterManagementService
    {
        private readonly ICrud<Quarter, GetQuarterDto, UpdateQuarterDto> _crud;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<Quarter> _quarterRepo;

        public QuarterManagementService(ICrud<Quarter, GetQuarterDto, UpdateQuarterDto> crud, IMapper mapper, IGenericMySqlAccessRepository<Quarter> genericMySqlAccessRepository)
        {
            _crud = crud;
            _mapper = mapper;
            _quarterRepo = genericMySqlAccessRepository;
        }
        public async Task<TaskResponse<bool>> Add(AddQuarterDto request)
        {
            Quarter dbQuarter = await _quarterRepo.GetQueryable().FirstOrDefaultAsync(s => s.QuarterName == request.QuarterName);
            return await _crud.AddToTableAsync(dbQuarter, request);
        }

        public async Task<TaskResponse<bool>> Delete(short id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }

        public async Task<TaskResponse<List<GetQuarterDto>>> GetAll()
        {
            return await _crud.GetAll();
        }

        public async Task<TaskResponse<GetQuarterDto>> GetById(short id)
        {
            return await _crud.GetById(id);
        }

        public async Task<TaskResponse<GetQuarterDto>> Update(UpdateQuarterDto request)
        {
            Quarter dbQuarter = await _quarterRepo.GetAsync(request.QuarterId);
            bool duplicated = (await _quarterRepo.GetQueryable().AnyAsync(b => b.QuarterName == request.QuarterName)) && dbQuarter.QuarterName.ToUpper() != request.QuarterName.ToUpper();

            return await _crud.UpdateEntry(dbQuarter, request, duplicated);
        }
    }
}