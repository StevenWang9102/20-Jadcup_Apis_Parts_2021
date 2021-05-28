using Jadcup.Common.Model;
using Jadcup.Services.Model.SalesVistModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jadcup.Services.Interface.SalesVisitService
{
    public interface ISalesVisitService
    {
        Task<TaskResponse<List<GetSalesVisitDto>>> GetAll();
        Task<TaskResponse<GetSalesVisitDto>> GetById(string id);
        Task<TaskResponse<short>> Add(AddSaleVistDto request);
        Task<TaskResponse<bool>> Update(UpdateSalesVisit request);
        Task<TaskResponse<bool>> Delete(string id);
    }
}
