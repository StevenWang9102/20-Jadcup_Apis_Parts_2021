using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface.CustomerGrpManagementService;
using Microsoft.EntityFrameworkCore;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup1;

namespace Jadcup.Services.Service.SmallGroupManagementService.CustomerGrpManagementService
{
    public class CustomerGrp1ManagementService : ICustomerGrp1ManagementService
    {
        private readonly ICrud<CustomerGrp1, GetGroup1Dto, UpdateGroup1Dto> _crud;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<CustomerGrp1> _group1Repo;

        public CustomerGrp1ManagementService(ICrud<CustomerGrp1, GetGroup1Dto, UpdateGroup1Dto> crud, IMapper mapper, IGenericMySqlAccessRepository<CustomerGrp1> genericMySqlAccessRepository)
        {
            _crud = crud;
            _mapper = mapper;
            _group1Repo = genericMySqlAccessRepository;
        }

        public async Task<TaskResponse<bool>> AddGroup1(AddGroup1Dto Group1)
        {
            CustomerGrp1 dbGroup1 = await _group1Repo.GetQueryable().FirstOrDefaultAsync(g => g.Group1Name == Group1.Group1Name);
            return await _crud.AddToTableAsync(dbGroup1, Group1);
        }

        public async Task<TaskResponse<bool>> DeleteGroup1(short id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }

        public async Task<TaskResponse<List<GetGroup1Dto>>> GetAllGroup1()
        {
            return await _crud.GetAll();
        }

        public async Task<TaskResponse<GetGroup1Dto>> GetGroup1ById(short id)
        {

            return await _crud.GetById(id);
        }
        public async Task<TaskResponse<GetGroup1Dto>> UpdateGroup1(UpdateGroup1Dto updatedGroup1)
        {

            CustomerGrp1 dbGroup1 = await _group1Repo.GetAsync(updatedGroup1.Group1Id);
            bool duplicated = (await _group1Repo.GetQueryable().AnyAsync(b => b.Group1Name == updatedGroup1.Group1Name)) && dbGroup1.Group1Name.ToUpper() != updatedGroup1.Group1Name.ToUpper();

            return await _crud.UpdateEntry(dbGroup1, updatedGroup1, duplicated);
        }
    }
}