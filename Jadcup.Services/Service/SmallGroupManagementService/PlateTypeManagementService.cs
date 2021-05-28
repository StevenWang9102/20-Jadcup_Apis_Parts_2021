using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.PlateTypeModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class PlateTypeManagementService : IPlateTypeManagementService
    {
        private readonly ICrud<PlateType, GetPlateTypeDto, UpdatePlateTypeDto> _crud;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<PlateType> _plateTypeRepo;

        public PlateTypeManagementService(ICrud<PlateType, GetPlateTypeDto, UpdatePlateTypeDto> crud, IMapper mapper, IGenericMySqlAccessRepository<PlateType> genericMySqlAccessRepository)
        {
            _crud = crud;
            _mapper = mapper;
            _plateTypeRepo = genericMySqlAccessRepository;
        }
        public async Task<TaskResponse<bool>> Add(AddPlateTypeDto request)
        {
            PlateType dbPlateType = await _plateTypeRepo.GetQueryable().FirstOrDefaultAsync(s => s.PlateTypeName == request.PlateTypeName);
            return await _crud.AddToTableAsync(dbPlateType, request);
        }

        public async Task<TaskResponse<bool>> Delete(short id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }

        public async Task<TaskResponse<List<GetPlateTypeDto>>> GetAll()
        {
            return await _crud.GetAll();
        }

        public async Task<TaskResponse<GetPlateTypeDto>> GetById(short id)
        {
            return await _crud.GetById(id);
        }

        public async Task<TaskResponse<GetPlateTypeDto>> Update(UpdatePlateTypeDto request)
        {
            PlateType dbPlateType = await _plateTypeRepo.GetAsync(request.PlateTypeId);
            bool duplicated = (await _plateTypeRepo.GetQueryable().AnyAsync(b => b.PlateTypeName == request.PlateTypeName)) && dbPlateType.PlateTypeName.ToUpper() != request.PlateTypeName.ToUpper();

            return await _crud.UpdateEntry(dbPlateType, request, duplicated);
        }
    }
}