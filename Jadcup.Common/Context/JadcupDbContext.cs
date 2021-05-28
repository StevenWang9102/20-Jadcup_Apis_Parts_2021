using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Jadcup.Common.Context
{
    public partial class JadcupDbContext : DbContext
    {
        public JadcupDbContext()
        {
        }

        public JadcupDbContext(DbContextOptions<JadcupDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accessment> Accessment { get; set; }
        public virtual DbSet<AccessmentDetail> AccessmentDetail { get; set; }
        public virtual DbSet<AccessmentPlan> AccessmentPlan { get; set; }
        public virtual DbSet<AccessmentStandards> AccessmentStandards { get; set; }
        public virtual DbSet<AccessmentStandardsDetail> AccessmentStandardsDetail { get; set; }
        public virtual DbSet<Action> Action { get; set; }
        public virtual DbSet<ApplicationDetails> ApplicationDetails { get; set; }
        public virtual DbSet<AttachedRecord> AttachedRecord { get; set; }
        public virtual DbSet<Attachment> Attachment { get; set; }
        public virtual DbSet<BaseProduct> BaseProduct { get; set; }
        public virtual DbSet<Box> Box { get; set; }
        public virtual DbSet<BoxStatus> BoxStatus { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Cell> Cell { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<ContractType> ContractType { get; set; }
        public virtual DbSet<Courier> Courier { get; set; }
        public virtual DbSet<CreditTransaction> CreditTransaction { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerCredit> CustomerCredit { get; set; }
        public virtual DbSet<CustomerGrp1> CustomerGrp1 { get; set; }
        public virtual DbSet<CustomerGrp2> CustomerGrp2 { get; set; }
        public virtual DbSet<CustomerGrp3> CustomerGrp3 { get; set; }
        public virtual DbSet<CustomerGrp4> CustomerGrp4 { get; set; }
        public virtual DbSet<CustomerGrp5> CustomerGrp5 { get; set; }
        public virtual DbSet<CustomerSource> CustomerSource { get; set; }
        public virtual DbSet<CustomerStatus> CustomerStatus { get; set; }
        public virtual DbSet<DailyReport> DailyReport { get; set; }
        public virtual DbSet<DeliveryMethod> DeliveryMethod { get; set; }
        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<Dispatching> Dispatching { get; set; }
        public virtual DbSet<DispatchingDetails> DispatchingDetails { get; set; }
        public virtual DbSet<DispatchingStatus> DispatchingStatus { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<ExtraAddress> ExtraAddress { get; set; }
        public virtual DbSet<HumanResource> HumanResource { get; set; }
        public virtual DbSet<InspectionLog> InspectionLog { get; set; }
        public virtual DbSet<InspectionPlan> InspectionPlan { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItem { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Machine> Machine { get; set; }
        public virtual DbSet<MachineType> MachineType { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<OnlineUser> OnlineUser { get; set; }
        public virtual DbSet<OperateLog> OperateLog { get; set; }
        public virtual DbSet<OrderOption> OrderOption { get; set; }
        public virtual DbSet<OrderProduct> OrderProduct { get; set; }
        public virtual DbSet<OrderSource> OrderSource { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<OrderType> OrderType { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PackagingType> PackagingType { get; set; }
        public virtual DbSet<Page> Page { get; set; }
        public virtual DbSet<PageGroup> PageGroup { get; set; }
        public virtual DbSet<PalletStacking> PalletStacking { get; set; }
        public virtual DbSet<Parameter> Parameter { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentCycle> PaymentCycle { get; set; }
        public virtual DbSet<Plate> Plate { get; set; }
        public virtual DbSet<PlateBox> PlateBox { get; set; }
        public virtual DbSet<PlateType> PlateType { get; set; }
        public virtual DbSet<PoDetail> PoDetail { get; set; }
        public virtual DbSet<PoStatus> PoStatus { get; set; }
        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductMachineMapping> ProductMachineMapping { get; set; }
        public virtual DbSet<ProductOption> ProductOption { get; set; }
        public virtual DbSet<ProductPrice> ProductPrice { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<ProductTypeAction> ProductTypeAction { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<Qualification> Qualification { get; set; }
        public virtual DbSet<Quarter> Quarter { get; set; }
        public virtual DbSet<Quotation> Quotation { get; set; }
        public virtual DbSet<QuotationItem> QuotationItem { get; set; }
        public virtual DbSet<QuotationOption> QuotationOption { get; set; }
        public virtual DbSet<QuotationOptionItem> QuotationOptionItem { get; set; }
        public virtual DbSet<RawMaterial> RawMaterial { get; set; }
        public virtual DbSet<RawMaterialApplication> RawMaterialApplication { get; set; }
        public virtual DbSet<RawMaterialBox> RawMaterialBox { get; set; }
        public virtual DbSet<RecordType> RecordType { get; set; }
        public virtual DbSet<ReturnItem> ReturnItem { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePageMapping> RolePageMapping { get; set; }
        public virtual DbSet<SalaryFactor> SalaryFactor { get; set; }
        public virtual DbSet<SalesVisitPlan> SalesVisitPlan { get; set; }
        public virtual DbSet<Shelf> Shelf { get; set; }
        public virtual DbSet<ShelfPlate> ShelfPlate { get; set; }
        public virtual DbSet<Standard> Standard { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<StockLog> StockLog { get; set; }
        public virtual DbSet<Suborder> Suborder { get; set; }
        public virtual DbSet<SuborderLog> SuborderLog { get; set; }
        public virtual DbSet<SuborderStatus> SuborderStatus { get; set; }
        public virtual DbSet<Suplier> Suplier { get; set; }
        public virtual DbSet<SuplierRawMaterial> SuplierRawMaterial { get; set; }
        public virtual DbSet<TempZone> TempZone { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<TicketProcess> TicketProcess { get; set; }
        public virtual DbSet<TicketType> TicketType { get; set; }
        public virtual DbSet<TransactionType> TransactionType { get; set; }
        public virtual DbSet<UnloadingInspection> UnloadingInspection { get; set; }
        public virtual DbSet<WorkOrder> WorkOrder { get; set; }
        public virtual DbSet<WorkOrderSource> WorkOrderSource { get; set; }
        public virtual DbSet<WorkOrderStatus> WorkOrderStatus { get; set; }
        public virtual DbSet<WorkingArrangement> WorkingArrangement { get; set; }
        public virtual DbSet<Zone> Zone { get; set; }
        public virtual DbSet<ZoneType> ZoneType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=206.189.39.185;port=3306;user=dbuser;password=MI4m481OuUJ1D9KijI921KFMRFHndvNi;database=jadcup", x => x.ServerVersion("5.7.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accessment>(entity =>
            {
                entity.ToTable("accessment");

                entity.HasIndex(e => e.AcceStandardId)
                    .HasName("R_203");

                entity.HasIndex(e => e.AccessmentPlanId)
                    .HasName("R_201");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("R_207");

                entity.Property(e => e.AccessmentId)
                    .HasColumnName("accessment_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AcceStandardId)
                    .HasColumnName("acce_standard_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AccessmentPlanId)
                    .HasColumnName("accessment_plan_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Item)
                    .HasColumnName("item")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.TotalMarks)
                    .HasColumnName("total_marks")
                    .HasColumnType("decimal(6,2)");

                entity.HasOne(d => d.AcceStandard)
                    .WithMany(p => p.Accessment)
                    .HasForeignKey(d => d.AcceStandardId)
                    .HasConstraintName("accessment_ibfk_2");

                entity.HasOne(d => d.AccessmentPlan)
                    .WithMany(p => p.Accessment)
                    .HasForeignKey(d => d.AccessmentPlanId)
                    .HasConstraintName("accessment_ibfk_1");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Accessment)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("accessment_ibfk_3");
            });

            modelBuilder.Entity<AccessmentDetail>(entity =>
            {
                entity.ToTable("accessment_detail");

                entity.HasIndex(e => e.AcceStandDetailId)
                    .HasName("R_206");

                entity.HasIndex(e => e.AccessmentId)
                    .HasName("R_204");

                entity.Property(e => e.AccessmentDetailId)
                    .HasColumnName("accessment_detail_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AcceStandDetailId)
                    .HasColumnName("acce_stand_detail_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AccessmentId)
                    .HasColumnName("accessment_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.AcceStandDetail)
                    .WithMany(p => p.AccessmentDetail)
                    .HasForeignKey(d => d.AcceStandDetailId)
                    .HasConstraintName("accessment_detail_ibfk_2");

                entity.HasOne(d => d.Accessment)
                    .WithMany(p => p.AccessmentDetail)
                    .HasForeignKey(d => d.AccessmentId)
                    .HasConstraintName("accessment_detail_ibfk_1");
            });

            modelBuilder.Entity<AccessmentPlan>(entity =>
            {
                entity.ToTable("accessment_plan");

                entity.Property(e => e.AccessmentPlanId)
                    .HasColumnName("accessment_plan_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<AccessmentStandards>(entity =>
            {
                entity.HasKey(e => e.AcceStandardId)
                    .HasName("PRIMARY");

                entity.ToTable("accessment_standards");

                entity.Property(e => e.AcceStandardId)
                    .HasColumnName("acce_standard_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<AccessmentStandardsDetail>(entity =>
            {
                entity.HasKey(e => e.AcceStandDetailId)
                    .HasName("PRIMARY");

                entity.ToTable("accessment_standards_detail");

                entity.HasIndex(e => e.AcceStandardId)
                    .HasName("R_205");

                entity.Property(e => e.AcceStandDetailId)
                    .HasColumnName("acce_stand_detail_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AcceStandardId)
                    .HasColumnName("acce_standard_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Item)
                    .HasColumnName("item")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Max)
                    .HasColumnName("max")
                    .HasColumnType("decimal(4,2)");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.AcceStandard)
                    .WithMany(p => p.AccessmentStandardsDetail)
                    .HasForeignKey(d => d.AcceStandardId)
                    .HasConstraintName("accessment_standards_detail_ibfk_1");
            });

            modelBuilder.Entity<Action>(entity =>
            {
                entity.ToTable("action");

                entity.Property(e => e.ActionId)
                    .HasColumnName("action_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ActionName)
                    .HasColumnName("action_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<ApplicationDetails>(entity =>
            {
                entity.HasKey(e => e.DetailsId)
                    .HasName("PRIMARY");

                entity.ToTable("application_details");

                entity.HasIndex(e => e.ApplicationId)
                    .HasName("R_132");

                entity.HasIndex(e => e.RawMaterialBoxId)
                    .HasName("R_133");

                entity.Property(e => e.DetailsId)
                    .HasColumnName("details_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ApplicationId)
                    .HasColumnName("application_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.RawMaterialBoxId)
                    .HasColumnName("raw_material_box_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Runout)
                    .HasColumnName("runout")
                    .HasColumnType("bit(1)");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ApplicationDetails)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("application_details_ibfk_1");

                entity.HasOne(d => d.RawMaterialBox)
                    .WithMany(p => p.ApplicationDetails)
                    .HasForeignKey(d => d.RawMaterialBoxId)
                    .HasConstraintName("application_details_ibfk_2");
            });

            modelBuilder.Entity<AttachedRecord>(entity =>
            {
                entity.HasKey(e => e.AttachedId)
                    .HasName("PRIMARY");

                entity.ToTable("attached_record");

                entity.HasIndex(e => e.RecordTypeId)
                    .HasName("R_196");

                entity.HasIndex(e => e.ResouceId)
                    .HasName("R_122");

                entity.Property(e => e.AttachedId)
                    .HasColumnName("attached_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordTypeId)
                    .HasColumnName("record_type_id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.ResouceId)
                    .HasColumnName("resouce_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.RecordType)
                    .WithMany(p => p.AttachedRecord)
                    .HasForeignKey(d => d.RecordTypeId)
                    .HasConstraintName("attached_record_ibfk_2");

                entity.HasOne(d => d.Resouce)
                    .WithMany(p => p.AttachedRecord)
                    .HasForeignKey(d => d.ResouceId)
                    .HasConstraintName("attached_record_ibfk_1");
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.ToTable("attachment");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("R_28");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("R_29");

                entity.Property(e => e.AttachmentId)
                    .HasColumnName("attachment_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AttachmentDesc)
                    .HasColumnName("attachment_desc")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AttachmentName)
                    .HasColumnName("attachment_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Urls)
                    .HasColumnName("urls")
                    .HasColumnType("varchar(3000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Attachment)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("attachment_ibfk_1");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Attachment)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("attachment_ibfk_2");
            });

            modelBuilder.Entity<BaseProduct>(entity =>
            {
                entity.ToTable("base_product");

                entity.HasIndex(e => e.PackagingTypeId)
                    .HasName("R_178");

                entity.HasIndex(e => e.ProductTypeId)
                    .HasName("R_17");

                entity.HasIndex(e => e.RawMaterialId)
                    .HasName("R_105");

                entity.HasIndex(e => e.RawMaterialId2)
                    .HasName("R_193");

                entity.Property(e => e.BaseProductId)
                    .HasColumnName("base_product_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.AmountPerSheet)
                    .HasColumnName("amount_per_sheet")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.BaseProductName)
                    .HasColumnName("base_product_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Manufactured)
                    .HasColumnName("manufactured")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.PackagingTypeId)
                    .HasColumnName("packaging_type_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("product_code")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductTypeId)
                    .HasColumnName("product_type_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.RawMaterialId)
                    .HasColumnName("raw_material_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.RawMaterialId2)
                    .HasColumnName("raw_material_id2")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.RawmaterialDesc)
                    .HasColumnName("rawmaterial_desc")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.PackagingType)
                    .WithMany(p => p.BaseProduct)
                    .HasForeignKey(d => d.PackagingTypeId)
                    .HasConstraintName("base_product_ibfk_3");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.BaseProduct)
                    .HasForeignKey(d => d.ProductTypeId)
                    .HasConstraintName("base_product_ibfk_1");

                entity.HasOne(d => d.RawMaterial)
                    .WithMany(p => p.BaseProductRawMaterial)
                    .HasForeignKey(d => d.RawMaterialId)
                    .HasConstraintName("base_product_ibfk_2");

                entity.HasOne(d => d.RawMaterialId2Navigation)
                    .WithMany(p => p.BaseProductRawMaterialId2Navigation)
                    .HasForeignKey(d => d.RawMaterialId2)
                    .HasConstraintName("base_product_ibfk_4");
            });

            modelBuilder.Entity<Box>(entity =>
            {
                entity.ToTable("box");

                entity.HasIndex(e => e.InspectionId)
                    .HasName("R_177");

                entity.HasIndex(e => e.ProductId)
                    .HasName("R_125");

                entity.HasIndex(e => e.Status)
                    .HasName("R_149");

                entity.HasIndex(e => e.SuborderId)
                    .HasName("R_42");

                entity.HasIndex(e => e.TicketId)
                    .HasName("R_181");

                entity.Property(e => e.BoxId)
                    .HasColumnName("box_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BarCode)
                    .HasColumnName("bar_code")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.InspectionId)
                    .HasColumnName("inspection_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsSemi)
                    .HasColumnName("is_semi")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.SuborderId)
                    .HasColumnName("suborder_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TicketId)
                    .HasColumnName("ticket_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Inspection)
                    .WithMany(p => p.Box)
                    .HasForeignKey(d => d.InspectionId)
                    .HasConstraintName("box_ibfk_4");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Box)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("box_ibfk_2");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Box)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("box_ibfk_3");

                entity.HasOne(d => d.Suborder)
                    .WithMany(p => p.Box)
                    .HasForeignKey(d => d.SuborderId)
                    .HasConstraintName("box_ibfk_1");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Box)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("box_ibfk_5");
            });

            modelBuilder.Entity<BoxStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PRIMARY");

                entity.ToTable("box_status");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.BoxStatusName)
                    .HasColumnName("box_status_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brand");

                entity.Property(e => e.BrandId)
                    .HasColumnName("brand_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.BrandName)
                    .HasColumnName("brand_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Cell>(entity =>
            {
                entity.ToTable("cell");

                entity.HasIndex(e => e.ShelfId)
                    .HasName("R_49");

                entity.Property(e => e.CellId)
                    .HasColumnName("cell_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.ColNo)
                    .HasColumnName("col_no")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.RowNo)
                    .HasColumnName("row_no")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ShelfId)
                    .HasColumnName("shelf_id")
                    .HasColumnType("smallint(6)");

                entity.HasOne(d => d.Shelf)
                    .WithMany(p => p.Cell)
                    .HasForeignKey(d => d.ShelfId)
                    .HasConstraintName("cell_ibfk_1");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.CityId)
                    .HasColumnName("city_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.CityName)
                    .HasColumnName("city_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("contract");

                entity.HasIndex(e => e.ContractTypeId)
                    .HasName("R_198");

                entity.HasIndex(e => e.ResouceId)
                    .HasName("R_123");

                entity.Property(e => e.ContractId)
                    .HasColumnName("contract_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ContractDesc)
                    .HasColumnName("contract_desc")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContractTypeId)
                    .HasColumnName("contract_type_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.EffDate)
                    .HasColumnName("eff_date")
                    .HasColumnType("date");

                entity.Property(e => e.ExpDate)
                    .HasColumnName("exp_date")
                    .HasColumnType("date");

                entity.Property(e => e.ResouceId)
                    .HasColumnName("resouce_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TrialDate)
                    .HasColumnName("trial_date")
                    .HasColumnType("date");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.ContractType)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.ContractTypeId)
                    .HasConstraintName("contract_ibfk_2");

                entity.HasOne(d => d.Resouce)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.ResouceId)
                    .HasConstraintName("contract_ibfk_1");
            });

            modelBuilder.Entity<ContractType>(entity =>
            {
                entity.ToTable("contract_type");

                entity.Property(e => e.ContractTypeId)
                    .HasColumnName("contract_type_id")
                    .HasColumnType("smallint(6)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ContractTypeName)
                    .HasColumnName("contract_type_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Courier>(entity =>
            {
                entity.ToTable("courier");

                entity.Property(e => e.CourierId)
                    .HasColumnName("courier_id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.CourierName)
                    .HasColumnName("courier_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<CreditTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PRIMARY");

                entity.ToTable("credit_transaction");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("R_184");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("R_112");

                entity.HasIndex(e => e.TicketId)
                    .HasName("R_180");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("transaction_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TicketId)
                    .HasColumnName("ticket_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CreditTransaction)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("credit_transaction_ibfk_3");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.CreditTransaction)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("credit_transaction_ibfk_1");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.CreditTransaction)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("credit_transaction_ibfk_2");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.BrandId)
                    .HasName("R_14");

                entity.HasIndex(e => e.CityId)
                    .HasName("R_15");

                entity.HasIndex(e => e.DeliveryMethodId)
                    .HasName("R_126");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("R_13");

                entity.HasIndex(e => e.Group1Id)
                    .HasName("R_7");

                entity.HasIndex(e => e.Group2Id)
                    .HasName("R_8");

                entity.HasIndex(e => e.Group3Id)
                    .HasName("R_9");

                entity.HasIndex(e => e.Group4Id)
                    .HasName("R_10");

                entity.HasIndex(e => e.Group5Id)
                    .HasName("R_11");

                entity.HasIndex(e => e.PaymentCycleId)
                    .HasName("R_100");

                entity.HasIndex(e => e.SourceId)
                    .HasName("R_31");

                entity.HasIndex(e => e.StatusId)
                    .HasName("R_99");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address1)
                    .HasColumnName("address1")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Address2)
                    .HasColumnName("address2")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BrandId)
                    .HasColumnName("brand_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.CityId)
                    .HasColumnName("city_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("contact_person")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerCode)
                    .HasColumnName("customer_code")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CustomerNo)
                    .HasColumnName("customer_no")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DeliveryMethodId)
                    .HasColumnName("delivery_method_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Group1Id)
                    .HasColumnName("group1_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Group2Id)
                    .HasColumnName("group2_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Group3Id)
                    .HasColumnName("group3_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Group4Id)
                    .HasColumnName("group4_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Group5Id)
                    .HasColumnName("group5_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.LeadRating)
                    .HasColumnName("lead_rating")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PaymentCycleId)
                    .HasColumnName("payment_cycle_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Salutation)
                    .HasColumnName("salutation")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SourceId)
                    .HasColumnName("source_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("customer_ibfk_12");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("customer_ibfk_8");

                entity.HasOne(d => d.DeliveryMethod)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.DeliveryMethodId)
                    .HasConstraintName("customer_ibfk_13");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("customer_ibfk_6");

                entity.HasOne(d => d.Group1)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.Group1Id)
                    .HasConstraintName("customer_ibfk_1");

                entity.HasOne(d => d.Group2)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.Group2Id)
                    .HasConstraintName("customer_ibfk_2");

                entity.HasOne(d => d.Group3)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.Group3Id)
                    .HasConstraintName("customer_ibfk_3");

                entity.HasOne(d => d.Group4)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.Group4Id)
                    .HasConstraintName("customer_ibfk_4");

                entity.HasOne(d => d.Group5)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.Group5Id)
                    .HasConstraintName("customer_ibfk_5");

                entity.HasOne(d => d.PaymentCycle)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.PaymentCycleId)
                    .HasConstraintName("customer_ibfk_11");

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.SourceId)
                    .HasConstraintName("customer_ibfk_9");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("customer_ibfk_10");
            });

            modelBuilder.Entity<CustomerCredit>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PRIMARY");

                entity.ToTable("customer_credit");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Credit)
                    .HasColumnName("credit")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.CustomerCredit)
                    .HasForeignKey<CustomerCredit>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer_credit_ibfk_1");
            });

            modelBuilder.Entity<CustomerGrp1>(entity =>
            {
                entity.HasKey(e => e.Group1Id)
                    .HasName("PRIMARY");

                entity.ToTable("customer_grp1");

                entity.Property(e => e.Group1Id)
                    .HasColumnName("group1_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Group1Name)
                    .HasColumnName("group1_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<CustomerGrp2>(entity =>
            {
                entity.HasKey(e => e.Group2Id)
                    .HasName("PRIMARY");

                entity.ToTable("customer_grp2");

                entity.Property(e => e.Group2Id)
                    .HasColumnName("group2_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Group2Name)
                    .HasColumnName("group2_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<CustomerGrp3>(entity =>
            {
                entity.HasKey(e => e.Group3Id)
                    .HasName("PRIMARY");

                entity.ToTable("customer_grp3");

                entity.Property(e => e.Group3Id)
                    .HasColumnName("group3_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Group3Name)
                    .HasColumnName("group3_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<CustomerGrp4>(entity =>
            {
                entity.HasKey(e => e.Group4Id)
                    .HasName("PRIMARY");

                entity.ToTable("customer_grp4");

                entity.Property(e => e.Group4Id)
                    .HasColumnName("group4_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Group4Name)
                    .HasColumnName("group4_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<CustomerGrp5>(entity =>
            {
                entity.HasKey(e => e.Group5Id)
                    .HasName("PRIMARY");

                entity.ToTable("customer_grp5");

                entity.Property(e => e.Group5Id)
                    .HasColumnName("group5_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Group5Name)
                    .HasColumnName("group5_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<CustomerSource>(entity =>
            {
                entity.HasKey(e => e.SourceId)
                    .HasName("PRIMARY");

                entity.ToTable("customer_source");

                entity.Property(e => e.SourceId)
                    .HasColumnName("source_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.SourceName)
                    .HasColumnName("source_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<CustomerStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PRIMARY");

                entity.ToTable("customer_status");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.StatusName)
                    .HasColumnName("status_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<DailyReport>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PRIMARY");

                entity.ToTable("daily_report");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("R_189");

                entity.HasIndex(e => e.MachineId)
                    .HasName("R_190");

                entity.Property(e => e.ReportId)
                    .HasColumnName("report_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("date");

                entity.Property(e => e.DailyReportId)
                    .HasColumnName("daily_report_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Loss)
                    .HasColumnName("loss")
                    .HasColumnType("decimal(6,2)");

                entity.Property(e => e.MachineId)
                    .HasColumnName("machine_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.DailyReport)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("daily_report_ibfk_1");

                entity.HasOne(d => d.Machine)
                    .WithMany(p => p.DailyReport)
                    .HasForeignKey(d => d.MachineId)
                    .HasConstraintName("daily_report_ibfk_2");
            });

            modelBuilder.Entity<DeliveryMethod>(entity =>
            {
                entity.ToTable("delivery_method");

                entity.Property(e => e.DeliveryMethodId)
                    .HasColumnName("delivery_method_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.DeliveryMethodName)
                    .HasColumnName("delivery_method_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.ToTable("dept");

                entity.HasIndex(e => e.AcceStandardId)
                    .HasName("R_202");

                entity.Property(e => e.DeptId)
                    .HasColumnName("dept_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.AcceStandardId)
                    .HasColumnName("acce_standard_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DeptName)
                    .HasColumnName("dept_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.AcceStandard)
                    .WithMany(p => p.Dept)
                    .HasForeignKey(d => d.AcceStandardId)
                    .HasConstraintName("dept_ibfk_1");
            });

            modelBuilder.Entity<Dispatching>(entity =>
            {
                entity.HasKey(e => e.DispatchId)
                    .HasName("PRIMARY");

                entity.ToTable("dispatching");

                entity.HasIndex(e => e.CourierId)
                    .HasName("R_90");

                entity.HasIndex(e => e.OrderId)
                    .HasName("R_89");

                entity.HasIndex(e => e.Status)
                    .HasName("R_159");

                entity.Property(e => e.DispatchId)
                    .HasColumnName("dispatch_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CourierId)
                    .HasColumnName("courier_id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeliveredAt)
                    .HasColumnName("delivered_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SourceType)
                    .HasColumnName("source_type")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.TrackingNo)
                    .HasColumnName("tracking_no")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Courier)
                    .WithMany(p => p.Dispatching)
                    .HasForeignKey(d => d.CourierId)
                    .HasConstraintName("dispatching_ibfk_2");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Dispatching)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("dispatching_ibfk_1");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Dispatching)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("dispatching_ibfk_3");
            });

            modelBuilder.Entity<DispatchingDetails>(entity =>
            {
                entity.HasKey(e => e.DetailId)
                    .HasName("PRIMARY");

                entity.ToTable("dispatching_details");

                entity.HasIndex(e => e.BoxId)
                    .HasName("R_92");

                entity.HasIndex(e => e.DispatchId)
                    .HasName("R_91");

                entity.HasIndex(e => e.ProductId)
                    .HasName("R_98");

                entity.Property(e => e.DetailId)
                    .HasColumnName("detail_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BoxId)
                    .HasColumnName("box_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DispatchId)
                    .HasColumnName("dispatch_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsWhole)
                    .HasColumnName("is_whole")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Box)
                    .WithMany(p => p.DispatchingDetails)
                    .HasForeignKey(d => d.BoxId)
                    .HasConstraintName("dispatching_details_ibfk_2");

                entity.HasOne(d => d.Dispatch)
                    .WithMany(p => p.DispatchingDetails)
                    .HasForeignKey(d => d.DispatchId)
                    .HasConstraintName("dispatching_details_ibfk_1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.DispatchingDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("dispatching_details_ibfk_3");
            });

            modelBuilder.Entity<DispatchingStatus>(entity =>
            {
                entity.HasKey(e => e.Status)
                    .HasName("PRIMARY");

                entity.ToTable("dispatching_status");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.StatusName)
                    .HasColumnName("status_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasIndex(e => e.DeptId)
                    .HasName("R_1");

                entity.HasIndex(e => e.RoleId)
                    .HasName("R_2");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeptId)
                    .HasColumnName("dept_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsSales)
                    .HasColumnName("is_sales")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(80)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Salt)
                    .HasColumnName("salt")
                    .HasColumnType("varchar(16)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserName)
                    .HasColumnName("user_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("employee_ibfk_1");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("employee_ibfk_2");
            });

            modelBuilder.Entity<ExtraAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PRIMARY");

                entity.ToTable("extra_address");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("R_160");

                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ExtraAddress)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("extra_address_ibfk_1");
            });

            modelBuilder.Entity<HumanResource>(entity =>
            {
                entity.HasKey(e => e.ResouceId)
                    .HasName("PRIMARY");

                entity.ToTable("human_resource");

                entity.Property(e => e.ResouceId)
                    .HasColumnName("resouce_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EntryDate)
                    .HasColumnName("entry_date")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(4)");
            });

            modelBuilder.Entity<InspectionLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PRIMARY");

                entity.ToTable("inspection_log");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("R_72");

                entity.HasIndex(e => e.MachineId)
                    .HasName("R_154");

                entity.HasIndex(e => e.PlanId)
                    .HasName("R_71");

                entity.Property(e => e.LogId)
                    .HasColumnName("log_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InspectTime)
                    .HasColumnName("inspect_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogDate)
                    .HasColumnName("log_date")
                    .HasColumnType("date");

                entity.Property(e => e.LogTime)
                    .HasColumnName("log_time")
                    .HasColumnType("time");

                entity.Property(e => e.MachineId)
                    .HasColumnName("machine_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Passed)
                    .HasColumnName("passed")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.PlanId)
                    .HasColumnName("plan_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.InspectionLog)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("inspection_log_ibfk_2");

                entity.HasOne(d => d.Machine)
                    .WithMany(p => p.InspectionLog)
                    .HasForeignKey(d => d.MachineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("inspection_log_ibfk_3");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.InspectionLog)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("inspection_log_ibfk_1");
            });

            modelBuilder.Entity<InspectionPlan>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PRIMARY");

                entity.ToTable("inspection_plan");

                entity.HasIndex(e => e.MachineId)
                    .HasName("R_69");

                entity.HasIndex(e => e.StandardId)
                    .HasName("R_70");

                entity.Property(e => e.PlanId)
                    .HasColumnName("plan_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("time");

                entity.Property(e => e.MachineId)
                    .HasColumnName("machine_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Periodicity)
                    .HasColumnName("periodicity")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.StandardId)
                    .HasColumnName("standard_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("time");

                entity.HasOne(d => d.Machine)
                    .WithMany(p => p.InspectionPlan)
                    .HasForeignKey(d => d.MachineId)
                    .HasConstraintName("inspection_plan_ibfk_1");

                entity.HasOne(d => d.Standard)
                    .WithMany(p => p.InspectionPlan)
                    .HasForeignKey(d => d.StandardId)
                    .HasConstraintName("inspection_plan_ibfk_2");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoice");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("invoice_customer_customer_id_fk");

                entity.HasIndex(e => e.OrderId)
                    .HasName("R_74");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Credit)
                    .HasColumnName("credit")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Emailed)
                    .HasColumnName("emailed")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoice_date")
                    .HasColumnType("date");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoice_no")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Paid)
                    .HasColumnName("paid")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.PriceInclcredit)
                    .HasColumnName("price_inclcredit")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.PriceInclgst)
                    .HasColumnName("price_inclgst")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("total_price")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("invoice_customer_customer_id_fk");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("invoice_ibfk_1");
            });

            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                entity.ToTable("invoice_item");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("R_75");

                entity.HasIndex(e => e.OptionId)
                    .HasName("R_183");

                entity.HasIndex(e => e.ProductId)
                    .HasName("R_76");

                entity.Property(e => e.InvoiceItemId)
                    .HasColumnName("invoice_item_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OptionId)
                    .HasColumnName("option_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("total_price")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("unit_price")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceItem)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("invoice_item_ibfk_1");

                entity.HasOne(d => d.Option)
                    .WithMany(p => p.InvoiceItem)
                    .HasForeignKey(d => d.OptionId)
                    .HasConstraintName("invoice_item_ibfk_3");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InvoiceItem)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("invoice_item_ibfk_2");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item");

                entity.HasIndex(e => e.ProductId)
                    .HasName("R_65");

                entity.HasIndex(e => e.RawMaterialId)
                    .HasName("R_64");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.IsSemi)
                    .HasColumnName("is_semi")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.ItemType)
                    .HasColumnName("item_type")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.RawMaterialId)
                    .HasColumnName("raw_material_id")
                    .HasColumnType("smallint(6)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("item_ibfk_2");
            });

            modelBuilder.Entity<Machine>(entity =>
            {
                entity.ToTable("machine");

                entity.HasIndex(e => e.MachineTypeId)
                    .HasName("R_173");

                entity.Property(e => e.MachineId)
                    .HasColumnName("machine_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.MachineName)
                    .HasColumnName("machine_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MachineTypeId)
                    .HasColumnName("machine_type_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Picture)
                    .HasColumnName("picture")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SortingOrder)
                    .HasColumnName("sorting_order")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(4)");

                entity.HasOne(d => d.MachineType)
                    .WithMany(p => p.Machine)
                    .HasForeignKey(d => d.MachineTypeId)
                    .HasConstraintName("machine_ibfk_1");
            });

            modelBuilder.Entity<MachineType>(entity =>
            {
                entity.ToTable("machine_type");

                entity.Property(e => e.MachineTypeId)
                    .HasColumnName("machine_type_id")
                    .HasColumnType("smallint(6)")
                    .ValueGeneratedNever();

                entity.Property(e => e.MachineTypeName)
                    .HasColumnName("machine_type_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("notification");

                entity.HasIndex(e => e.CreaterId)
                    .HasName("R_208");

                entity.HasIndex(e => e.RoleId)
                    .HasName("role_id");

                entity.Property(e => e.NotificationId)
                    .HasColumnName("notification_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreaterId)
                    .HasColumnName("creater_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.NotificationContext)
                    .IsRequired()
                    .HasColumnName("notification_context")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Creater)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.CreaterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("notification_ibfk_2");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("notification_ibfk_1");
            });

            modelBuilder.Entity<OnlineUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("online_user");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("R_12");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Salt)
                    .HasColumnName("salt")
                    .HasColumnType("varchar(16)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserName)
                    .HasColumnName("user_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OnlineUser)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("online_user_ibfk_1");
            });

            modelBuilder.Entity<OperateLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PRIMARY");

                entity.ToTable("operate_log");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("R_188");

                entity.HasIndex(e => e.OrderId)
                    .HasName("R_187");

                entity.HasIndex(e => e.QuotationId)
                    .HasName("R_185");

                entity.Property(e => e.LogId)
                    .HasColumnName("log_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.QuotationId)
                    .HasColumnName("quotation_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.OperateLog)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("operate_log_ibfk_3");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OperateLog)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("operate_log_ibfk_2");

                entity.HasOne(d => d.Quotation)
                    .WithMany(p => p.OperateLog)
                    .HasForeignKey(d => d.QuotationId)
                    .HasConstraintName("operate_log_ibfk_1");
            });

            modelBuilder.Entity<OrderOption>(entity =>
            {
                entity.ToTable("order_option");

                entity.HasIndex(e => e.OptionId)
                    .HasName("R_170");

                entity.HasIndex(e => e.OrderId)
                    .HasName("R_169");

                entity.Property(e => e.OrderOptionId)
                    .HasColumnName("order_option_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OptionId)
                    .HasColumnName("option_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("unit_price")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.Option)
                    .WithMany(p => p.OrderOption)
                    .HasForeignKey(d => d.OptionId)
                    .HasConstraintName("order_option_ibfk_2");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderOption)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("order_option_ibfk_1");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.ToTable("order_product");

                entity.HasIndex(e => e.OrderId)
                    .HasName("R_33");

                entity.HasIndex(e => e.ProductId)
                    .HasName("R_34");

                entity.Property(e => e.OrderProductId)
                    .HasColumnName("order_product_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Delivered)
                    .HasColumnName("delivered")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.DeliveredQuantity)
                    .HasColumnName("delivered_quantity")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MarginOfError)
                    .HasColumnName("margin_of_error")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("unit_price")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProduct)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("order_product_ibfk_1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderProduct)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("order_product_ibfk_2");
            });

            modelBuilder.Entity<OrderSource>(entity =>
            {
                entity.ToTable("order_source");

                entity.Property(e => e.OrderSourceId)
                    .HasColumnName("order_source_id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.OrderSourceName)
                    .HasColumnName("order_source_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("order_status");

                entity.Property(e => e.OrderStatusId)
                    .HasColumnName("order_status_id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.OrderStatusName)
                    .HasColumnName("order_status_name")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<OrderType>(entity =>
            {
                entity.ToTable("order_type");

                entity.Property(e => e.OrderTypeId)
                    .HasColumnName("order_type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OrderTypeName)
                    .HasColumnName("order_type_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PRIMARY");

                entity.ToTable("orders");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("R_30");

                entity.HasIndex(e => e.DeliveryCityId)
                    .HasName("R_93");

                entity.HasIndex(e => e.DeliveryMethodId)
                    .HasName("R_106");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("R_107");

                entity.HasIndex(e => e.OrderSourceId)
                    .HasName("R_164");

                entity.HasIndex(e => e.OrderStatusId)
                    .HasName("orders_order_status_order_status_id_fk");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DeliveryAddress)
                    .HasColumnName("delivery_address")
                    .HasColumnType("varchar(400)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DeliveryAsap)
                    .HasColumnName("delivery_asap")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.DeliveryCityId)
                    .HasColumnName("delivery_city_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnName("delivery_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeliveryMethodId)
                    .HasColumnName("delivery_method_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.DeliveryName)
                    .HasColumnName("delivery_name")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("order_no")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrderSourceId)
                    .HasColumnName("order_source_id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.OrderStatusId)
                    .HasColumnName("order_status_id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Paid)
                    .HasColumnName("paid")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PriceInclgst)
                    .HasColumnName("price_inclgst")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.RequiredDate)
                    .HasColumnName("required_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("total_price")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("orders_ibfk_1");

                entity.HasOne(d => d.DeliveryCity)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DeliveryCityId)
                    .HasConstraintName("orders_ibfk_3");

                entity.HasOne(d => d.DeliveryMethod)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DeliveryMethodId)
                    .HasConstraintName("orders_ibfk_5");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("orders_ibfk_2");

                entity.HasOne(d => d.OrderSource)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderSourceId)
                    .HasConstraintName("orders_ibfk_6");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .HasConstraintName("orders_order_status_order_status_id_fk");
            });

            modelBuilder.Entity<PackagingType>(entity =>
            {
                entity.ToTable("packaging_type");

                entity.Property(e => e.PackagingTypeId)
                    .HasColumnName("packaging_type_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.PackagingTypeName)
                    .HasColumnName("packaging_type_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.SleevePkt)
                    .HasColumnName("sleeve_pkt")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.SleeveQty)
                    .HasColumnName("sleeve_qty")
                    .HasColumnType("smallint(6)");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.ToTable("page");

                entity.HasIndex(e => e.GroupId)
                    .HasName("R_4");

                entity.Property(e => e.PageId)
                    .HasColumnName("page_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.GroupId)
                    .HasColumnName("group_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.PageName)
                    .HasColumnName("page_name")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PageUrl)
                    .HasColumnName("page_url")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SortingOrder)
                    .HasColumnName("sorting_order")
                    .HasColumnType("smallint(6)");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Page)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("page_ibfk_1");
            });

            modelBuilder.Entity<PageGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("PRIMARY");

                entity.ToTable("page_group");

                entity.Property(e => e.GroupId)
                    .HasColumnName("group_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.GroupName)
                    .HasColumnName("group_name")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SortingOrder)
                    .HasColumnName("sorting_order")
                    .HasColumnType("smallint(6)");
            });

            modelBuilder.Entity<PalletStacking>(entity =>
            {
                entity.ToTable("pallet_stacking");

                entity.Property(e => e.PalletStackingId)
                    .HasColumnName("pallet_stacking_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.LayoutImage)
                    .HasColumnName("layout_image")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PalletStackingName)
                    .HasColumnName("pallet_stacking_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Parameter>(entity =>
            {
                entity.HasKey(e => e.ParaId)
                    .HasName("PRIMARY");

                entity.ToTable("parameter");

                entity.Property(e => e.ParaId)
                    .HasColumnName("para_id")
                    .HasColumnType("smallint(6)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ParaName)
                    .HasColumnName("para_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("decimal(10,2)");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("R_158");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("payment_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("date");

                entity.Property(e => e.AmountSettlement)
                    .HasColumnName("amountSettlement")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CardHolderName)
                    .HasColumnName("cardHolderName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CardId)
                    .HasColumnName("cardId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CardName)
                    .HasColumnName("cardName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CardNumber)
                    .HasColumnName("cardNumber")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ClientInfo)
                    .HasColumnName("clientInfo")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CurrencyInput)
                    .HasColumnName("currencyInput")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CurrencySettlement)
                    .HasColumnName("currencySettlement")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateExpiry)
                    .HasColumnName("dateExpiry")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PaymentMethod)
                    .HasColumnName("payment_method")
                    .HasColumnType("date");

                entity.Property(e => e.ResponseText)
                    .HasColumnName("responseText")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Success)
                    .HasColumnName("success")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TxnId)
                    .HasColumnName("txnId")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TxnMac)
                    .HasColumnName("txnMac")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("payment_ibfk_1");
            });

            modelBuilder.Entity<PaymentCycle>(entity =>
            {
                entity.ToTable("payment_cycle");

                entity.Property(e => e.PaymentCycleId)
                    .HasColumnName("payment_cycle_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.PaymentCycleName)
                    .HasColumnName("payment_cycle_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Plate>(entity =>
            {
                entity.ToTable("plate");

                entity.HasIndex(e => e.PlateTypeId)
                    .HasName("R_146");

                entity.Property(e => e.PlateId)
                    .HasColumnName("plate_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Package)
                    .HasColumnName("package")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.PlateCode)
                    .HasColumnName("plate_code")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PlateTypeId)
                    .HasColumnName("plate_type_id")
                    .HasColumnType("smallint(6)");

                entity.HasOne(d => d.PlateType)
                    .WithMany(p => p.Plate)
                    .HasForeignKey(d => d.PlateTypeId)
                    .HasConstraintName("plate_ibfk_1");
            });

            modelBuilder.Entity<PlateBox>(entity =>
            {
                entity.ToTable("plate_box");

                entity.HasIndex(e => e.BoxId)
                    .HasName("R_53");

                entity.HasIndex(e => e.PlateId)
                    .HasName("R_52");

                entity.HasIndex(e => e.RawMaterialBoxId)
                    .HasName("R_136");

                entity.Property(e => e.PlateBoxId)
                    .HasColumnName("plate_box_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.BoxId)
                    .HasColumnName("box_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.PlateId)
                    .HasColumnName("plate_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.RawMaterialBoxId)
                    .HasColumnName("raw_material_box_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Box)
                    .WithMany(p => p.PlateBox)
                    .HasForeignKey(d => d.BoxId)
                    .HasConstraintName("plate_box_ibfk_2");

                entity.HasOne(d => d.Plate)
                    .WithMany(p => p.PlateBox)
                    .HasForeignKey(d => d.PlateId)
                    .HasConstraintName("plate_box_ibfk_1");

                entity.HasOne(d => d.RawMaterialBox)
                    .WithMany(p => p.PlateBox)
                    .HasForeignKey(d => d.RawMaterialBoxId)
                    .HasConstraintName("plate_box_ibfk_3");
            });

            modelBuilder.Entity<PlateType>(entity =>
            {
                entity.ToTable("plate_type");

                entity.Property(e => e.PlateTypeId)
                    .HasColumnName("plate_type_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.PlateTypeName)
                    .HasColumnName("plate_type_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<PoDetail>(entity =>
            {
                entity.ToTable("po_detail");

                entity.HasIndex(e => e.PoId)
                    .HasName("R_164");

                entity.HasIndex(e => e.RawMaterialId)
                    .HasName("R_165");

                entity.Property(e => e.PoDetailId)
                    .HasColumnName("po_detail_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Completed)
                    .HasColumnName("completed")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.PoId)
                    .HasColumnName("po_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RawMaterialId)
                    .HasColumnName("raw_material_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("unit_price")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.Po)
                    .WithMany(p => p.PoDetail)
                    .HasForeignKey(d => d.PoId)
                    .HasConstraintName("po_detail_ibfk_1");

                entity.HasOne(d => d.RawMaterial)
                    .WithMany(p => p.PoDetail)
                    .HasForeignKey(d => d.RawMaterialId)
                    .HasConstraintName("po_detail_ibfk_2");
            });

            modelBuilder.Entity<PoStatus>(entity =>
            {
                entity.ToTable("po_status");

                entity.Property(e => e.PoStatusId)
                    .HasColumnName("po_status_id")
                    .HasColumnType("smallint(6)")
                    .ValueGeneratedNever();

                entity.Property(e => e.PoStatusName)
                    .HasColumnName("po_status_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("price");

                entity.HasIndex(e => e.BaseProductId)
                    .HasName("R_23");

                entity.HasIndex(e => e.Group1Id)
                    .HasName("R_24");

                entity.Property(e => e.PriceId)
                    .HasColumnName("price_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.BaseProductId)
                    .HasColumnName("base_product_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Group1Id)
                    .HasColumnName("group1_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.MinPrice)
                    .HasColumnName("min_price")
                    .HasColumnType("decimal(5,2)");

                entity.HasOne(d => d.BaseProduct)
                    .WithMany(p => p.Price)
                    .HasForeignKey(d => d.BaseProductId)
                    .HasConstraintName("price_ibfk_1");

                entity.HasOne(d => d.Group1)
                    .WithMany(p => p.Price)
                    .HasForeignKey(d => d.Group1Id)
                    .HasConstraintName("price_ibfk_2");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.BaseProductId)
                    .HasName("R_16");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("R_18");

                entity.HasIndex(e => e.PalletStackingId)
                    .HasName("R_179");

                entity.HasIndex(e => e.PlateTypeId)
                    .HasName("R_50");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.BaseProductId)
                    .HasColumnName("base_product_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Images)
                    .HasColumnName("images")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LogoType)
                    .HasColumnName("logo_type")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.LogoUrl)
                    .HasColumnName("logo_url")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Manufactured)
                    .HasColumnName("manufactured")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.MarginOfError)
                    .HasColumnName("margin_of_error")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.MinOrderQuantity)
                    .HasColumnName("min_order_quantity")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.PalletStackingId)
                    .HasColumnName("pallet_stacking_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Plain)
                    .HasColumnName("plain")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.PlateTypeId)
                    .HasColumnName("plate_type_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("product_code")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductMsl)
                    .HasColumnName("product_msl")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ProductName)
                    .HasColumnName("product_name")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SemiMsl)
                    .HasColumnName("semi_msl")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.BaseProduct)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.BaseProductId)
                    .HasConstraintName("product_ibfk_1");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("product_ibfk_2");

                entity.HasOne(d => d.PalletStacking)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.PalletStackingId)
                    .HasConstraintName("product_ibfk_4");

                entity.HasOne(d => d.PlateType)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.PlateTypeId)
                    .HasConstraintName("product_ibfk_3");
            });

            modelBuilder.Entity<ProductMachineMapping>(entity =>
            {
                entity.HasKey(e => e.MappingId)
                    .HasName("PRIMARY");

                entity.ToTable("product_machine_mapping");

                entity.HasIndex(e => e.ActionId)
                    .HasName("R_168");

                entity.HasIndex(e => e.BaseProductId)
                    .HasName("R_167");

                entity.HasIndex(e => e.MachineId)
                    .HasName("R_166");

                entity.Property(e => e.MappingId)
                    .HasColumnName("mapping_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ActionId)
                    .HasColumnName("action_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.BaseProductId)
                    .HasColumnName("base_product_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.MachineId)
                    .HasColumnName("machine_id")
                    .HasColumnType("smallint(6)");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.ProductMachineMapping)
                    .HasForeignKey(d => d.ActionId)
                    .HasConstraintName("product_machine_mapping_ibfk_3");

                entity.HasOne(d => d.BaseProduct)
                    .WithMany(p => p.ProductMachineMapping)
                    .HasForeignKey(d => d.BaseProductId)
                    .HasConstraintName("product_machine_mapping_ibfk_2");

                entity.HasOne(d => d.Machine)
                    .WithMany(p => p.ProductMachineMapping)
                    .HasForeignKey(d => d.MachineId)
                    .HasConstraintName("product_machine_mapping_ibfk_1");
            });

            modelBuilder.Entity<ProductOption>(entity =>
            {
                entity.HasKey(e => e.OptionId)
                    .HasName("PRIMARY");

                entity.ToTable("product_option");

                entity.Property(e => e.OptionId)
                    .HasColumnName("option_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.OptionName)
                    .HasColumnName("option_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(8,2)");
            });

            modelBuilder.Entity<ProductPrice>(entity =>
            {
                entity.ToTable("product_price");

                entity.HasIndex(e => e.BaseProductId)
                    .HasName("R_192");

                entity.HasIndex(e => e.Group1Id)
                    .HasName("R_209");

                entity.Property(e => e.ProductPriceId)
                    .HasColumnName("product_price_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BaseProductId)
                    .HasColumnName("base_product_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Group1Id)
                    .HasColumnName("group1_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(8,3)");

                entity.Property(e => e.Quantiy)
                    .HasColumnName("quantiy")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.BaseProduct)
                    .WithMany(p => p.ProductPrice)
                    .HasForeignKey(d => d.BaseProductId)
                    .HasConstraintName("product_price_ibfk_1");

                entity.HasOne(d => d.Group1)
                    .WithMany(p => p.ProductPrice)
                    .HasForeignKey(d => d.Group1Id)
                    .HasConstraintName("product_price_ibfk_2");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("product_type");

                entity.Property(e => e.ProductTypeId)
                    .HasColumnName("product_type_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ProductTypeName)
                    .HasColumnName("product_type_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<ProductTypeAction>(entity =>
            {
                entity.ToTable("product_type_action");

                entity.HasIndex(e => e.ActionId)
                    .HasName("R_48");

                entity.HasIndex(e => e.OrderTypeId)
                    .HasName("R_118");

                entity.HasIndex(e => e.ProductTypeId)
                    .HasName("R_47");

                entity.Property(e => e.ProductTypeActionId)
                    .HasColumnName("product_type_action_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ActionId)
                    .HasColumnName("action_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.OrderTypeId)
                    .HasColumnName("order_type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductTypeId)
                    .HasColumnName("product_type_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.SequenceNo)
                    .HasColumnName("sequence_no")
                    .HasColumnType("tinyint(4)");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.ProductTypeAction)
                    .HasForeignKey(d => d.ActionId)
                    .HasConstraintName("product_type_action_ibfk_2");

                entity.HasOne(d => d.OrderType)
                    .WithMany(p => p.ProductTypeAction)
                    .HasForeignKey(d => d.OrderTypeId)
                    .HasConstraintName("product_type_action_ibfk_3");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.ProductTypeAction)
                    .HasForeignKey(d => d.ProductTypeId)
                    .HasConstraintName("product_type_action_ibfk_1");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.PoId)
                    .HasName("PRIMARY");

                entity.ToTable("purchase_order");

                entity.HasIndex(e => e.CreatedEmployeeId)
                    .HasName("R_56");

                entity.HasIndex(e => e.PoStatusId)
                    .HasName("R_174");

                entity.HasIndex(e => e.SuplierId)
                    .HasName("R_59");

                entity.Property(e => e.PoId)
                    .HasColumnName("po_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedEmployeeId)
                    .HasColumnName("created_employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PoNo)
                    .HasColumnName("po_no")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PoStatusId)
                    .HasColumnName("po_status_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.SuplierId)
                    .HasColumnName("suplier_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CreatedEmployee)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.CreatedEmployeeId)
                    .HasConstraintName("purchase_order_ibfk_1");

                entity.HasOne(d => d.PoStatus)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.PoStatusId)
                    .HasConstraintName("purchase_order_ibfk_3");

                entity.HasOne(d => d.Suplier)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.SuplierId)
                    .HasConstraintName("purchase_order_ibfk_2");
            });

            modelBuilder.Entity<Qualification>(entity =>
            {
                entity.ToTable("qualification");

                entity.HasIndex(e => e.SuplierId)
                    .HasName("R_57");

                entity.Property(e => e.QualificationId)
                    .HasColumnName("qualification_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.ExpDate)
                    .HasColumnName("exp_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.QualificationName)
                    .HasColumnName("qualification_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.QualificationUrls)
                    .HasColumnName("qualification_urls")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SuplierId)
                    .HasColumnName("suplier_id")
                    .HasColumnType("smallint(6)");

                entity.HasOne(d => d.Suplier)
                    .WithMany(p => p.Qualification)
                    .HasForeignKey(d => d.SuplierId)
                    .HasConstraintName("qualification_ibfk_1");
            });

            modelBuilder.Entity<Quarter>(entity =>
            {
                entity.ToTable("quarter");

                entity.Property(e => e.QuarterId)
                    .HasColumnName("quarter_id")
                    .HasColumnType("smallint(6)")
                    .ValueGeneratedNever();

                entity.Property(e => e.QuarterName)
                    .HasColumnName("quarter_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Quotation>(entity =>
            {
                entity.ToTable("quotation");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("R_21");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("R_25");

                entity.Property(e => e.QuotationId)
                    .HasColumnName("quotation_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustConfimedAt)
                    .HasColumnName("cust_confimed_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustConfirmed)
                    .HasColumnName("cust_confirmed")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Draft)
                    .HasColumnName("draft")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.EffDate)
                    .HasColumnName("eff_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExpDate)
                    .HasColumnName("exp_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("varchar(300)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.QuotationNo)
                    .HasColumnName("quotation_no")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Quotation)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("quotation_ibfk_1");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Quotation)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("quotation_ibfk_2");
            });

            modelBuilder.Entity<QuotationItem>(entity =>
            {
                entity.ToTable("quotation_item");

                entity.HasIndex(e => e.BaseProductId)
                    .HasName("R_101");

                entity.HasIndex(e => e.ProductId)
                    .HasName("R_20");

                entity.HasIndex(e => e.QuotationId)
                    .HasName("R_103");

                entity.Property(e => e.QuotationItemId)
                    .HasColumnName("quotation_item_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BaseProductId)
                    .HasColumnName("base_product_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.CartonPrice)
                    .HasColumnName("carton_price")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.IsLowerPrice)
                    .HasColumnName("is_lower_price")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.ItemDesc)
                    .HasColumnName("item_desc")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Notes2)
                    .HasColumnName("notes2")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OriginPrice)
                    .HasColumnName("origin_price")
                    .HasColumnType("decimal(8,3)");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(8,3)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.QuotationId)
                    .HasColumnName("quotation_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.BaseProduct)
                    .WithMany(p => p.QuotationItem)
                    .HasForeignKey(d => d.BaseProductId)
                    .HasConstraintName("quotation_item_ibfk_2");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.QuotationItem)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("quotation_item_ibfk_1");

                entity.HasOne(d => d.Quotation)
                    .WithMany(p => p.QuotationItem)
                    .HasForeignKey(d => d.QuotationId)
                    .HasConstraintName("quotation_item_ibfk_3");
            });

            modelBuilder.Entity<QuotationOption>(entity =>
            {
                entity.HasKey(e => e.OptionId)
                    .HasName("PRIMARY");

                entity.ToTable("quotation_option");

                entity.HasIndex(e => e.QuotationId)
                    .HasName("R_26");

                entity.HasIndex(e => e.QuotationOptionItemId)
                    .HasName("R_27");

                entity.Property(e => e.OptionId)
                    .HasColumnName("option_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CustomizeOptionNotes)
                    .HasColumnName("customize_option_notes")
                    .HasColumnType("varchar(400)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.QuotationId)
                    .HasColumnName("quotation_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.QuotationOptionItemId)
                    .HasColumnName("quotation_option_item_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Quotation)
                    .WithMany(p => p.QuotationOption)
                    .HasForeignKey(d => d.QuotationId)
                    .HasConstraintName("quotation_option_ibfk_1");

                entity.HasOne(d => d.QuotationOptionItem)
                    .WithMany(p => p.QuotationOption)
                    .HasForeignKey(d => d.QuotationOptionItemId)
                    .HasConstraintName("quotation_option_ibfk_2");
            });

            modelBuilder.Entity<QuotationOptionItem>(entity =>
            {
                entity.ToTable("quotation_option_item");

                entity.Property(e => e.QuotationOptionItemId)
                    .HasColumnName("quotation_option_item_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuotationOptionItemName)
                    .HasColumnName("quotation_option_item_name")
                    .HasColumnType("varchar(400)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<RawMaterial>(entity =>
            {
                entity.ToTable("raw_material");

                entity.Property(e => e.RawMaterialId)
                    .HasColumnName("raw_material_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.AlarmLimit)
                    .HasColumnName("alarm_limit")
                    .HasColumnType("decimal(14,2)");

                entity.Property(e => e.RawMaterialCode)
                    .HasColumnName("raw_material_code")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RawMaterialName)
                    .HasColumnName("raw_material_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<RawMaterialApplication>(entity =>
            {
                entity.HasKey(e => e.ApplicationId)
                    .HasName("PRIMARY");

                entity.ToTable("raw_material_application");

                entity.HasIndex(e => e.ApplyEmployeeId)
                    .HasName("R_127");

                entity.HasIndex(e => e.RawMaterialId)
                    .HasName("R_129");

                entity.HasIndex(e => e.WarehouseEmployeeId)
                    .HasName("R_128");

                entity.Property(e => e.ApplicationId)
                    .HasColumnName("application_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.AppliedAt)
                    .HasColumnName("applied_at")
                    .HasColumnType("date");

                entity.Property(e => e.ApplyEmployeeId)
                    .HasColumnName("apply_employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApplyQuantity)
                    .HasColumnName("apply_quantity")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Processed)
                    .HasColumnName("processed")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.ProcessedAt)
                    .HasColumnName("processed_at")
                    .HasColumnType("date");

                entity.Property(e => e.RawMaterialId)
                    .HasColumnName("raw_material_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ReceivedAt)
                    .HasColumnName("received_at")
                    .HasColumnType("date");

                entity.Property(e => e.RecievedQuantity)
                    .HasColumnName("recieved_quantity")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.WarehouseEmployeeId)
                    .HasColumnName("warehouse_employee_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.ApplyEmployee)
                    .WithMany(p => p.RawMaterialApplicationApplyEmployee)
                    .HasForeignKey(d => d.ApplyEmployeeId)
                    .HasConstraintName("raw_material_application_ibfk_1");

                entity.HasOne(d => d.RawMaterial)
                    .WithMany(p => p.RawMaterialApplication)
                    .HasForeignKey(d => d.RawMaterialId)
                    .HasConstraintName("raw_material_application_ibfk_3");

                entity.HasOne(d => d.WarehouseEmployee)
                    .WithMany(p => p.RawMaterialApplicationWarehouseEmployee)
                    .HasForeignKey(d => d.WarehouseEmployeeId)
                    .HasConstraintName("raw_material_application_ibfk_2");
            });

            modelBuilder.Entity<RawMaterialBox>(entity =>
            {
                entity.ToTable("raw_material_box");

                entity.HasIndex(e => e.InspectionId)
                    .HasName("R_130");

                entity.HasIndex(e => e.RawMaterialId)
                    .HasName("R_148");

                entity.Property(e => e.RawMaterialBoxId)
                    .HasColumnName("raw_material_box_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.BoxCode)
                    .HasColumnName("box_code")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.InspectionId)
                    .HasColumnName("inspection_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.RawMaterialId)
                    .HasColumnName("raw_material_id")
                    .HasColumnType("smallint(6)");

                entity.HasOne(d => d.Inspection)
                    .WithMany(p => p.RawMaterialBox)
                    .HasForeignKey(d => d.InspectionId)
                    .HasConstraintName("raw_material_box_ibfk_1");

                entity.HasOne(d => d.RawMaterial)
                    .WithMany(p => p.RawMaterialBox)
                    .HasForeignKey(d => d.RawMaterialId)
                    .HasConstraintName("raw_material_box_ibfk_2");
            });

            modelBuilder.Entity<RecordType>(entity =>
            {
                entity.ToTable("record_type");

                entity.Property(e => e.RecordTypeId)
                    .HasColumnName("record_type_id")
                    .HasColumnType("tinyint(4)")
                    .ValueGeneratedNever();

                entity.Property(e => e.RecordTypeName)
                    .HasColumnName("record_type_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<ReturnItem>(entity =>
            {
                entity.HasKey(e => e.ReturnedItemId)
                    .HasName("PRIMARY");

                entity.ToTable("return_item");

                entity.HasIndex(e => e.OperEmployeeId)
                    .HasName("R_85");

                entity.HasIndex(e => e.ProductId)
                    .HasName("R_83");

                entity.HasIndex(e => e.SalesEmployeeId)
                    .HasName("R_87");

                entity.HasIndex(e => e.TicketId)
                    .HasName("R_86");

                entity.Property(e => e.ReturnedItemId)
                    .HasColumnName("returned_item_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BoxQty)
                    .HasColumnName("box_qty")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.OperEmployeeId)
                    .HasColumnName("oper_employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Processed)
                    .HasColumnName("processed")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.QuantityPerBox)
                    .HasColumnName("quantity_per_box")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.SalesEmployeeId)
                    .HasColumnName("sales_employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TicketId)
                    .HasColumnName("ticket_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.OperEmployee)
                    .WithMany(p => p.ReturnItemOperEmployee)
                    .HasForeignKey(d => d.OperEmployeeId)
                    .HasConstraintName("return_item_ibfk_2");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ReturnItem)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("return_item_ibfk_1");

                entity.HasOne(d => d.SalesEmployee)
                    .WithMany(p => p.ReturnItemSalesEmployee)
                    .HasForeignKey(d => d.SalesEmployeeId)
                    .HasConstraintName("return_item_ibfk_4");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.ReturnItem)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("return_item_ibfk_3");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.RoleName)
                    .HasColumnName("role_name")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<RolePageMapping>(entity =>
            {
                entity.HasKey(e => e.MappingId)
                    .HasName("PRIMARY");

                entity.ToTable("role_page_mapping");

                entity.HasIndex(e => e.PageId)
                    .HasName("R_6");

                entity.HasIndex(e => e.RoleId)
                    .HasName("R_5");

                entity.Property(e => e.MappingId)
                    .HasColumnName("mapping_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.PageId)
                    .HasColumnName("page_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("smallint(6)");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.RolePageMapping)
                    .HasForeignKey(d => d.PageId)
                    .HasConstraintName("role_page_mapping_ibfk_2");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePageMapping)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("role_page_mapping_ibfk_1");
            });

            modelBuilder.Entity<SalaryFactor>(entity =>
            {
                entity.HasKey(e => e.ResouceId)
                    .HasName("PRIMARY");

                entity.ToTable("salary_factor");

                entity.HasIndex(e => e.QuarterId)
                    .HasName("R_147");

                entity.Property(e => e.ResouceId)
                    .HasColumnName("resouce_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BaseSalary)
                    .HasColumnName("base_salary")
                    .HasColumnType("decimal(6,2)");

                entity.Property(e => e.Bonus)
                    .HasColumnName("bonus")
                    .HasColumnType("decimal(6,2)");

                entity.Property(e => e.BonusRate)
                    .HasColumnName("bonus_rate")
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.Facter1)
                    .HasColumnName("facter1")
                    .HasColumnType("decimal(6,2)");

                entity.Property(e => e.Facter2)
                    .HasColumnName("facter2")
                    .HasColumnType("decimal(6,2)");

                entity.Property(e => e.Facter3)
                    .HasColumnName("facter3")
                    .HasColumnType("decimal(6,2)");

                entity.Property(e => e.Facter4)
                    .HasColumnName("facter4")
                    .HasColumnType("decimal(6,2)");

                entity.Property(e => e.Facter5)
                    .HasColumnName("facter5")
                    .HasColumnType("decimal(6,2)");

                entity.Property(e => e.QuarterId)
                    .HasColumnName("quarter_id")
                    .HasColumnType("smallint(6)");

                entity.HasOne(d => d.Quarter)
                    .WithMany(p => p.SalaryFactor)
                    .HasForeignKey(d => d.QuarterId)
                    .HasConstraintName("salary_factor_ibfk_2");

                entity.HasOne(d => d.Resouce)
                    .WithOne(p => p.SalaryFactor)
                    .HasForeignKey<SalaryFactor>(d => d.ResouceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("salary_factor_ibfk_1");
            });

            modelBuilder.Entity<SalesVisitPlan>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PRIMARY");

                entity.ToTable("sales_visit_plan");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("R_120");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("R_119");

                entity.Property(e => e.PlanId)
                    .HasColumnName("plan_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("date");

                entity.Property(e => e.Completed)
                    .HasColumnName("completed")
                    .HasColumnType("date");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NextVisitTime)
                    .HasColumnName("next_visit_time")
                    .HasColumnType("date");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("date");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SalesVisitPlan)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("sales_visit_plan_ibfk_2");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.SalesVisitPlan)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("sales_visit_plan_ibfk_1");
            });

            modelBuilder.Entity<Shelf>(entity =>
            {
                entity.ToTable("shelf");

                entity.HasIndex(e => e.ZoneId)
                    .HasName("shelf_ibfk_1");

                entity.Property(e => e.ShelfId)
                    .HasColumnName("shelf_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ShelfCode)
                    .HasColumnName("shelf_code")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TotalCols)
                    .HasColumnName("total_cols")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.TotalRows)
                    .HasColumnName("total_rows")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ZoneId)
                    .HasColumnName("zone_id")
                    .HasColumnType("tinyint(4)");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.Shelf)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName("shelf_ibfk_1");
            });

            modelBuilder.Entity<ShelfPlate>(entity =>
            {
                entity.ToTable("shelf_plate");

                entity.HasIndex(e => e.CellId)
                    .HasName("R_54");

                entity.HasIndex(e => e.PlateId)
                    .HasName("R_55");

                entity.Property(e => e.ShelfPlateId)
                    .HasColumnName("shelf_plate_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.CellId)
                    .HasColumnName("cell_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.PlateId)
                    .HasColumnName("plate_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Cell)
                    .WithMany(p => p.ShelfPlate)
                    .HasForeignKey(d => d.CellId)
                    .HasConstraintName("shelf_plate_ibfk_1");

                entity.HasOne(d => d.Plate)
                    .WithMany(p => p.ShelfPlate)
                    .HasForeignKey(d => d.PlateId)
                    .HasConstraintName("shelf_plate_ibfk_2");
            });

            modelBuilder.Entity<Standard>(entity =>
            {
                entity.ToTable("standard");

                entity.Property(e => e.StandardId)
                    .HasColumnName("standard_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.StandardContent)
                    .HasColumnName("standard_content")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("stock");

                entity.HasIndex(e => e.ItemId)
                    .HasName("uidx_item")
                    .IsUnique();

                entity.Property(e => e.StockId)
                    .HasColumnName("stock_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.Item)
                    .WithOne(p => p.Stock)
                    .HasForeignKey<Stock>(d => d.ItemId)
                    .HasConstraintName("stock_ibfk_1");
            });

            modelBuilder.Entity<StockLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PRIMARY");

                entity.ToTable("stock_log");

                entity.HasIndex(e => e.BoxId)
                    .HasName("stock_log_ibfk_8");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("R_67");

                entity.HasIndex(e => e.RawMaterialBoxId)
                    .HasName("stock_log_ibfk_9");

                entity.HasIndex(e => e.StockId)
                    .HasName("R_66");

                entity.HasIndex(e => e.TransactionTypeId)
                    .HasName("R_78");

                entity.Property(e => e.LogId)
                    .HasColumnName("log_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BoxId)
                    .HasColumnName("box_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.RawMaterialBoxId)
                    .HasColumnName("raw_material_box_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StockId)
                    .HasColumnName("stock_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.TransactionTypeId)
                    .HasColumnName("transaction_type_id")
                    .HasColumnType("smallint(6)");

                entity.HasOne(d => d.Box)
                    .WithMany(p => p.StockLog)
                    .HasForeignKey(d => d.BoxId)
                    .HasConstraintName("stock_log_ibfk_8");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.StockLog)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("stock_log_ibfk_2");

                entity.HasOne(d => d.RawMaterialBox)
                    .WithMany(p => p.StockLog)
                    .HasForeignKey(d => d.RawMaterialBoxId)
                    .HasConstraintName("stock_log_ibfk_9");

                entity.HasOne(d => d.Stock)
                    .WithMany(p => p.StockLog)
                    .HasForeignKey(d => d.StockId)
                    .HasConstraintName("stock_log_ibfk_7");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.StockLog)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .HasConstraintName("stock_log_ibfk_3");
            });

            modelBuilder.Entity<Suborder>(entity =>
            {
                entity.ToTable("suborder");

                entity.HasIndex(e => e.ActionId)
                    .HasName("R_44");

                entity.HasIndex(e => e.SuborderStatusId)
                    .HasName("suborder_ibfk_4_idx");

                entity.HasIndex(e => e.WorkOrderId)
                    .HasName("R_38");

                entity.Property(e => e.SuborderId)
                    .HasColumnName("suborder_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ActionId)
                    .HasColumnName("action_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CompletedDate)
                    .HasColumnName("completed_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CompletedQuanity)
                    .HasColumnName("completed_quanity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrginalQuantity)
                    .HasColumnName("orginal_quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReceivedQuantity)
                    .HasColumnName("received_quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SequenceNo)
                    .HasColumnName("sequence_no")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.SuborderStatusId)
                    .HasColumnName("suborder_status_id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.WorkOrderId)
                    .HasColumnName("work_order_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.Suborder)
                    .HasForeignKey(d => d.ActionId)
                    .HasConstraintName("suborder_ibfk_3");

                entity.HasOne(d => d.SuborderStatus)
                    .WithMany(p => p.Suborder)
                    .HasForeignKey(d => d.SuborderStatusId)
                    .HasConstraintName("suborder_ibfk_4");

                entity.HasOne(d => d.WorkOrder)
                    .WithMany(p => p.Suborder)
                    .HasForeignKey(d => d.WorkOrderId)
                    .HasConstraintName("suborder_ibfk_1");
            });

            modelBuilder.Entity<SuborderLog>(entity =>
            {
                entity.ToTable("suborder_log");

                entity.HasIndex(e => e.BoxId)
                    .HasName("R_176");

                entity.HasIndex(e => e.MachineId)
                    .HasName("R_143");

                entity.HasIndex(e => e.OperEmployeeId)
                    .HasName("R_41");

                entity.HasIndex(e => e.RawMaterialBoxId)
                    .HasName("R_142");

                entity.HasIndex(e => e.RawMaterialBoxId2)
                    .HasName("R_197");

                entity.HasIndex(e => e.SuborderId)
                    .HasName("R_40");

                entity.Property(e => e.SuborderLogId)
                    .HasColumnName("suborder_log_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BoxId)
                    .HasColumnName("box_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.MachineId)
                    .HasColumnName("machine_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.OperEmployeeId)
                    .HasColumnName("oper_employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RawMaterialBoxId)
                    .HasColumnName("raw_material_box_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RawMaterialBoxId2)
                    .HasColumnName("raw_material_box_id2")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SuborderId)
                    .HasColumnName("suborder_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Box)
                    .WithMany(p => p.SuborderLog)
                    .HasForeignKey(d => d.BoxId)
                    .HasConstraintName("suborder_log_ibfk_6");

                entity.HasOne(d => d.Machine)
                    .WithMany(p => p.SuborderLog)
                    .HasForeignKey(d => d.MachineId)
                    .HasConstraintName("suborder_log_ibfk_4");

                entity.HasOne(d => d.OperEmployee)
                    .WithMany(p => p.SuborderLog)
                    .HasForeignKey(d => d.OperEmployeeId)
                    .HasConstraintName("suborder_log_ibfk_2");

                entity.HasOne(d => d.RawMaterialBox)
                    .WithMany(p => p.SuborderLogRawMaterialBox)
                    .HasForeignKey(d => d.RawMaterialBoxId)
                    .HasConstraintName("suborder_log_ibfk_3");

                entity.HasOne(d => d.RawMaterialBoxId2Navigation)
                    .WithMany(p => p.SuborderLogRawMaterialBoxId2Navigation)
                    .HasForeignKey(d => d.RawMaterialBoxId2)
                    .HasConstraintName("suborder_log_ibfk_7");

                entity.HasOne(d => d.Suborder)
                    .WithMany(p => p.SuborderLog)
                    .HasForeignKey(d => d.SuborderId)
                    .HasConstraintName("suborder_log_ibfk_1");
            });

            modelBuilder.Entity<SuborderStatus>(entity =>
            {
                entity.ToTable("suborder_status");

                entity.Property(e => e.SuborderStatusId)
                    .HasColumnName("suborder_status_id")
                    .HasColumnType("tinyint(4)")
                    .ValueGeneratedNever();

                entity.Property(e => e.SuborderStatusName)
                    .HasColumnName("suborder_status_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Suplier>(entity =>
            {
                entity.ToTable("suplier");

                entity.Property(e => e.SuplierId)
                    .HasColumnName("suplier_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(300)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SuplierName)
                    .HasColumnName("suplier_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SuplierType)
                    .HasColumnName("suplier_type")
                    .HasColumnType("tinyint(4)");
            });

            modelBuilder.Entity<SuplierRawMaterial>(entity =>
            {
                entity.ToTable("suplier_raw_material");

                entity.HasIndex(e => e.RawMaterialId)
                    .HasName("R_108");

                entity.HasIndex(e => e.SuplierId)
                    .HasName("R_109");

                entity.Property(e => e.SuplierRawMaterialId)
                    .HasColumnName("suplier_raw_material_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RawMaterialId)
                    .HasColumnName("raw_material_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.SuplierId)
                    .HasColumnName("suplier_id")
                    .HasColumnType("smallint(6)");

                entity.HasOne(d => d.RawMaterial)
                    .WithMany(p => p.SuplierRawMaterial)
                    .HasForeignKey(d => d.RawMaterialId)
                    .HasConstraintName("suplier_raw_material_ibfk_1");

                entity.HasOne(d => d.Suplier)
                    .WithMany(p => p.SuplierRawMaterial)
                    .HasForeignKey(d => d.SuplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("suplier_raw_material_ibfk_2");
            });

            modelBuilder.Entity<TempZone>(entity =>
            {
                entity.ToTable("temp_zone");

                entity.HasIndex(e => e.PlateId)
                    .HasName("R_155");

                entity.HasIndex(e => e.ZoneType)
                    .HasName("R_200");

                entity.Property(e => e.TempZoneId)
                    .HasColumnName("temp_zone_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.PlateId)
                    .HasColumnName("plate_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ZoneType)
                    .HasColumnName("zone_type")
                    .HasColumnType("tinyint(4)");

                entity.HasOne(d => d.Plate)
                    .WithMany(p => p.TempZone)
                    .HasForeignKey(d => d.PlateId)
                    .HasConstraintName("temp_zone_ibfk_1");

                entity.HasOne(d => d.ZoneTypeNavigation)
                    .WithMany(p => p.TempZone)
                    .HasForeignKey(d => d.ZoneType)
                    .HasConstraintName("temp_zone_ibfk_2");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("ticket");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("R_80");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("R_79");

                entity.HasIndex(e => e.OrderId)
                    .HasName("R_102");

                entity.HasIndex(e => e.RedeliveryOrderId)
                    .HasName("R_152");

                entity.HasIndex(e => e.TicketType)
                    .HasName("R_150");

                entity.Property(e => e.TicketId)
                    .HasColumnName("ticket_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Closed)
                    .HasColumnName("closed")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.ContactNo)
                    .HasColumnName("contact_no")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContectPerson)
                    .HasColumnName("contect_person")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Destroyed)
                    .HasColumnName("destroyed")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Redelivery)
                    .HasColumnName("redelivery")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.RedeliveryOrderId)
                    .HasColumnName("redelivery_order_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReturnCredit)
                    .HasColumnName("return_credit")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.TicketType)
                    .HasColumnName("ticket_type")
                    .HasColumnType("tinyint(4)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("ticket_ibfk_2");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("ticket_ibfk_1");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TicketOrder)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("ticket_ibfk_3");

                entity.HasOne(d => d.RedeliveryOrder)
                    .WithMany(p => p.TicketRedeliveryOrder)
                    .HasForeignKey(d => d.RedeliveryOrderId)
                    .HasConstraintName("ticket_ibfk_5");

                entity.HasOne(d => d.TicketTypeNavigation)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.TicketType)
                    .HasConstraintName("ticket_ibfk_4");
            });

            modelBuilder.Entity<TicketProcess>(entity =>
            {
                entity.HasKey(e => e.ProcessId)
                    .HasName("PRIMARY");

                entity.ToTable("ticket_process");

                entity.HasIndex(e => e.AssignedEmployeeId)
                    .HasName("R_82");

                entity.HasIndex(e => e.TicketId)
                    .HasName("R_81");

                entity.Property(e => e.ProcessId)
                    .HasColumnName("process_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AssignedEmployeeId)
                    .HasColumnName("assigned_employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CompletedAt)
                    .HasColumnName("completed_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Processed)
                    .HasColumnName("processed")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.TicketId)
                    .HasColumnName("ticket_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.AssignedEmployee)
                    .WithMany(p => p.TicketProcess)
                    .HasForeignKey(d => d.AssignedEmployeeId)
                    .HasConstraintName("ticket_process_ibfk_2");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.TicketProcess)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("ticket_process_ibfk_1");
            });

            modelBuilder.Entity<TicketType>(entity =>
            {
                entity.HasKey(e => e.TicketType1)
                    .HasName("PRIMARY");

                entity.ToTable("ticket_type");

                entity.Property(e => e.TicketType1)
                    .HasColumnName("ticket_type")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.TicketTypeName)
                    .HasColumnName("ticket_type_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("transaction_type");

                entity.Property(e => e.TransactionTypeId)
                    .HasColumnName("transaction_type_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.TransactionTypeName)
                    .HasColumnName("transaction_type_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<UnloadingInspection>(entity =>
            {
                entity.HasKey(e => e.InspectionId)
                    .HasName("PRIMARY");

                entity.ToTable("unloading_inspection");

                entity.HasIndex(e => e.PoId)
                    .HasName("R_97");

                entity.Property(e => e.InspectionId)
                    .HasColumnName("inspection_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ActualQty)
                    .HasColumnName("actual_qty")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArrivalTime)
                    .HasColumnName("arrival_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConditionOfPackage)
                    .HasColumnName("condition_of_package")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ConditionOfProduct)
                    .HasColumnName("condition_of_product")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContainerNo)
                    .HasColumnName("container_no")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PoId)
                    .HasColumnName("po_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SpendingHours)
                    .HasColumnName("spending_hours")
                    .HasColumnType("decimal(6,2)");

                entity.Property(e => e.TakeAwayDate)
                    .HasColumnName("take_away_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.UnloadingDate)
                    .HasColumnName("unloading_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.UnloadingPeople)
                    .HasColumnName("unloading_people")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Po)
                    .WithMany(p => p.UnloadingInspection)
                    .HasForeignKey(d => d.PoId)
                    .HasConstraintName("unloading_inspection_ibfk_1");
            });

            modelBuilder.Entity<WorkOrder>(entity =>
            {
                entity.ToTable("work_order");

                entity.HasIndex(e => e.CreatedEmployeeId)
                    .HasName("R_37");

                entity.HasIndex(e => e.OrderProductId)
                    .HasName("R_35");

                entity.HasIndex(e => e.OrderTypeId)
                    .HasName("R_116");

                entity.HasIndex(e => e.ProductId)
                    .HasName("R_36");

                entity.HasIndex(e => e.WorkOrderSourceId)
                    .HasName("R_140");

                entity.HasIndex(e => e.WorkOrderStatusId)
                    .HasName("R_141");

                entity.Property(e => e.WorkOrderId)
                    .HasColumnName("work_order_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ApprovedComments)
                    .HasColumnName("approved_comments")
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ApprovedEmployeeId)
                    .HasColumnName("approved_employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedEmployeeId)
                    .HasColumnName("created_employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OrderProductId)
                    .HasColumnName("order_product_id")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrderTypeId)
                    .HasColumnName("order_type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RequiredDate)
                    .HasColumnName("required_date")
                    .HasColumnType("date");

                entity.Property(e => e.Urgent)
                    .HasColumnName("urgent")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.WorkOrderNo)
                    .HasColumnName("work_order_no")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WorkOrderSourceId)
                    .HasColumnName("work_order_source_id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.WorkOrderStatusId)
                    .HasColumnName("work_order_status_id")
                    .HasColumnType("tinyint(4)");

                entity.HasOne(d => d.CreatedEmployee)
                    .WithMany(p => p.WorkOrder)
                    .HasForeignKey(d => d.CreatedEmployeeId)
                    .HasConstraintName("work_order_ibfk_3");

                entity.HasOne(d => d.OrderProduct)
                    .WithMany(p => p.WorkOrder)
                    .HasForeignKey(d => d.OrderProductId)
                    .HasConstraintName("work_order_ibfk_1");

                entity.HasOne(d => d.OrderType)
                    .WithMany(p => p.WorkOrder)
                    .HasForeignKey(d => d.OrderTypeId)
                    .HasConstraintName("work_order_ibfk_5");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.WorkOrder)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("work_order_ibfk_2");

                entity.HasOne(d => d.WorkOrderSource)
                    .WithMany(p => p.WorkOrder)
                    .HasForeignKey(d => d.WorkOrderSourceId)
                    .HasConstraintName("work_order_ibfk_6");

                entity.HasOne(d => d.WorkOrderStatus)
                    .WithMany(p => p.WorkOrder)
                    .HasForeignKey(d => d.WorkOrderStatusId)
                    .HasConstraintName("work_order_ibfk_7");
            });

            modelBuilder.Entity<WorkOrderSource>(entity =>
            {
                entity.ToTable("work_order_source");

                entity.Property(e => e.WorkOrderSourceId)
                    .HasColumnName("work_order_source_id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.WorkOrderSourceName)
                    .HasColumnName("work_order_source_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<WorkOrderStatus>(entity =>
            {
                entity.ToTable("work_order_status");

                entity.Property(e => e.WorkOrderStatusId)
                    .HasColumnName("work_order_status_id")
                    .HasColumnType("tinyint(4)")
                    .ValueGeneratedNever();

                entity.Property(e => e.WorkOrderStatusName)
                    .HasColumnName("work_order_status_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<WorkingArrangement>(entity =>
            {
                entity.HasKey(e => e.ArrangementId)
                    .HasName("PRIMARY");

                entity.ToTable("working_arrangement");

                entity.HasIndex(e => e.CreatedBy)
                    .HasName("R_113");

                entity.HasIndex(e => e.MachineId)
                    .HasName("R_114");

                entity.HasIndex(e => e.Operator)
                    .HasName("R_115");

                entity.Property(e => e.ArrangementId)
                    .HasColumnName("arrangement_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MachineId)
                    .HasColumnName("machine_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Maintenance)
                    .HasColumnName("maintenance")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Operator)
                    .HasColumnName("operator")
                    .HasColumnType("int(11)");

                entity.Property(e => e.WorkingDate)
                    .HasColumnName("working_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.WorkingArrangementCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("working_arrangement_ibfk_1");

                entity.HasOne(d => d.Machine)
                    .WithMany(p => p.WorkingArrangement)
                    .HasForeignKey(d => d.MachineId)
                    .HasConstraintName("working_arrangement_ibfk_2");

                entity.HasOne(d => d.OperatorNavigation)
                    .WithMany(p => p.WorkingArrangementOperatorNavigation)
                    .HasForeignKey(d => d.Operator)
                    .HasConstraintName("working_arrangement_ibfk_3");
            });

            modelBuilder.Entity<Zone>(entity =>
            {
                entity.ToTable("zone");

                entity.Property(e => e.ZoneId)
                    .HasColumnName("zone_id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.ZoneCode)
                    .HasColumnName("zone_code")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<ZoneType>(entity =>
            {
                entity.HasKey(e => e.ZoneType1)
                    .HasName("PRIMARY");

                entity.ToTable("zone_type");

                entity.Property(e => e.ZoneType1)
                    .HasColumnName("zone_type")
                    .HasColumnType("tinyint(4)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ZoneTypeName)
                    .HasColumnName("zone_type_name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
