using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.DispatchingModel;

namespace Jadcup.Services.Interface.DispatchingService
{
    public interface IDispatchingManagementService
    {
         Task<TaskResponse<List<GetDispatchingDto>>> GetAll(string orderId, sbyte? statusId, DateTime? start, DateTime? end);
         Task<TaskResponse<GetDispatchingDto>> GetSingle(string dispatchId, string trackingNO);
         Task<TaskResponse<string>> Add(AddDispatchingDto request);
         Task<TaskResponse<bool>> Update(UpdateDispatchingDto request);
         Task<TaskResponse<bool>> Delete(string id);
         Task<TaskResponse<bool>> Dispatch(FinishDispatchDto request);
    }
}