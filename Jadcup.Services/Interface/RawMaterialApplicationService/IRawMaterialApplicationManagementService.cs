using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.ApplicationDetailsModel;
using Jadcup.Services.Model.RawMaterialApplicationModel;

namespace Jadcup.Services.Interface.RawMaterialApplicationService
{
    public interface IRawMaterialApplicationManagementService
    {
         Task<TaskResponse<List<GetRawMaterialApplicationDto>>> GetAll(ulong? processed);
         Task<TaskResponse<GetRawMaterialApplicationDto>> GetById(string id);
         Task<TaskResponse<string>> Add(AddRawMaterialApplicationDto request);
         Task<TaskResponse<bool>> Delete(string id);
         Task<TaskResponse<bool>> Process(string id, int warehouseEmployeeId);
         Task<TaskResponse<bool>> Receive(string id, int quantity);

    }
}