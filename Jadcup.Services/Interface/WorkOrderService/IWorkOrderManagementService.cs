using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.WorkOrderModel;

namespace Jadcup.Services.Interface.WorkOrderService
{
    public interface IWorkOrderManagementService
    {
        Task<TaskResponse<List<GetWorkOrderDto>>> GetAll(sbyte? statusId, DateTime? start, DateTime? end, bool? orderByRequiredDate);
        Task<TaskResponse<GetWorkOrderDto>> GetById(string id);
        Task<TaskResponse<bool>> Add(AddWorkOrderDto request);
        Task<TaskResponse<bool>> Delete(string id);
        Task<TaskResponse<bool>> Urgent(string id, bool urgent);
        Task<TaskResponse<bool>> Approve(string id, int employeeId, string approvedComment);
        Task<TaskResponse<bool>> UpdateQuantity(string id, int quantity);
        Task AddWorkOrderAndSuborder(AddWorkOrderDto request);
        Task<string> GenerateWorkOrderNo();
    }
}