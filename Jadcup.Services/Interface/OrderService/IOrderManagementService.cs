using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.OrderModel;

namespace Jadcup.Services.Interface.OrderService
{
    public interface IOrderManagementService
    {
        Task<TaskResponse<List<GetOrderDto>>> GetAll(sbyte? orderStatusId, DateTime? start, DateTime? end);
        Task<TaskResponse<List<GetOrderDto>>> GetByCust(int customerId);
        Task<TaskResponse<GetOrderDto>> GetById(string id);
        Task<TaskResponse<bool>> Update(UpdateOrderDto request);
        Task<TaskResponse<bool>> Delete(string id);
        Task<TaskResponse<string>> AddAll(AddOrderDto2 request);
        Task<TaskResponse<bool>> UpdateAll(UpdateOrderDto2 request);
        Task<TaskResponse<bool>> UpdateStatus(string id, sbyte statusId);
        Task<TaskResponse<List<GetOrderDto3>>> GetDispatchable();
        Task<TaskResponse<bool>> FinishDispatch(string orderId);   

        Task<TaskResponse<bool>> ApproveOrder(string orderId); 
        Task<string> AddFullOrder(AddOrderDto2 request,bool approved);
    }
}