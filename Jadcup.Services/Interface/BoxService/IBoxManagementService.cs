using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Services.Model.BoxModel;

namespace Jadcup.Services.Interface.BoxService
{
    public interface IBoxManagementService
    {
        Task<TaskResponse<List<GetBoxDto>>> GetAll(string suborderId, short? productId, ulong? isSemi, short? sequence, string ticketId);
        Task<TaskResponse<GetBoxDto>> GetById(string id);
        Task<TaskResponse<GetBoxDto>> GetByBarCode(string barCode);
        Task<TaskResponse<List<string>>> GenerateBarCode(string suborderId, int count);
        Task<TaskResponse<bool>> UpdateQuantity(string id, int quantity);
        Task<TaskResponse<bool>> Delete(string id);
        Task<TaskResponse<List<GetBoxDto3>>> GetByProductId(short productId);
        Task<TaskResponse<bool>> Obsolete(string id);
        Task<TaskResponse<bool>> UpdateStockQuantity(string id, int quantity);
        Task GenerateSemiBox(Suborder suborder); 
        Task<string> GetBarCode();
        Task<bool> SetPalletAvaiable(string boxId);
        Task<bool> SetPalletAvaiable(List<string> boxId);        
    }
}