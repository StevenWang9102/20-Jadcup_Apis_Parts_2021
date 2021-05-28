using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.DepartmentModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class DeptManagementService : IDeptManagementService
    {
        private readonly ICrud<Dept, GetDepartmentDto, UpdateDepartmentDto> _crud;
        private readonly IGenericMySqlAccessRepository<Dept> _deptRepo;
        private readonly IMapper _mapper;

        public DeptManagementService(ICrud<Dept, GetDepartmentDto, UpdateDepartmentDto> crud, IGenericMySqlAccessRepository<Dept> genericMySqlAccessRepository, IMapper mapper)
        {
            _crud = crud;
            _deptRepo = genericMySqlAccessRepository;
            _mapper = mapper;
        }
        public async Task<TaskResponse<bool>> Add(AddDepartmentDto request)
        {
            Dept dbDept = await _deptRepo.GetQueryable().FirstOrDefaultAsync(d => d.DeptName == request.DeptName);
            return await _crud.AddToTableAsync(dbDept, request);
        }

        public async Task<TaskResponse<bool>> Delete(short id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }

        public async Task<TaskResponse<List<GetDepartmentDto>>> GetAll()
        {
            return await _crud.GetAll();
        }

        public async Task<TaskResponse<List<GetDepartmentWithStandardDto>>> GetAllDepartmentWithStandard()
        {
            TaskResponse<List<GetDepartmentWithStandardDto>> response = new TaskResponse<List<GetDepartmentWithStandardDto>>();

            List<Dept> entity = await _deptRepo.GetQueryable()
                .Include(c => c.AcceStandard)
                .ToListAsync();

            response.Data = entity.Select(c => _mapper.Map<GetDepartmentWithStandardDto>(c)).ToList();
            return response;
        }

        public async Task<TaskResponse<GetDepartmentDto>> GetById(short id)
        {
            return await _crud.GetById(id);
        }

        public async Task<TaskResponse<GetDepartmentDto>> Update(UpdateDepartmentDto request)
        {
            Dept dbDept = await _deptRepo.GetAsync(request.DeptId);
            bool duplicated = (await _deptRepo.GetQueryable().AnyAsync(d => d.DeptName == request.DeptName)) && dbDept.DeptName.ToUpper() != request.DeptName.ToUpper();

            return await _crud.UpdateEntry(dbDept, request, duplicated);
        }
    }
}