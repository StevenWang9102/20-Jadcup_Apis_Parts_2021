using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.RawMaterialModel;
using Jadcup.Services.Model.SupplierModel;
using Jadcup.Services.Model.SupplierRawMaterialModel;

namespace Jadcup.Services.Interface.SupplierRawMaterialService
{
    public interface ISupplierRawMaterialManagementService
    {
         Task<TaskResponse<List<GetSupplierDto>>> GetSupplierByRawMaterialId(short rawMaterialId);
         Task<TaskResponse<List<GetRawMaterialDto>>> GetRawMaterialBySupplierId(short supplierId);
         Task<TaskResponse<List<GetSupplierRawMaterialDto>>> GetAll(short? supplierId, short? rawMaterialId);
         Task<TaskResponse<int>> Add(AddSupplierRawMaterialDto request);
         Task<TaskResponse<bool>> Delete(DeleteSupplierRawMaterialDto request);
    }
}