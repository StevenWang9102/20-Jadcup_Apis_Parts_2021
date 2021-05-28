using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Employee
    {
        public Employee()
        {
            Accessment = new HashSet<Accessment>();
            Attachment = new HashSet<Attachment>();
            Customer = new HashSet<Customer>();
            DailyReport = new HashSet<DailyReport>();
            InspectionLog = new HashSet<InspectionLog>();
            Notification = new HashSet<Notification>();
            OperateLog = new HashSet<OperateLog>();
            Orders = new HashSet<Orders>();
            PurchaseOrder = new HashSet<PurchaseOrder>();
            Quotation = new HashSet<Quotation>();
            RawMaterialApplicationApplyEmployee = new HashSet<RawMaterialApplication>();
            RawMaterialApplicationWarehouseEmployee = new HashSet<RawMaterialApplication>();
            ReturnItemOperEmployee = new HashSet<ReturnItem>();
            ReturnItemSalesEmployee = new HashSet<ReturnItem>();
            SalesVisitPlan = new HashSet<SalesVisitPlan>();
            StockLog = new HashSet<StockLog>();
            SuborderLog = new HashSet<SuborderLog>();
            Ticket = new HashSet<Ticket>();
            TicketProcess = new HashSet<TicketProcess>();
            WorkOrder = new HashSet<WorkOrder>();
            WorkingArrangementCreatedByNavigation = new HashSet<WorkingArrangement>();
            WorkingArrangementOperatorNavigation = new HashSet<WorkingArrangement>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public ulong? Active { get; set; }
        public ulong IsSales { get; set; }
        public short? DeptId { get; set; }
        public short? RoleId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public virtual Dept Dept { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Accessment> Accessment { get; set; }
        public virtual ICollection<Attachment> Attachment { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<DailyReport> DailyReport { get; set; }
        public virtual ICollection<InspectionLog> InspectionLog { get; set; }
        public virtual ICollection<Notification> Notification { get; set; }
        public virtual ICollection<OperateLog> OperateLog { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual ICollection<Quotation> Quotation { get; set; }
        public virtual ICollection<RawMaterialApplication> RawMaterialApplicationApplyEmployee { get; set; }
        public virtual ICollection<RawMaterialApplication> RawMaterialApplicationWarehouseEmployee { get; set; }
        public virtual ICollection<ReturnItem> ReturnItemOperEmployee { get; set; }
        public virtual ICollection<ReturnItem> ReturnItemSalesEmployee { get; set; }
        public virtual ICollection<SalesVisitPlan> SalesVisitPlan { get; set; }
        public virtual ICollection<StockLog> StockLog { get; set; }
        public virtual ICollection<SuborderLog> SuborderLog { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
        public virtual ICollection<TicketProcess> TicketProcess { get; set; }
        public virtual ICollection<WorkOrder> WorkOrder { get; set; }
        public virtual ICollection<WorkingArrangement> WorkingArrangementCreatedByNavigation { get; set; }
        public virtual ICollection<WorkingArrangement> WorkingArrangementOperatorNavigation { get; set; }
    }
}
