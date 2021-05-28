using System;
using System.Collections.Generic;
using Jadcup.Services.Model.QuotationItemModel;
using Jadcup.Services.Model.QuotationOptionModel;
using System.ComponentModel.DataAnnotations;

namespace Jadcup.Services.Model.QuotationModel
{
    public class AddQuotationDto
    {
        [Required(ErrorMessage = "Is Draft is required.")]          
        public ulong? Draft { get; set; }
       [Required(ErrorMessage = "Customer Id is required.")]          
        public int? CustomerId { get; set; }
       [Required(ErrorMessage = "Effect Date is required.")]             
        public DateTime? EffDate { get; set; }
       [Required(ErrorMessage = "Expired Date is required.")]             
        public DateTime? ExpDate { get; set; }
        public int? EmployeeId { get; set; }
        public string Notes { get; set; }
        
    }

    public class AddQuotationDto2
    {
        [Required(ErrorMessage = "Is Draft is required.")]   
        public ulong? Draft { get; set; }
       [Required(ErrorMessage = "Customer Id is required.")]         
        public int? CustomerId { get; set; }
       [Required(ErrorMessage = "Effect Date is required.")]          
        public DateTime? EffDate { get; set; }
        [Required(ErrorMessage = "Expired Date is required.")]          
        public DateTime? ExpDate { get; set; }
        public int? EmployeeId { get; set; }
        public string Notes { get; set; }
        public List<AddQuotationItemDto> QuotationItem { get; set; }
        public List<AddQuotationOptionDto> QuotationOption { get; set; }
    }
}