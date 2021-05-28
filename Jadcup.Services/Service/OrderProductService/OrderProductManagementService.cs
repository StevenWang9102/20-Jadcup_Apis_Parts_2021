using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.OrderProductService;
using Jadcup.Services.Model.OrderProductModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.OrderProductService
{
    public class OrderProductManagementService : IOrderProductManagementService
    {
        private readonly IGenericMySqlAccessRepository<OrderProduct> _orderProductRepo;
        private readonly IMapper _mapper;
        public OrderProductManagementService(IGenericMySqlAccessRepository<OrderProduct> orderProductRepo, IMapper mapper)
        {
            _mapper = mapper;
            _orderProductRepo = orderProductRepo;
        }
        public async Task<TaskResponse<string>> Add(AddOrderProductDto request)
        {
            TaskResponse<string> response =  new TaskResponse<string>();
            OrderProduct op = _mapper.Map<OrderProduct>(request);

            Guid id = Guid.NewGuid();
            op.OrderProductId = id.ToString();
            _orderProductRepo.Insert(op);
            await _orderProductRepo.SaveAsync();

            response.Data = id.ToString();
            return response;
        }

        public async Task<TaskResponse<bool>> Delete(string id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            OrderProduct op = await _orderProductRepo.GetAsync(id);

            if (op == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _orderProductRepo.Delete(op);
            await _orderProductRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetOrderProductDto>>> GetAll()
        {
            TaskResponse<List<GetOrderProductDto>> response = new TaskResponse<List<GetOrderProductDto>>();

            List<OrderProduct> ops = await _orderProductRepo.GetQueryable().Include(op => op.Product).ToListAsync();

            response.Data = ops.Select(op => _mapper.Map<GetOrderProductDto>(op)).ToList();
            return response;
        }

        public async Task<TaskResponse<GetOrderProductDto>> GetById(string id)
        {
            TaskResponse<GetOrderProductDto> response = new TaskResponse<GetOrderProductDto>();

            OrderProduct op = await _orderProductRepo.GetQueryable().Include(o => o.Product).FirstOrDefaultAsync(o => o.OrderProductId == id);

            response.Data = _mapper.Map<GetOrderProductDto>(op);
            return response;
        }

        public async Task<TaskResponse<bool>> Update(UpdateOrderProductDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            OrderProduct op = await _orderProductRepo.GetAsync(request.OrderProductId);

            if (op == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _mapper.Map(request, op);
            _orderProductRepo.UpdateT(op);
            await _orderProductRepo.SaveAsync();

            response.Data = true;
            return response;
        }
    }
}