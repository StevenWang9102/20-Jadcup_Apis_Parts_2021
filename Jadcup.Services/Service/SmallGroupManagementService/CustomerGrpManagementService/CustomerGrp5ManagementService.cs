using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface.CustomerGrpManagementService;
using Microsoft.EntityFrameworkCore;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup5;

namespace Jadcup.Services.Service.SmallGroupManagementService.CustomerGrpManagementService
{
    public class CustomerGrp5ManagementService : ICustomerGrp5ManagementService
    {
        private readonly ICrud<CustomerGrp5, GetGroup5Dto, UpdateGroup5Dto> _crud;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<CustomerGrp5> _group5Repo;

        public CustomerGrp5ManagementService(ICrud<CustomerGrp5, GetGroup5Dto, UpdateGroup5Dto> crud, IMapper mapper, IGenericMySqlAccessRepository<CustomerGrp5> genericMySqlAccessRepository)
        {
            _crud = crud;
            _mapper = mapper;
            _group5Repo = genericMySqlAccessRepository;
        }

        public async Task<TaskResponse<bool>> AddGroup5(AddGroup5Dto Group5)
        {
            CustomerGrp5 dbGroup5 = await _group5Repo.GetQueryable().FirstOrDefaultAsync(g => g.Group5Name == Group5.Group5Name);
            return await _crud.AddToTableAsync(dbGroup5, Group5);
        }

        public async Task<TaskResponse<bool>> DeleteGroup5(short id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }

        public async Task<TaskResponse<List<GetGroup5Dto>>> GetAllGroup5()
        {
            return await _crud.GetAll();
        }

        public async Task<TaskResponse<GetGroup5Dto>> GetGroup5ById(short id)
        {

            return await _crud.GetById(id);
        }
        public async Task<TaskResponse<GetGroup5Dto>> UpdateGroup5(UpdateGroup5Dto updatedGroup5)
        {

            CustomerGrp5 dbGroup5 = await _group5Repo.GetAsync(updatedGroup5.Group5Id);
            bool duplicated = (await _group5Repo.GetQueryable().AnyAsync(b => b.Group5Name == updatedGroup5.Group5Name)) && dbGroup5.Group5Name.ToUpper() != updatedGroup5.Group5Name.ToUpper();

            return await _crud.UpdateEntry(dbGroup5, updatedGroup5, duplicated);
        }
    }
}