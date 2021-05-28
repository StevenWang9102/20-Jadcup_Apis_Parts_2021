using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.UnloadingInspectionModel;

namespace Jadcup.Services.Interface.UnloadingInspectionService
{
    public interface IUnloadingInspectionManagementService
    {
         Task<TaskResponse<List<GetUnloadingInspectionDto2>>> GetAll(int? poId, DateTime? unloadingDateStart, DateTime? unloadingDateEnd);
         Task<TaskResponse<GetUnloadingInspectionDto>> GetById(string id);
         Task<TaskResponse<string>> Add(AddUnloadingInspectionDto request);
         Task<TaskResponse<bool>> Update(UpdateUnloadingInspectionDto request);
         Task<TaskResponse<bool>> Delete(string id); 
    }
}