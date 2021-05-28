using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.OrderStatusModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class OrderStatusManagementService : IOrderStatusManagementService
    {
        private readonly IGenericMySqlAccessRepository<OrderStatus> _orderStatusRepo;
        private readonly IMapper _mapper;
        public OrderStatusManagementService(IGenericMySqlAccessRepository<OrderStatus> orderStatusRepo, IMapper mapper)
        {
            _mapper = mapper;
            _orderStatusRepo = orderStatusRepo;

        }
        public async Task<TaskResponse<List<GetOrderStatusDto>>> GetAll()
        {
            TaskResponse<List<GetOrderStatusDto>> response = new TaskResponse<List<GetOrderStatusDto>>();

            List<OrderStatus> os = await _orderStatusRepo.GetQueryable().Where(o => o.OrderStatusId != 0).ToListAsync();

            response.Data = os.Select(o => _mapper.Map<GetOrderStatusDto>(o)).ToList();
            return response;
        }

        public async Task<TaskResponse<GetOrderStatusDto>> GetById(sbyte id)
        {
            TaskResponse<GetOrderStatusDto> response = new TaskResponse<GetOrderStatusDto>();
        
            OrderStatus os = await _orderStatusRepo.GetAsync(id);
            
            if (id == 0 || os == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            response.Data = _mapper.Map<GetOrderStatusDto>(os);
            return response;         
        }
    }
}