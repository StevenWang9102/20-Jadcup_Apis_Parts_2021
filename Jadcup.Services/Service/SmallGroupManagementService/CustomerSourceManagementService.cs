using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.CustomerSourceModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class CustomerSourceManagementService : ICustomerSourceManagementService
    {
        private readonly ICrud<CustomerSource, GetCustomerSourceDto, UpdateCustomerSourceDto> _crud;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<CustomerSource> _customerSourceRepo;

        public CustomerSourceManagementService(ICrud<CustomerSource, GetCustomerSourceDto, UpdateCustomerSourceDto> crud, IMapper mapper, IGenericMySqlAccessRepository<CustomerSource> genericMySqlAccessRepository)
        {
            _crud = crud;
            _mapper = mapper;
            _customerSourceRepo = genericMySqlAccessRepository;
        }


        public async Task<TaskResponse<bool>> Add(AddCustomerSourceDto request)
        {
            CustomerSource dbSource = await _customerSourceRepo.GetQueryable().FirstOrDefaultAsync(s => s.SourceName == request.SourceName);
            return await _crud.AddToTableAsync(dbSource, request);
        }


        public async Task<TaskResponse<bool>> Delete(short id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }
        public async Task<TaskResponse<List<GetCustomerSourceDto>>> GetAll()
        {
            return await _crud.GetAll();
        }

        public async Task<TaskResponse<GetCustomerSourceDto>> GetById(short id)
        {
            return await _crud.GetById(id);
        }

        public async Task<TaskResponse<GetCustomerSourceDto>> Update(UpdateCustomerSourceDto updatedCustomerSource)
        {
            CustomerSource dbCustomerSource = await _customerSourceRepo.GetAsync(updatedCustomerSource.SourceId);
            bool duplicated = (await _customerSourceRepo.GetQueryable().AnyAsync(b => b.SourceName == updatedCustomerSource.SourceName)) && dbCustomerSource.SourceName.ToUpper() != updatedCustomerSource.SourceName.ToUpper();
            
            return await _crud.UpdateEntry(dbCustomerSource, updatedCustomerSource, duplicated);
        }
    }
}