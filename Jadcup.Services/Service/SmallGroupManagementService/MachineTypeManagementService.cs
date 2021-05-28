
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.MachineTypeModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class MachineTypeManagementService : IMachineTypeManagementService
    {
        private readonly ICrud<MachineType, GetMachineTypeDto, UpdateMachineTypeDto> _crud;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<MachineType> _machineTypeRepo;

        public MachineTypeManagementService(ICrud<MachineType, GetMachineTypeDto, UpdateMachineTypeDto> crud, IMapper mapper, IGenericMySqlAccessRepository<MachineType> genericMySqlAccessRepository)
        {
            _crud = crud;
            _mapper = mapper;
            _machineTypeRepo = genericMySqlAccessRepository;
        }
        public async Task<TaskResponse<bool>> Add(AddMachineTypeDto request)
        {
            MachineType dbMachineType = await _machineTypeRepo.GetQueryable().FirstOrDefaultAsync(s => s.MachineTypeName == request.MachineTypeName);
            return await _crud.AddToTableAsync(dbMachineType, request);
        }

        public async Task<TaskResponse<bool>> Delete(int id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }

        public async Task<TaskResponse<List<GetMachineTypeDto>>> GetAll()
        {
            return await _crud.GetAll();
        }

        public async Task<TaskResponse<GetMachineTypeDto>> GetById(int id)
        {
            return await _crud.GetById(id);
        }

        public async Task<TaskResponse<GetMachineTypeDto>> Update(UpdateMachineTypeDto request)
        {
            MachineType dbMachineType = await _machineTypeRepo.GetAsync(request.MachineTypeId);
            bool duplicated = (await _machineTypeRepo.GetQueryable().AnyAsync(b => b.MachineTypeName == request.MachineTypeName)) && dbMachineType.MachineTypeName.ToUpper() != request.MachineTypeName.ToUpper();

            return await _crud.UpdateEntry(dbMachineType, request, duplicated);
        }
    }
}
