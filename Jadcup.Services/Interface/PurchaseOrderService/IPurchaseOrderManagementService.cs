using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.PurchaseOrderModel;

namespace Jadcup.Services.Interface.PurchaseOrderService
{
    public interface IPurchaseOrderManagementService
    {
        Task<TaskResponse<List<GetPurchaseOrderDto>>> GetAll(DateTime? start, DateTime? end);
        Task<TaskResponse<GetPurchaseOrderDto>> GetSingle(int? id, string poNumber);
        Task<TaskResponse<int>> Add(AddPurchaseOrderDto request);
        Task<TaskResponse<bool>> Update(UpdatePurchaseOrderDto request); 
        Task<TaskResponse<bool>> Delete(int id);
        Task<TaskResponse<bool>> Approve(int id);
        Task<TaskResponse<bool>> Complete(int id);
        Task<TaskResponse<bool>> UnloadingComplete(int id);        
        Task<TaskResponse<bool>> CompleteDetail(int poDetailId);
    }
}