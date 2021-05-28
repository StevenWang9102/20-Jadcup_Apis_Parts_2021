using Jadcup.Common.Model;
using Jadcup.Services.Model.HumanResource;
using Jadcup.Services.Model.HumanResource.AttachedRecord;
using Jadcup.Services.Model.HumanResource.Contract;
using Jadcup.Services.Model.HumanResource.SalaryFactor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Jadcup.Services.Interface.HumanResourceService
{
    public interface IHumanResourceManagementService
    {
        Task<TaskResponse<List<GetHumanResourceDto>>> GetAll(short? status, short? role, DateTime? start, DateTime? end);
        Task<TaskResponse<GetHumanResourceDto>> GetById(string id);
        Task<TaskResponse<bool>> Add(AddHumanResourceDto request);
        Task<TaskResponse<bool>> Update(UpdateHumanResourceDto request);
        Task<TaskResponse<bool>> Delete(string resourceId);
        Task<TaskResponse<bool>> AddContract(AddContractDto request);
        Task<TaskResponse<bool>> UpdateContract(UpdateContractDto request);
        Task<TaskResponse<bool>> DeleteContract(short contractId);
        Task<TaskResponse<bool>> AddAttachedRecord(AddAttachedRecordDto request);
        Task<TaskResponse<bool>> UpdateAttachedRecord(UpdateAttachedRecordDto request);
        Task<TaskResponse<bool>> DeleteAttachedRecord(string id);
        Task<TaskResponse<bool>> AddSalaryFactor(AddSalaryFactorDto request);
        Task<TaskResponse<bool>> UpdateSalaryFactor(UpdateSalaryFactorDto request);
        Task<TaskResponse<bool>> DeleteSalaryFactor(string resourceId);
    }
}
