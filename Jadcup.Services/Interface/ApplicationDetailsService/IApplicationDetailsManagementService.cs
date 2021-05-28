using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.ApplicationDetailsModel;
using Jadcup.Services.Model.RawMaterialBoxModel;

namespace Jadcup.Services.Interface.ApplicationDetailsManagementService
{
    public interface IApplicationDetailsManagementService
    {
         Task<TaskResponse<List<GetApplicationDetailsDto>>> GetAll(string applicationId, ulong? runout, DateTime? start, DateTime? end);
         Task<TaskResponse<GetApplicationDetailsDto>> GetById(string id);
         Task<TaskResponse<string>> Add(AddApplicationDetailsDto request);
         Task<TaskResponse<bool>> MarkRunout (string id, ulong runout);
         Task<TaskResponse<bool>> Delete(string id);
         Task<TaskResponse<List<List<GetRawMaterialBoxDto>>>> GetActiveRawMaterialBoxByProductId(short productId);
    }
}