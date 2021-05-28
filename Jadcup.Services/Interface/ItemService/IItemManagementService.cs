using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Context;
using Jadcup.Services.Model.ItemModel;

namespace Jadcup.Services.Interface.ItemService
{
    public interface IItemManagementService
    {
        Task<short> AddItem(AddItemDto request);
        Task DeleteItem(short id);
        Task<Item> GetItemByRawMaterialId(short id);
        Task<List<Item>> GetItemByProductId(short id);
    }
}