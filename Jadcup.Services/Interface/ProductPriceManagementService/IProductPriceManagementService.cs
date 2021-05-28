using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.ProductPriceModel;

namespace Jadcup.Services.Interface.ProductPriceService
{
    public interface IProductPriceService
    {
        Task<TaskResponse<List<GetProductPriceDto>>> GetAll();
        Task<TaskResponse<List<GetProductPriceDto>>> GetProductPriceByProduct(int ProductId);
        Task<TaskResponse<bool>> AddProductPrice(AddProductPriceDto dto);
        Task<TaskResponse<bool>> UpdateProductPrices(UpdateProductPriceDto Dto);
        Task<TaskResponse<bool>> DeleteProductPrice(string Id);

    }
}
