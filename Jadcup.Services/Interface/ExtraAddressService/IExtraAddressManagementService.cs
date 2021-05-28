using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.ExtraAddressModel;

namespace Jadcup.Services.Interface.ExtraAddressService
{
    public interface IExtraAddressManagementService
    {
         Task<TaskResponse<List<GetExtraAddressDto>>> GetAll(int? customerId);
         Task<TaskResponse<bool>> Add(AddExtraAddressDto request);
         Task<TaskResponse<bool>> Update(UpdateExtraAddressDto request);
         Task<TaskResponse<bool>> Delete(short id);
    }
}