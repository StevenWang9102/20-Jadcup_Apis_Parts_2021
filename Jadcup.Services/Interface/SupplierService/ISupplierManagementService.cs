using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.QualificationModel;
using Jadcup.Services.Model.SupplierModel;

namespace Jadcup.Services.Interface.SupplierService
{
    public interface ISupplierManagementService
    {
        Task<TaskResponse<List<GetSupplierDto>>> GetAll(ulong? active);
        Task<TaskResponse<GetSupplierDto>> GetById(short id);
        Task<TaskResponse<short>> Add(AddSupplierDto request);
        Task<TaskResponse<bool>> Update(UpdateSupplierDto request);
        Task<TaskResponse<short>> AddFull(AddSupplierDto2 request);
        Task<TaskResponse<bool>> AddQualification(List<AddQualificationDto> request);
        Task<TaskResponse<bool>> UpdateQualification(UpdateQualificationDto request);
        Task<TaskResponse<bool>> Delete(short id);
        Task<TaskResponse<bool>> DeleteQualification(short id);
    }
}