using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.PriceModel;

namespace Jadcup.Services.Interface.PriceService
{
    public interface IPriceManagementService
    {
        Task<TaskResponse<List<GetPriceDto>>> GetAll(short? BaseProductId, short? group1Id);
        Task<TaskResponse<GetPriceDto>> GeyById(short priceId);
        Task<TaskResponse<bool>> Add(AddPriceDto request);
        Task<TaskResponse<bool>> Update(UpdatePriceDto request);
        Task<TaskResponse<bool>> Delete(short priceId);
    }
}