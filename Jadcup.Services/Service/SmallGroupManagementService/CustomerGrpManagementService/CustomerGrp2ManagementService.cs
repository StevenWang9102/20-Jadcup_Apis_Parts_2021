using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface.CustomerGrpManagementService;
using Microsoft.EntityFrameworkCore;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup2;

namespace Jadcup.Services.Service.SmallGroupManagementService.CustomerGrpManagementService
{
    public class CustomerGrp2ManagementService : ICustomerGrp2ManagementService
    {
        private readonly ICrud<CustomerGrp2, GetGroup2Dto, UpdateGroup2Dto> _crud;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<CustomerGrp2> _group2Repo;

        public CustomerGrp2ManagementService(ICrud<CustomerGrp2, GetGroup2Dto, UpdateGroup2Dto> crud, IMapper mapper, IGenericMySqlAccessRepository<CustomerGrp2> genericMySqlAccessRepository)
        {
            _crud = crud;
            _mapper = mapper;
            _group2Repo = genericMySqlAccessRepository;
        }

        public async Task<TaskResponse<bool>> AddGroup2(AddGroup2Dto Group2)
        {
            CustomerGrp2 dbGroup2 = await _group2Repo.GetQueryable().FirstOrDefaultAsync(g => g.Group2Name == Group2.Group2Name);
            return await _crud.AddToTableAsync(dbGroup2, Group2);
        }

        public async Task<TaskResponse<bool>> DeleteGroup2(short id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }

        public async Task<TaskResponse<List<GetGroup2Dto>>> GetAllGroup2()
        {
            return await _crud.GetAll();
        }

        public async Task<TaskResponse<GetGroup2Dto>> GetGroup2ById(short id)
        {

            return await _crud.GetById(id);
        }
        public async Task<TaskResponse<GetGroup2Dto>> UpdateGroup2(UpdateGroup2Dto updatedGroup2)
        {

            CustomerGrp2 dbGroup2 = await _group2Repo.GetAsync(updatedGroup2.Group2Id);
            bool duplicated = (await _group2Repo.GetQueryable().AnyAsync(b => b.Group2Name == updatedGroup2.Group2Name)) && dbGroup2.Group2Name.ToUpper() != updatedGroup2.Group2Name.ToUpper();
            
            return await _crud.UpdateEntry(dbGroup2, updatedGroup2, duplicated);
        }
    }
}