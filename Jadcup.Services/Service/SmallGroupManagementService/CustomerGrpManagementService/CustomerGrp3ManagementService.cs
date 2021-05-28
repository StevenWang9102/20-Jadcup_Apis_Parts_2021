using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface.CustomerGrpManagementService;
using Microsoft.EntityFrameworkCore;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup3;

namespace Jadcup.Services.Service.SmallGroupManagementService.CustomerGrpManagementService
{
    public class CustomerGrp3ManagementService : ICustomerGrp3ManagementService
    {
        private readonly ICrud<CustomerGrp3, GetGroup3Dto, UpdateGroup3Dto> _crud;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<CustomerGrp3> _group3Repo;

        public CustomerGrp3ManagementService(ICrud<CustomerGrp3, GetGroup3Dto, UpdateGroup3Dto> crud, IMapper mapper, IGenericMySqlAccessRepository<CustomerGrp3> genericMySqlAccessRepository)
        {
            _crud = crud;
            _mapper = mapper;
            _group3Repo = genericMySqlAccessRepository;
        }

        public async Task<TaskResponse<bool>> AddGroup3(AddGroup3Dto Group3)
        {
            CustomerGrp3 dbGroup3 = await _group3Repo.GetQueryable().FirstOrDefaultAsync(g => g.Group3Name == Group3.Group3Name);
            return await _crud.AddToTableAsync(dbGroup3, Group3);
        }

        public async Task<TaskResponse<bool>> DeleteGroup3(short id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }

        public async Task<TaskResponse<List<GetGroup3Dto>>> GetAllGroup3()
        {
            return await _crud.GetAll();
        }

        public async Task<TaskResponse<GetGroup3Dto>> GetGroup3ById(short id)
        {

            return await _crud.GetById(id);
        }
        public async Task<TaskResponse<GetGroup3Dto>> UpdateGroup3(UpdateGroup3Dto updatedGroup3)
        {

            CustomerGrp3 dbGroup3 = await _group3Repo.GetAsync(updatedGroup3.Group3Id);
            bool duplicated = (await _group3Repo.GetQueryable().AnyAsync(b => b.Group3Name == updatedGroup3.Group3Name)) && dbGroup3.Group3Name.ToUpper() != updatedGroup3.Group3Name.ToUpper();

            return await _crud.UpdateEntry(dbGroup3, updatedGroup3, duplicated);
        }
    }
}