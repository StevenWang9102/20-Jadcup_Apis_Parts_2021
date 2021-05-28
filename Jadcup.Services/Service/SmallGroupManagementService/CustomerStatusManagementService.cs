using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.CustomerStatusModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class CustomerStatusManagementService : ICustomerStatusManagementService
    {
        private readonly IGenericMySqlAccessRepository<CustomerStatus> _customerStatusRepo;
        private readonly IMapper _mapper;
        public CustomerStatusManagementService(IGenericMySqlAccessRepository<CustomerStatus> genericMySqlAccessRepository, IMapper mapper)
        {
            _mapper = mapper;
            _customerStatusRepo = genericMySqlAccessRepository;

        }
        public async Task<TaskResponse<List<GetCustomerStatusDto>>> GetAll()
        {
            TaskResponse<List<GetCustomerStatusDto>> response =  new TaskResponse<List<GetCustomerStatusDto>>();
            
            List<CustomerStatus> statuses = await _customerStatusRepo.GetQueryable().Where(s => s.StatusName != "Inactive").ToListAsync();

            response.Data = (statuses.Select(s => _mapper.Map<GetCustomerStatusDto>(s))).ToList();

            return response;
        }
    }
}