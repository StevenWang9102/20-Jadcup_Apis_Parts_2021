using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.CellModel;

namespace Jadcup.Services.Interface.CellService
{
    public interface ICellManagementService
    {
         Task<TaskResponse<List<GetCellDto>>> GetAll(short? shelfId, short? rowNo, short? colNo);
         Task<TaskResponse<GetCellDto>> GetById(short id);
         Task<TaskResponse<bool>> Update(UpdateCellDto request);
         Task<TaskResponse<short>> Add(AddCellDto request);
         Task<TaskResponse<bool>> Delete(short id); 
    }
}