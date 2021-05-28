using Jadcup.Services.Model.EmployeeModel;
using System;

namespace Jadcup.Services.Model.AssessmentModel
{
    public class GetAllAssessmentStandardDto
    {
        public string AcceStandardId { get; set; }
        public string Name { get; set; }
        public ulong? Active { get; set; }
    }

    public class GetAllAssessmentStandardDetailsDto
    {
        public string AcceStandDetailId { get; set; }
        public string Item { get; set; }
        public decimal Max { get; set; }
        public string AcceStandardId { get; set; }
        public int? Weight { get; set; }
    }
    public class AssessmentPlanDto
    {
        public string AccessmentPlanId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public ulong? Active { get; set; }
        public string Notes { get; set; }
    }

    public class AssessmentPlanDto2
    {
        public string AccessmentPlanId { get; set; }
        public string Notes { get; set; }
    }

    public class AccessmentDto
    {
        public string AccessmentId { get; set; }
        public int? EmployeeId { get; set; }
        public GetEmployeeDto3 Employee { get; set; }
        public string AccessmentPlanId { get; set; }
        public AssessmentPlanDto2 AccessmentPlan { get; set; }
        public string AcceStandardId { get; set; }
        public GetAllAssessmentStandardDto AcceStandard { get; set; }
        public string Item { get; set; }
        public sbyte Status { get; set; }
        public ulong? Active { get; set; }

        public decimal TotalMarks { get; set; }

    }

    public class AccessmentDetailsDto
    {
        public string AccessmentDetailId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Notes { get; set; }
        public string AccessmentId { get; set; }
        public string AcceStandDetailId
        {
            get; set;
        }
    }

    public class AddAssessmentDetailsDto
    {
        public string AccessmentDetailId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Notes { get; set; }
        public string AccessmentId { get; set; }
        public string AcceStandDetailId { get; set; }
    }

        public class AddAccessmentDto
        {
            public string AccessmentPlanId { get; set; }
            public DateTime? CreatedAt { get; set; }
            public ulong? Active { get; set; }
            public string Notes { get; set; }
        }

        public class AddStandardDto
        {
            public string AcceStandardId { get; set; }
            public string Name { get; set; }
            public ulong? Active { get; set; }
        }

        public class AddStandardDetailsDto
        {
            public string AcceStandDetailId { get; set; }
            public string Item { get; set; }
            public decimal Max { get; set; }
            public string AcceStandardId { get; set; }
            public int? Weight { get; set; }
        }

        public class AddAssessmentPlanDto
        {
            public string AccessmentPlanId { get; set; }
            public DateTime? CreatedAt { get; set; }
            public ulong? Active { get; set; }
            public string Notes { get; set; }
        }

        public class AddOneAssessmentDto
        {
            public string AccessmentId { get; set; }
            public string Item { get; set; }
            public decimal TotalMarks { get; set; }
            public sbyte Status { get; set; }
            public string AccessmentPlanId { get; set; }
            public string AcceStandardId { get; set; }
            public ulong? Active { get; set; }
            public int? EmployeeId { get; set; }
        }


        public class UpdateStandardDto
        {
            public string AcceStandardId { get; set; }
            public string Name { get; set; }
            public ulong? Active { get; set; }
        }

        public class UpdateOneAssessmentDto
        {
            public string AccessmentId { get; set; }
            public string Item { get; set; }
            public decimal TotalMarks { get; set; }
            public sbyte Status { get; set; }
            public string AccessmentPlanId { get; set; }
            public string AcceStandardId { get; set; }
            public ulong? Active { get; set; }
            public int? EmployeeId { get; set; }
        }

        public class UpdateAssessmentPlanDto
        {
            public string AccessmentPlanId { get; set; }
            public DateTime? CreatedAt { get; set; }
            public ulong? Active { get; set; }
            public string Notes { get; set; }
        }

        public class UpdateStandardDetailsDto
        {
            public string AcceStandDetailId { get; set; }
            public string Item { get; set; }
            public decimal Max { get; set; }
            public string AcceStandardId { get; set; }
            public int? Weight { get; set; }
        }

        public class AddStandardDetailDto
        {
            public string AcceStandDetailId { get; set; }
            public string Item { get; set; }
            public decimal Max { get; set; }
            public string AcceStandardId { get; set; }
            public int? Weight { get; set; }
        }

    
    public class UpdateAssessmentDetailDto
    {
        public string AccessmentDetailId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Notes { get; set; }
        public string AccessmentId { get; set; }
        public string AcceStandDetailId { get; set; }
    }
}
