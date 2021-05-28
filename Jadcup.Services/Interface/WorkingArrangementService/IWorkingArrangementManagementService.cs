using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.WorkingArrangementModel;

namespace Jadcup.Services.Interface.WorkingArrangementService
{
    public interface IWorkingArrangementManagementService
    {
        Task<TaskResponse<List<GetWorkingArrangementDto>>> GetAll(int? createdBy, DateTime? workingDate, short? machingId, int? operatorId, DateTime? start, DateTime? end);
        Task<TaskResponse<GetWorkingArrangementDto>> GetById(int id);
        Task<TaskResponse<bool>> Update(UpdateWorkingArrangementDto request);
        Task<TaskResponse<bool>> Delete(int id);
        Task<TaskResponse<int>> Add(AddWorkingArrangementDto request);
        Task<TaskResponse<bool>> UpdateList(List<UpdateWorkingArrangementDto> request);
        Task<TaskResponse<bool>> DeleteList(List<int> request); 
        Task<TaskResponse<bool>> AddList(List<AddWorkingArrangementDto> request);       
    }
}