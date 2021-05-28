using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Jadcup.Common.Context;
using Jadcup.Services.Model.QuotationItemModel;
using Jadcup.Services.Model.QuotationOptionModel;
using System.ComponentModel.DataAnnotations;

namespace Jadcup.Services.Model.QuotationModel
{
    public class UpdateQuotationDto
    {
      [Required(ErrorMessage = "Quotation Id is required.")]           
        public string QuotationId { get; set; }
      [Required(ErrorMessage = "Customer Id is required.")]           
        public int? CustomerId { get; set; }
      [Required(ErrorMessage = "Effect Date is required.")]           
        public DateTime? EffDate { get; set; }
      [Required(ErrorMessage = "Expired Date is required.")]           
        public DateTime? ExpDate { get; set; }
        public int? EmployeeId { get; set; }
        public string Notes { get; set; }
        public DateTime? CustConfimedAt { get; set; }
        public ulong? CustConfirmed { get; set; }        
        public List<AddQuotationItemDto> QuotationItem { get; set; }
        public List<AddQuotationOptionDto> QuotationOption { get; set; }
    }
}