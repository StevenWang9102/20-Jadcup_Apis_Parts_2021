using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.RoleModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class RoleManagementService : IRoleManagementService
    {
        private readonly ICrud<Role, GetRoleDto, UpdateRoleDto> _crud;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<Role> _roleRepo;

        public RoleManagementService(ICrud<Role, GetRoleDto, UpdateRoleDto> crud, IMapper mapper, IGenericMySqlAccessRepository<Role> genericMySqlAccessRepository)
        {
            _crud = crud;
            _mapper = mapper;
            _roleRepo = genericMySqlAccessRepository;
        }

        public async Task<TaskResponse<bool>> Add(AddRoleDto request)
        {
            Role dbRole = await _roleRepo.GetQueryable().FirstOrDefaultAsync(r => r.RoleName == request.RoleName);
            return await _crud.AddToTableAsync(dbRole, request);
        }

        public async Task<TaskResponse<bool>> Delete(short id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }

        public async Task<TaskResponse<List<GetRoleDto>>> GetAll()
        {
            return await _crud.GetAll();
        }

        public async Task<TaskResponse<GetRoleDto>> GetById(short id)
        {
            return await _crud.GetById(id);
        }

        public async Task<TaskResponse<GetRoleDto>> Update(UpdateRoleDto request)
        {
            Role dbRole = await _roleRepo.GetAsync(request.RoleId);
            bool duplicated = (await _roleRepo.GetQueryable().AnyAsync(r => r.RoleName == request.RoleName)) && dbRole.RoleName.ToUpper() != request.RoleName.ToUpper();

            return await _crud.UpdateEntry(dbRole, request, duplicated);
        }
    }
}