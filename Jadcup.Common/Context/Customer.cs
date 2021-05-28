using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Customer
    {
        public Customer()
        {
            Attachment = new HashSet<Attachment>();
            ExtraAddress = new HashSet<ExtraAddress>();
            Invoice = new HashSet<Invoice>();
            OnlineUser = new HashSet<OnlineUser>();
            Orders = new HashSet<Orders>();
            Product = new HashSet<Product>();
            Quotation = new HashSet<Quotation>();
            SalesVisitPlan = new HashSet<SalesVisitPlan>();
            Ticket = new HashSet<Ticket>();
        }

        public int CustomerId { get; set; }
        public string Company { get; set; }
        public string ContactPerson { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public short? Group1Id { get; set; }
        public short? Group2Id { get; set; }
        public short? Group3Id { get; set; }
        public short? Group4Id { get; set; }
        public short? Group5Id { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? EmployeeId { get; set; }
        public short? BrandId { get; set; }
        public short? CityId { get; set; }
        public string Salutation { get; set; }
        public short LeadRating { get; set; }
        public short? SourceId { get; set; }
        public string PostalCode { get; set; }
        public string CustomerCode { get; set; }
        public short? StatusId { get; set; }
        public short? PaymentCycleId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public short? DeliveryMethodId { get; set; }
        public string CustomerNo { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual City City { get; set; }
        public virtual DeliveryMethod DeliveryMethod { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual CustomerGrp1 Group1 { get; set; }
        public virtual CustomerGrp2 Group2 { get; set; }
        public virtual CustomerGrp3 Group3 { get; set; }
        public virtual CustomerGrp4 Group4 { get; set; }
        public virtual CustomerGrp5 Group5 { get; set; }
        public virtual PaymentCycle PaymentCycle { get; set; }
        public virtual CustomerSource Source { get; set; }
        public virtual CustomerStatus Status { get; set; }
        public virtual CustomerCredit CustomerCredit { get; set; }
        public virtual ICollection<Attachment> Attachment { get; set; }
        public virtual ICollection<ExtraAddress> ExtraAddress { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<OnlineUser> OnlineUser { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Quotation> Quotation { get; set; }
        public virtual ICollection<SalesVisitPlan> SalesVisitPlan { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
