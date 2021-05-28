using System;
using System.Collections.Generic;
using Jadcup.Services.Model.CustomerModel;
using Jadcup.Services.Model.EmployeeModel;
using Jadcup.Services.Model.QuotationItemModel;
using Jadcup.Services.Model.QuotationOptionModel;

namespace Jadcup.Services.Model.QuotationModel
{
    public class GetQuotationDto
    {
        public string QuotationId { get; set; }
        public ulong? Draft { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? EffDate { get; set; }
        public DateTime? ExpDate { get; set; }
        public int? EmployeeId { get; set; }
        public string QuotationNo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Notes { get; set; }
        public DateTime? CustConfimedAt { get; set; }
        public ulong? CustConfirmed { get; set; }        

        public GetCustomerDto2 Customer { get; set; }
        public GetEmployeeDto2 Employee { get; set; }
        public List<GetQuotationItemDto2> QuotationItem { get; set; }
        public List<GetQuotationOptionDto> QuotationOption { get; set; }

    }
}