using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.PaymentCycleModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface IPaymentCycleManagementService
    {
        Task<TaskResponse<List<GetPaymentCycleDto>>> GetAll();
        Task<TaskResponse<GetPaymentCycleDto>> GetById(short id);
        Task<TaskResponse<GetPaymentCycleDto>> Update(UpdatePaymentCycleDto request);
        Task<TaskResponse<bool>> Add(AddPaymentCycleDto request);
        Task<TaskResponse<bool>> Delete(short id);
    }
}