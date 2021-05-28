using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Services.Model.ApplicationDetailsModel;
using Jadcup.Services.Model.AssessmentModel;
using Jadcup.Services.Model.RawMaterialBoxModel;

namespace Jadcup.Services.Interface.AssessmentService
{
    public interface IAssessmentService
    {
        // ----------------------------- Standard -----------------------------
        Task<TaskResponse<List<GetAllAssessmentStandardDto>>> GetAllAssessmentStandard();
        Task<TaskResponse<bool>> Update(UpdateStandardDto request);
        Task<TaskResponse<AccessmentStandards>> AddAssessmentStandard(AddStandardDto request);
        Task<TaskResponse<bool>> DeleteAssessmentStandard(string id);


        // ----------------------------- Standard Details -----------------------------
        Task<TaskResponse<List<GetAllAssessmentStandardDetailsDto>>> GetAllAssessmentStandardDetails();
        Task<TaskResponse<AccessmentStandardsDetail>> AddAssessmentStandardDetails(AddStandardDetailsDto request);
        Task<TaskResponse<bool>> UpdateAssessmentStandardDetails(UpdateStandardDetailsDto request);
        Task<TaskResponse<bool>> DeleteAssessmentStandardDetails(string id);

        // ----------------------------- Assessment Plan -----------------------------
        Task<TaskResponse<List<AssessmentPlanDto>>> GetAllAssessmentPlan();
        Task<TaskResponse<AccessmentPlan>> AddAssessmentPlan(AddAssessmentPlanDto request);
        Task<TaskResponse<bool>> UpdateAssessmentPlan(UpdateAssessmentPlanDto request);
        Task<TaskResponse<bool>> DeleteAssessmentPlan(string id);

        // ----------------------------- One Assessment  -----------------------------
        Task<TaskResponse<List<AccessmentDto>>> GetOneAssessment(string? id);
        Task<TaskResponse<Accessment>> AddOneAssessment(AddOneAssessmentDto request);
        Task<TaskResponse<bool>> UpdateOneAssessment(UpdateOneAssessmentDto request);
        Task<TaskResponse<bool>> DeleteOneAssessment(string id);

        // ----------------------------- Assessment Details -----------------------------
        Task<TaskResponse<List<AccessmentDetailsDto>>> GetAssessmentDetails();
        Task<TaskResponse<AccessmentDetail>> AddAssessmentDetails(AddAssessmentDetailsDto request);
        Task<TaskResponse<bool>> UpdateAssessmentDetails(UpdateAssessmentDetailDto request);
        Task<TaskResponse<bool>> DeleteOneAssessmentDetails(string id);

    }
}