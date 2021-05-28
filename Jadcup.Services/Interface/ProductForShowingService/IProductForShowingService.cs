using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.ProductForShowingModel;

namespace Jadcup.Services.Interface.ProductForShowingService
{
    public interface IProductForShowingService
    {
        Task<TaskResponse<List<GetProductForShowingDto>>> GetAll();
    }
}