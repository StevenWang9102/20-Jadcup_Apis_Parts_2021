using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.MachineModel;

namespace Jadcup.Services.Interface.MachineService
{
    public interface IMachineManagementService
    {
         Task<TaskResponse<List<GetMachineDto>>> GetAll();
         Task<TaskResponse<GetMachineDto>> GetById(short id);
         Task<TaskResponse<bool>> Update(UpdateMachineDto request);
         Task<TaskResponse<bool>> Add(AddMachineDto request);
         Task<TaskResponse<bool>> Delete(short id);
    }
}