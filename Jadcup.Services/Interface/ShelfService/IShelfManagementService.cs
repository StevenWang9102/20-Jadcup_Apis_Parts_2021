using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.ShelfModel;

namespace Jadcup.Services.Interface.ShelfService
{
    public interface IShelfManagementService
    {
         Task<TaskResponse<List<GetShelfDto>>> GetAll();
         Task<TaskResponse<GetShelfDto2>> GetSingle(short? shelfId, string code);
         Task<TaskResponse<short>> Add(AddShelfDto request);
         Task<TaskResponse<bool>> Update(UpdateShelfDto request);
         Task<TaskResponse<bool>> Delete(short id);
    }
}