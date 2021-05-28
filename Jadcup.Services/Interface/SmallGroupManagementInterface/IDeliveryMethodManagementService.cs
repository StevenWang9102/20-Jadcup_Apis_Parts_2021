using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.DeliveryMethodModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface IDeliveryMethodManagementService
    {
        Task<TaskResponse<List<GetDeliveryMethodDto>>> GetAll();
        Task<TaskResponse<GetDeliveryMethodDto>> GetById(short id);
        Task<TaskResponse<GetDeliveryMethodDto>> Update(UpdateDeliveryMethodDto request);
        Task<TaskResponse<bool>> Add(AddDeliveryMethodDto request);
        Task<TaskResponse<bool>> Delete(short id);
    }
}