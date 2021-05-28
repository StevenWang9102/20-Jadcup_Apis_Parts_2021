using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.OrderTypeModel;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class OrderTypeManagementService : IOrderTypeManagementService
    {
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<OrderType> _orderTypeRepo;
        public OrderTypeManagementService(IMapper mapper, IGenericMySqlAccessRepository<OrderType> orderTypeRepo)
        {
            _orderTypeRepo = orderTypeRepo;
            _mapper = mapper;

        }
        public async Task<TaskResponse<List<GetOrderTypeDto>>> GetAll()
        {
            TaskResponse<List<GetOrderTypeDto>> response = new TaskResponse<List<GetOrderTypeDto>>();

            List<OrderType> ots = await _orderTypeRepo.GetAllAsync();

            response.Data = ots.Select(o => _mapper.Map<GetOrderTypeDto>(o)).ToList();
            return response;
        }
    }
}