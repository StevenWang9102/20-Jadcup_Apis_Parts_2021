using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface.CustomerGrpManagementService;
using Microsoft.EntityFrameworkCore;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup4;

namespace Jadcup.Services.Service.SmallGroupManagementService.CustomerGrpManagementService
{
    public class CustomerGrp4ManagementService : ICustomerGrp4ManagementService
    {
        private readonly ICrud<CustomerGrp4, GetGroup4Dto, UpdateGroup4Dto> _crud;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<CustomerGrp4> _group4Repo;

        public CustomerGrp4ManagementService(ICrud<CustomerGrp4, GetGroup4Dto, UpdateGroup4Dto> crud, IMapper mapper, IGenericMySqlAccessRepository<CustomerGrp4> genericMySqlAccessRepository)
        {
            _crud = crud;
            _mapper = mapper;
            _group4Repo = genericMySqlAccessRepository;
        }

        public async Task<TaskResponse<bool>> AddGroup4(AddGroup4Dto Group4)
        {
            CustomerGrp4 dbGroup4 = await _group4Repo.GetQueryable().FirstOrDefaultAsync(g => g.Group4Name == Group4.Group4Name);
            return await _crud.AddToTableAsync(dbGroup4, Group4);
        }

        public async Task<TaskResponse<bool>> DeleteGroup4(short id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }

        public async Task<TaskResponse<List<GetGroup4Dto>>> GetAllGroup4()
        {
            return await _crud.GetAll();
        }

        public async Task<TaskResponse<GetGroup4Dto>> GetGroup4ById(short id)
        {

            return await _crud.GetById(id);
        }
        public async Task<TaskResponse<GetGroup4Dto>> UpdateGroup4(UpdateGroup4Dto updatedGroup4)
        {

            CustomerGrp4 dbGroup4 = await _group4Repo.GetAsync(updatedGroup4.Group4Id);
            bool duplicated = (await _group4Repo.GetQueryable().AnyAsync(b => b.Group4Name == updatedGroup4.Group4Name)) && dbGroup4.Group4Name.ToUpper() != updatedGroup4.Group4Name.ToUpper();

            return await _crud.UpdateEntry(dbGroup4, updatedGroup4, duplicated);
        }
    }
}