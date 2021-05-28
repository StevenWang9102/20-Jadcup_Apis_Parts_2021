using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.ProductModel;
using Jadcup.Services.Model.StockModel;

namespace Jadcup.Services.Interface.ProductService
{
    public interface IProductManagementService
    {
         Task<TaskResponse<List<GetProductDto>>> GetAll();
         Task<TaskResponse<GetProductDto>> GetById(short id, short? group1Id);
         Task<TaskResponse<int>> UpdateProduct(UpdateProductDto request);
         Task<TaskResponse<int>> Add(AddProductDto request);
         Task<TaskResponse<int>> AddOutSourceProd(AddOutSourceProdDto request);
         Task<TaskResponse<bool>> Delete(short id);
         Task<TaskResponse<List<GetProductDto3>>> GetProductByCustomerId(int id);
         Task<(GetStockDto stockDto, GetStockDto semiStockDto)> GetProductStocks(short productId);
    }
}