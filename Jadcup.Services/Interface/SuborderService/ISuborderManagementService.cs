using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.SuborderLogModel;
using Jadcup.Services.Model.SuborderModel;

namespace Jadcup.Services.Interface.SuborderService
{
    public interface ISuborderManagementService
    {
        Task<TaskResponse<List<GetSuborderDto3>>> GetAll(sbyte? statusId, DateTime? start, DateTime? end);
        Task<TaskResponse<GetSuborderDto>> GetById(string id);
        Task<TaskResponse<List<GetSuborderDto4>>> GetByMachineId(short id, DateTime? date,bool inclQueue);
        Task<TaskResponse<List<GetSuborderDto4>>> GetByMachineId1(short id, DateTime? date,bool inclQueue);

        Task<TaskResponse<List<GetSuborderDto5>>> GetByDate( DateTime? completeDate);
        Task<TaskResponse<List<GetSuborderDto5>>> GetByDate2( DateTime? completeDate);
        Task<TaskResponse<List<GetSuborderDto5>>> GetByDate3( DateTime? completeDate);
        void Add(AddSuborderDto request);
        Task<TaskResponse<bool>> TakeOrder(string id, AddSuborderLogDto request);
        Task<TaskResponse<bool>> Pause(string id);
        Task<TaskResponse<bool>> Finish(string id, AddSuborderLogDto request);
        Task<TaskResponse<bool>> PartlyFinish(string id, AddSuborderLogDto request);
        Task<TaskResponse<List<GetSuborderDto>>> GetByWorkOrderId(string id);
        Task<TaskResponse<List<GetSuborderLogDto>>> GetSuborderLog(string suborderId, int? operEmployeeId, string rawMaterialBoxId, short? machineId);
        Task<TaskResponse<bool>> Unpause(string id);
    }
}