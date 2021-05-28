using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.PalletStackingModel;

namespace Jadcup.Services.Interface.PalletStackingService
{
    public interface IPalletStackingManagementService
    {
         Task<TaskResponse<List<GetPalletStackingDto>>> GetAll();
         Task<TaskResponse<GetPalletStackingDto>> GetById(short id);
         Task<TaskResponse<bool>> Add(AddPalletStackingDto request);
         Task<TaskResponse<bool>> Update(UpdatePalletStackingDto request);
         Task<TaskResponse<bool>> Delete(short id);
         
    }
}