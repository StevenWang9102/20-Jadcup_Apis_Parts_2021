using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.PackagingTypeModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class PackagingTypeManagementService : IPackagingTypeManagementService
    {
        private readonly ICrud<PackagingType, GetPackagingTypeDto, UpdatePackagingTypeDto> _crud;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<PackagingType> _packagingTypeRepo;

        public PackagingTypeManagementService(ICrud<PackagingType, GetPackagingTypeDto, UpdatePackagingTypeDto> crud, IMapper mapper, IGenericMySqlAccessRepository<PackagingType> genericMySqlAccessRepository)
        {
            _crud = crud;
            _mapper = mapper;
            _packagingTypeRepo = genericMySqlAccessRepository;
        }
        public async Task<TaskResponse<bool>> Add(AddPackagingTypeDto request)
        {
            PackagingType dbPackagingType = await _packagingTypeRepo.GetQueryable().FirstOrDefaultAsync(s => s.PackagingTypeName == request.PackagingTypeName);
            return await _crud.AddToTableAsync(dbPackagingType, request);
        }

        public async Task<TaskResponse<bool>> Delete(short id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }

        public async Task<TaskResponse<List<GetPackagingTypeDto>>> GetAll()
        {
            return await _crud.GetAll();
        }

        public async Task<TaskResponse<GetPackagingTypeDto>> GetById(short id)
        {
            return await _crud.GetById(id);
        }

        public async Task<TaskResponse<GetPackagingTypeDto>> Update(UpdatePackagingTypeDto request)
        {
            PackagingType dbPackagingType = await _packagingTypeRepo.GetAsync(request.PackagingTypeId);
            bool duplicated = (await _packagingTypeRepo.GetQueryable().AnyAsync(b => b.PackagingTypeName == request.PackagingTypeName)) && dbPackagingType.PackagingTypeName.ToUpper() != request.PackagingTypeName.ToUpper();

            return await _crud.UpdateEntry(dbPackagingType, request, duplicated);
        }
    }
}