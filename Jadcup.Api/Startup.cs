using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Jadcup.Common.Context;
using Jadcup.Common.Helper;
using Jadcup.Services.Interface.CommonServiceInterface;
using Jadcup.Services.Service.CommonService;
using AutoMapper;
using Jadcup.Services.Interface.EmployeeInterface;
using Jadcup.Services.Service.EmployeeService;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Service.SmallGroupManagementService;
using Jadcup.Services.Interface.SmallGroupManagementInterface.CustomerGrpManagementService;
using Jadcup.Services.Service.SmallGroupManagementService.CustomerGrpManagementService;
using Jadcup.Common.CommonFunctions;
using Jadcup.Services.Model.CustomerSourceModel;
using Jadcup.Common.Repository;
using Jadcup.Services.Model.BrandModel;
using Jadcup.Services.Model.CityModel;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup1;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup2;
using Jadcup.Services.Interface.CustomerService;
using Jadcup.Services.Service.CustomerService;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup3;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup4;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup5;
using Jadcup.Services.Model.PaymentCycleModel;
using Jadcup.Services.Model.DepartmentModel;
using Jadcup.Services.Model.RoleModel;
using Jadcup.Services.Model.HumanResource;
using Jadcup.Services.Interface.IPageService;
using Jadcup.Services.Service.PageService;
using Jadcup.Services.Model.PageModel;
using Jadcup.Services.Model.PageGroupModel;
using Jadcup.Services.Interface.PageGroupService;
using Jadcup.Services.Service.PageGroupService;
using Jadcup.Services.Interface.RolePageService;
using Jadcup.Services.Service.RolePageService;
using Jadcup.Services.Model.ProductTypeModel;
using Jadcup.Services.Model.RawMaterialModel;
using Jadcup.Services.Interface.RawMaterialService;
using Jadcup.Services.Service.RawMaterialService;
using Jadcup.Services.Interface.BaseProductService;
using Jadcup.Services.Service.BaseProductService;
using Jadcup.Services.Model.PlateTypeModel;
using Jadcup.Services.Model.PackagingTypeModel;
using Jadcup.Services.Interface.ProductService;
using Jadcup.Services.Service.ProductService;
using Jadcup.Services.Interface.ItemService;
using Jadcup.Services.Service.ItemService;
using Jadcup.Services.Model.QuotationOptionItemModel;
using Jadcup.Services.Interface.QuotationOptionManagementService;
using Jadcup.Services.Service.QuotationOptionService;
using Jadcup.Services.Interface.QuotationItemService;
using Jadcup.Services.Service.QuotationItemService;
using Jadcup.Services.Model.DeliveryMethodModel;
using Jadcup.Services.Interface.QuotationService;
using Jadcup.Services.Service.QuotationService;
using Jadcup.Services.Interface.OrderProductService;
using Jadcup.Services.Service.OrderProductService;
using Jadcup.Services.Interface.OrderService;
using Jadcup.Services.Service.OrderService;
using Jadcup.Services.Interface.WorkOrderStatusService;
using Jadcup.Services.Service.WorkOrderStatusService;
using Jadcup.Services.Interface.ParameterService;
using Jadcup.Services.Service.ParameterService;
using Jadcup.Services.Interface.ProductTypeActionService;
using Jadcup.Services.Service.ProductTypeActionService;
using Jadcup.Services.Model.MachineTypeModel;
using Jadcup.Services.Interface.MachineService;
using Jadcup.Services.Service.MachineService;
using Jadcup.Services.Interface.SuborderStatusService;
using Jadcup.Services.Interface.SuborderService;
using Jadcup.Services.Service.SuborderService;
using Jadcup.Services.Model.ZoneModel;
using Jadcup.Services.Interface.HumanResourceService;
using Jadcup.Services.Service.HumanResourceService;
using Jadcup.Services.Interface.WorkOrderService;
using Jadcup.Services.Service.WorkOrderService;
using Jadcup.Services.Interface.ApplicationDetailsManagementService;
using Jadcup.Services.Service.ApplicationDetailsService;
using Jadcup.Services.Interface.RawMaterialApplicationService;
using Jadcup.Services.Service.RawMaterialApplicationService;
using Jadcup.Services.Interface.WorkingArrangementService;
using Jadcup.Services.Service.WorkingArrangementService;
using Jadcup.Services.Interface.BoxService;
using Jadcup.Services.Service.BoxService;
using Jadcup.Services.Interface.TicketService;
using Jadcup.Services.Interface.PlateService;
using Jadcup.Services.Service.PlateService;
using Jadcup.Services.Interface.PlateBoxService;
using Jadcup.Services.Service.PlateBoxService;
using Jadcup.Services.Interface.WorkOrderStockService;
using Jadcup.Services.Service.WorkOrderStockService;
using Jadcup.Services.Interface.InspectionPlanService;
using Jadcup.Services.Service.InspectionPlanService;
using Jadcup.Services.Interface.TempZoneService;
using Jadcup.Services.Service.TempZoneService;
using Jadcup.Services.Interface.ShelfPlateService;
using Jadcup.Services.Service.ShelfPlateService;
using Jadcup.Services.Interface.CellService;
using Jadcup.Services.Interface.ContractTypeService;
using Jadcup.Services.Service.CellService;
using Jadcup.Services.Interface.ShelfService;
using Jadcup.Services.Service.ShelfService;
using Jadcup.Services.Interface.RawMaterialBoxService;
using Jadcup.Services.Service.RawMaterialBoxService;
using Jadcup.Services.Interface.ZoneService;
using Jadcup.Services.Service.ZoneService;
using Jadcup.Services.Interface.ExtraAddressService;
using Jadcup.Services.Service.ExtraAddressService;
using Jadcup.Services.Model.CourierModel;
using Jadcup.Services.Interface.DispatchingService;
using Jadcup.Services.Service.DispatchingService;
using Jadcup.Services.Interface.SupplierService;
using Jadcup.Services.Service.SupplierService;
using Jadcup.Services.Interface.OnlineUserService;
using Jadcup.Services.Service.OnlineUserManagementService;
using Jadcup.Services.Interface.SupplierRawMaterialService;
using Jadcup.Services.Service.SupplierRawMaterialService;
using Jadcup.Services.Interface.PurchaseOrderService;
using Jadcup.Services.Service.PurchaseOrderService;
using Jadcup.Services.Interface.UnloadingInspectionService;
using Jadcup.Services.Service.UnloadingInspectionService;
using Jadcup.Services.Interface.ProductMachineMappingService;
using Jadcup.Services.Service.ProductMachineMappingService;
using Jadcup.Services.Interface.ProductOptionService;
using Jadcup.Services.Service.ProductOptionService;
using Jadcup.Services.Interface.RawMaterialStockService;
using Jadcup.Services.Service.RawMaterialStockService;
using Jadcup.Services.Model.HumanResource.Quarter;
using Jadcup.Services.Interface.PalletStackingService;
using Jadcup.Services.Service.PalletStackingService;
using Jadcup.Services.Interface.PriceService;
using Jadcup.Services.Service.PriceService;
using Jadcup.Services.Interface.InvoiceService;
using Jadcup.Services.Service.InvoiceService;
using Jadcup.Services.Service.TicketService;
using Jadcup.Services.Interface.TicketProcessService;
using Jadcup.Services.Service.TicketProcessService;
using Jadcup.Services.Interface.ReturnItemService;
using Jadcup.Services.Service.ReturnItemService;
using Jadcup.Services.Interface.ProductPriceService;
using Jadcup.Services.Service.ProductPriceManagementService;
using Jadcup.Services.Interface.SalesVisitService;
using Jadcup.Services.Service.SalesVisitService;
using Jadcup.Services.Interface.NotificationService;
using Jadcup.Services.Interface.ProductForShowingService;
using Jadcup.Services.Interface.RecordTypeService;
using Jadcup.Services.Service.NotificationService;
using Jadcup.Services.Interface.SalesReportService;
using Jadcup.Services.Service.ContractTypeService;
using Jadcup.Services.Service.ProductForShowingService;
using Jadcup.Services.Service.RecordTypeService;
using Jadcup.Services.Service.SalesReportService;
using Jadcup.Services.Interface.AssessmentService;
using Jadcup.Services.Service.AssessmentService;

namespace Jadcup.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<JadcupDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaulstConnection")));
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddMvc();
            services.AddSingleton<IConfiguration>(Configuration);

            // Notification
            services.AddScoped<IGenericMySqlAccessRepository<Notification>, GenericMySqlAccessRepository<Notification>>();
            services.AddScoped<INotificationService, NotificationService>();

            // Sales Visit Plan
            services.AddScoped<IGenericMySqlAccessRepository<SalesVisitPlan>, GenericMySqlAccessRepository<SalesVisitPlan>>();
            services.AddScoped<ISalesVisitService, SalesVisitService>();

            // Sales Report 
            services.AddScoped<IGenericMySqlAccessRepository<Invoice>, GenericMySqlAccessRepository<Invoice>>();
            services.AddScoped<ISalesReportService, SalesReportService>();

            // Assessment Standards
            services.AddScoped<IGenericMySqlAccessRepository<AccessmentStandards>, GenericMySqlAccessRepository<AccessmentStandards>>();
            services.AddScoped<IGenericMySqlAccessRepository<AccessmentStandardsDetail>, GenericMySqlAccessRepository<AccessmentStandardsDetail>>();
            services.AddScoped<IGenericMySqlAccessRepository<AccessmentPlan>, GenericMySqlAccessRepository<AccessmentPlan>>();
            services.AddScoped<IGenericMySqlAccessRepository<Accessment>, GenericMySqlAccessRepository<Accessment>>();
            services.AddScoped<IGenericMySqlAccessRepository<AccessmentDetail>, GenericMySqlAccessRepository<AccessmentDetail>>();
            services.AddScoped<IAssessmentService, AssessmentService>();

            services.AddScoped<IGenericMySqlAccessRepository<Employee>, GenericMySqlAccessRepository<Employee>>();
            services.AddScoped<IGenericMySqlAccessRepository<Customer>, GenericMySqlAccessRepository<Customer>>();
            services.AddScoped<IGenericMySqlAccessRepository<RolePageMapping>, GenericMySqlAccessRepository<RolePageMapping>>();
            services.AddScoped<IGenericMySqlAccessRepository<Brand>, GenericMySqlAccessRepository<Brand>>();
            services.AddScoped<IGenericMySqlAccessRepository<City>, GenericMySqlAccessRepository<City>>();
            services.AddScoped<IGenericMySqlAccessRepository<Page>, GenericMySqlAccessRepository<Page>>();
            services.AddScoped<IGenericMySqlAccessRepository<CustomerGrp1>, GenericMySqlAccessRepository<CustomerGrp1>>();
            services.AddScoped<IGenericMySqlAccessRepository<CustomerGrp2>, GenericMySqlAccessRepository<CustomerGrp2>>();
            services.AddScoped<IGenericMySqlAccessRepository<CustomerGrp3>, GenericMySqlAccessRepository<CustomerGrp3>>();
            services.AddScoped<IGenericMySqlAccessRepository<CustomerGrp4>, GenericMySqlAccessRepository<CustomerGrp4>>();
            services.AddScoped<IGenericMySqlAccessRepository<CustomerGrp5>, GenericMySqlAccessRepository<CustomerGrp5>>();
            services.AddScoped<IGenericMySqlAccessRepository<CustomerSource>, GenericMySqlAccessRepository<CustomerSource>>();
            services.AddScoped<IGenericMySqlAccessRepository<PaymentCycle>, GenericMySqlAccessRepository<PaymentCycle>>();
            services.AddScoped<IGenericMySqlAccessRepository<CustomerStatus>, GenericMySqlAccessRepository<CustomerStatus>>();
            services.AddScoped<IGenericMySqlAccessRepository<Dept>, GenericMySqlAccessRepository<Dept>>();
            services.AddScoped<IGenericMySqlAccessRepository<Role>, GenericMySqlAccessRepository<Role>>();
            services.AddScoped<IGenericMySqlAccessRepository<PageGroup>, GenericMySqlAccessRepository<PageGroup>>();
            services.AddScoped<IGenericMySqlAccessRepository<ProductType>, GenericMySqlAccessRepository<ProductType>>();
            services.AddScoped<IGenericMySqlAccessRepository<RawMaterial>, GenericMySqlAccessRepository<RawMaterial>>();
            services.AddScoped<IGenericMySqlAccessRepository<BaseProduct>, GenericMySqlAccessRepository<BaseProduct>>();
            services.AddScoped<IGenericMySqlAccessRepository<PlateType>, GenericMySqlAccessRepository<PlateType>>();
            services.AddScoped<IGenericMySqlAccessRepository<PackagingType>, GenericMySqlAccessRepository<PackagingType>>();
            services.AddScoped<IGenericMySqlAccessRepository<Product>, GenericMySqlAccessRepository<Product>>();
            services.AddScoped<IGenericMySqlAccessRepository<Box>, GenericMySqlAccessRepository<Box>>();
            services.AddScoped<IGenericMySqlAccessRepository<Item>, GenericMySqlAccessRepository<Item>>();
            services.AddScoped<IGenericMySqlAccessRepository<Stock>, GenericMySqlAccessRepository<Stock>>();
            services.AddScoped<IGenericMySqlAccessRepository<Price>, GenericMySqlAccessRepository<Price>>();
            services.AddScoped<IGenericMySqlAccessRepository<QuotationOptionItem>, GenericMySqlAccessRepository<QuotationOptionItem>>();
            services.AddScoped<IGenericMySqlAccessRepository<QuotationOption>, GenericMySqlAccessRepository<QuotationOption>>();
            services.AddScoped<IGenericMySqlAccessRepository<QuotationItem>, GenericMySqlAccessRepository<QuotationItem>>();
            services.AddScoped<IGenericMySqlAccessRepository<DeliveryMethod>, GenericMySqlAccessRepository<DeliveryMethod>>();
            services.AddScoped<IGenericMySqlAccessRepository<Quotation>, GenericMySqlAccessRepository<Quotation>>();
            services.AddScoped<IGenericMySqlAccessRepository<OrderStatus>, GenericMySqlAccessRepository<OrderStatus>>();
            services.AddScoped<IGenericMySqlAccessRepository<OrderProduct>, GenericMySqlAccessRepository<OrderProduct>>();
            services.AddScoped<IGenericMySqlAccessRepository<Orders>, GenericMySqlAccessRepository<Orders>>();
            services.AddScoped<IGenericMySqlAccessRepository<WorkOrderStatus>, GenericMySqlAccessRepository<WorkOrderStatus>>();
            services.AddScoped<IGenericMySqlAccessRepository<Parameter>, GenericMySqlAccessRepository<Parameter>>();
            services.AddScoped<IGenericMySqlAccessRepository<WorkOrder>, GenericMySqlAccessRepository<WorkOrder>>();
            services.AddScoped<IGenericMySqlAccessRepository<Suborder>, GenericMySqlAccessRepository<Suborder>>();
            services.AddScoped<IGenericMySqlAccessRepository<SuborderStatus>, GenericMySqlAccessRepository<SuborderStatus>>();
            services.AddScoped<IGenericMySqlAccessRepository<ProductTypeAction>, GenericMySqlAccessRepository<ProductTypeAction>>();
            services.AddScoped<IGenericMySqlAccessRepository<Common.Context.Action>, GenericMySqlAccessRepository<Common.Context.Action>>();
            services.AddScoped<IGenericMySqlAccessRepository<MachineType>, GenericMySqlAccessRepository<MachineType>>();
            services.AddScoped<IGenericMySqlAccessRepository<Machine>, GenericMySqlAccessRepository<Machine>>();
            services.AddScoped<IGenericMySqlAccessRepository<OrderType>, GenericMySqlAccessRepository<OrderType>>();
            services.AddScoped<IGenericMySqlAccessRepository<WorkOrderSource>, GenericMySqlAccessRepository<WorkOrderSource>>();
            services.AddScoped<IGenericMySqlAccessRepository<SuborderLog>, GenericMySqlAccessRepository<SuborderLog>>();
            services.AddScoped<IGenericMySqlAccessRepository<ApplicationDetails>, GenericMySqlAccessRepository<ApplicationDetails>>();
            services.AddScoped<IGenericMySqlAccessRepository<RawMaterialApplication>, GenericMySqlAccessRepository<RawMaterialApplication>>();
            services.AddScoped<IGenericMySqlAccessRepository<WorkingArrangement>, GenericMySqlAccessRepository<WorkingArrangement>>();
            services.AddScoped<IGenericMySqlAccessRepository<Plate>, GenericMySqlAccessRepository<Plate>>();
            services.AddScoped<IGenericMySqlAccessRepository<PlateBox>, GenericMySqlAccessRepository<PlateBox>>();
            services.AddScoped<IGenericMySqlAccessRepository<TempZone>, GenericMySqlAccessRepository<TempZone>>();
            services.AddScoped<IGenericMySqlAccessRepository<StockLog>, GenericMySqlAccessRepository<StockLog>>();
            services.AddScoped<IGenericMySqlAccessRepository<ShelfPlate>, GenericMySqlAccessRepository<ShelfPlate>>();
            services.AddScoped<IGenericMySqlAccessRepository<Cell>, GenericMySqlAccessRepository<Cell>>();
            services.AddScoped<IGenericMySqlAccessRepository<Shelf>, GenericMySqlAccessRepository<Shelf>>();
            services.AddScoped<IGenericMySqlAccessRepository<RawMaterialBox>, GenericMySqlAccessRepository<RawMaterialBox>>();
            services.AddScoped<IGenericMySqlAccessRepository<ExtraAddress>, GenericMySqlAccessRepository<ExtraAddress>>();
            services.AddScoped<IGenericMySqlAccessRepository<DispatchingStatus>, GenericMySqlAccessRepository<DispatchingStatus>>();
            services.AddScoped<IGenericMySqlAccessRepository<Courier>, GenericMySqlAccessRepository<Courier>>();
            services.AddScoped<IGenericMySqlAccessRepository<Dispatching>, GenericMySqlAccessRepository<Dispatching>>();
            services.AddScoped<IGenericMySqlAccessRepository<DispatchingDetails>, GenericMySqlAccessRepository<DispatchingDetails>>();
            services.AddScoped<IGenericMySqlAccessRepository<Suplier>, GenericMySqlAccessRepository<Suplier>>();
            services.AddScoped<IGenericMySqlAccessRepository<Qualification>, GenericMySqlAccessRepository<Qualification>>();
            services.AddScoped<IGenericMySqlAccessRepository<SuplierRawMaterial>, GenericMySqlAccessRepository<SuplierRawMaterial>>();
            services.AddScoped<IGenericMySqlAccessRepository<ProductMachineMapping>, GenericMySqlAccessRepository<ProductMachineMapping>>();
            services.AddScoped<IGenericMySqlAccessRepository<PoStatus>, GenericMySqlAccessRepository<PoStatus>>();
            services.AddScoped<IGenericMySqlAccessRepository<PurchaseOrder>, GenericMySqlAccessRepository<PurchaseOrder>>();
            services.AddScoped<IGenericMySqlAccessRepository<PoDetail>, GenericMySqlAccessRepository<PoDetail>>();
            services.AddScoped<IGenericMySqlAccessRepository<UnloadingInspection>, GenericMySqlAccessRepository<UnloadingInspection>>();
            services.AddScoped<IGenericMySqlAccessRepository<ProductOption>, GenericMySqlAccessRepository<ProductOption>>();
            services.AddScoped<IGenericMySqlAccessRepository<OrderOption>, GenericMySqlAccessRepository<OrderOption>>();
            services.AddScoped<IGenericMySqlAccessRepository<Standard>, GenericMySqlAccessRepository<Standard>>();
            services.AddScoped<IGenericMySqlAccessRepository<Quarter>, GenericMySqlAccessRepository<Quarter>>();
            services.AddScoped<IGenericMySqlAccessRepository<Zone>, GenericMySqlAccessRepository<Zone>>();
            services.AddScoped<IGenericMySqlAccessRepository<HumanResource>, GenericMySqlAccessRepository<HumanResource>>();
            services.AddScoped<IGenericMySqlAccessRepository<Contract>, GenericMySqlAccessRepository<Contract>>();
            services.AddScoped<IGenericMySqlAccessRepository<AttachedRecord>, GenericMySqlAccessRepository<AttachedRecord>>();
            services.AddScoped<IGenericMySqlAccessRepository<SalaryFactor>, GenericMySqlAccessRepository<SalaryFactor>>();
            services.AddScoped<IGenericMySqlAccessRepository<InspectionPlan>, GenericMySqlAccessRepository<InspectionPlan>>();
            services.AddScoped<IGenericMySqlAccessRepository<InspectionLog>, GenericMySqlAccessRepository<InspectionLog>>();
            services.AddScoped<IGenericMySqlAccessRepository<PalletStacking>, GenericMySqlAccessRepository<PalletStacking>>();
            services.AddScoped<IGenericMySqlAccessRepository<Invoice>, GenericMySqlAccessRepository<Invoice>>();
            services.AddScoped<IGenericMySqlAccessRepository<InvoiceItem>, GenericMySqlAccessRepository<InvoiceItem>>();
            services.AddScoped<IGenericMySqlAccessRepository<CustomerCredit>, GenericMySqlAccessRepository<CustomerCredit>>();
            services.AddScoped<IGenericMySqlAccessRepository<CreditTransaction>, GenericMySqlAccessRepository<CreditTransaction>>();
            services.AddScoped<IGenericMySqlAccessRepository<Ticket>, GenericMySqlAccessRepository<Ticket>>();
            services.AddScoped<IGenericMySqlAccessRepository<TicketProcess>, GenericMySqlAccessRepository<TicketProcess>>();
            services.AddScoped<IGenericMySqlAccessRepository<ReturnItem>, GenericMySqlAccessRepository<ReturnItem>>();
            services.AddScoped<IGenericMySqlAccessRepository<TicketType>, GenericMySqlAccessRepository<TicketType>>();
            services.AddScoped<IGenericMySqlAccessRepository<ZoneType>, GenericMySqlAccessRepository<ZoneType>>();
            
            //ContractType
            services.AddScoped<IGenericMySqlAccessRepository<ContractType>, GenericMySqlAccessRepository<ContractType>>();
            
            //RecordType
            services.AddScoped<IGenericMySqlAccessRepository<RecordType>, GenericMySqlAccessRepository<RecordType>>();

            services.AddScoped<IGenericMySqlAccessRepository<OnlineUser>, GenericMySqlAccessRepository<OnlineUser>>();
            services.AddScoped<IGenericMySqlAccessRepository<ProductPrice>, GenericMySqlAccessRepository<ProductPrice>>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IEmployeeManagementService, EmployeeManagementService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerStatusManagementService, CustomerStatusManagementService>();
            services.AddScoped<IPageManagementService, PageManagementService>();
            services.AddScoped<IRolePageService, RolePageService>();
            services.AddScoped<IBaseProductManagementService, BaseProductManagementService>();
            services.AddScoped<IProductManagementService, ProductManagementService>();
            services.AddScoped<IItemManagementService, ItemManagementService>();
            services.AddScoped<IQuotationOptionManagementService, QuotationOptionManagementService>();
            services.AddScoped<IQuotationItemManagementService, QuotationItemManagementService>();
            services.AddScoped<IQuotationManagementService, QuotationManagementService>();
            services.AddScoped<IOrderStatusManagementService, OrderStatusManagementService>();
            services.AddScoped<IOrderProductManagementService, OrderProductManagementService>();
            services.AddScoped<IOrderManagementService, OrderManagementService>();
            services.AddScoped<IWorkOrderStatusManagementService, WorkOrderStatusManagementService>();
            services.AddScoped<IParameterManagementService, ParameterManagementService>();
            services.AddScoped<IProductTypeActionManagementService, ProductTypeActionManagementService>();
            services.AddScoped<IActionManagementService, ActionManagementService>();
            services.AddScoped<IMachineManagementService, MachineManagementService>();
            services.AddScoped<ISuborderStatusManagementService, SuborderStatusManagementService>();
            services.AddScoped<ISuborderManagementService, SuborderManagementService>();
            services.AddScoped<IOrderTypeManagementService, OrderTypeManagementService>();
            services.AddScoped<IWorkOrderSourceManagementService, WorkOrderSourceManagementService>();
            services.AddScoped<IWorkOrderManagementService, WorkOrderManagementService>();
            services.AddScoped<IApplicationDetailsManagementService, ApplicationDetailsManagementService>();
            services.AddScoped<IRawMaterialApplicationManagementService, RawMaterialApplicationManagementService>();
            services.AddScoped<IWorkingArrangementManagementService, WorkingArrangementManagementService>();
            services.AddScoped<IBoxManagementService, BoxManagementService>();
            services.AddScoped<IPlateManagementService, PlateManagementService>();
            services.AddScoped<IPlateBoxManagementService, PlateBoxManagementService>();
            services.AddScoped<IWorkOrderStockManagementService, WorkOrderStockManagementService>();
            services.AddScoped<ITempZoneManagementService, TempZoneManagementService>();
            services.AddScoped<IShelfPlateManagementService, ShelfPlateManagementService>();
            services.AddScoped<ICellManagementService, CellManagementService>();
            services.AddScoped<IShelfManagementService, ShelfManagementService>();
            services.AddScoped<IRawMaterialBoxManagementService, RawMaterialBoxManagementService>();
            services.AddScoped<IExtraAddressManagementService, ExtraAddressManagementService>();
            services.AddScoped<IDispatchingStatusManagementService, DispatchingStatusManagementService>();
            services.AddScoped<IDispatchingManagementService, DispatchingManagementService>();
            services.AddScoped<ISupplierManagementService, SupplierManagementService>();
            services.AddScoped<ISupplierRawMaterialManagementService, SupplierRawMaterialManagementService>();
            services.AddScoped<IPoStatusManagementService, PoStatusManagementService>();
            services.AddScoped<IPurchaseOrderManagementService, PurchaseOrderManagementService>();
            services.AddScoped<IUnloadingInspectionManagementService, UnloadingInspectionManagementService>();
            services.AddScoped<IProductMachineMappingManagementService, ProductMachineMappingManagementService>();
            services.AddScoped<IProductOptionManagementService, ProductOptionManagementService>();
            services.AddScoped<IRawMaterialStockManagementService, RawMaterialStockManagementService>();
            services.AddScoped<IPalletStackingManagementService, PalletStackingManagementService>();
            services.AddScoped<IPriceManagementService, PriceManagementService>();
            services.AddScoped<IInvoiceManagementService, InvoiceManagementService>();
            services.AddScoped<ITicketProcessManagementService, TicketProcessManagementService>();
            services.AddScoped<IReturnItemManagementService, ReturnItemManagementService>();

            //ContratType
            services.AddScoped<IContractTypeService, ContractTypeService>();
            
            //RecordType
            services.AddScoped<IRecordTypeService, RecordTypeService>();
            services.AddScoped<IProductForShowingService, ProductForShowingService>();
            
            services.AddScoped<IOrderFromCustomerManagementService, OrderFromCustomerManagementService>();
            services.AddScoped<OrderManagementService, OrderManagementService>();
            services.AddScoped<IOlineUserManagementService, OnlineUserManagementService>();

            services.AddScoped<ICrud<Zone, GetZoneDto, UpdateZoneDto>, Crud<Zone, GetZoneDto, UpdateZoneDto>>();
            services.AddScoped<IZoneManagementService, ZoneManagementService>();
            services.AddScoped<IHumanResourceManagementService, HumanResourceManagementService>();
            services.AddScoped<ITicketManagementService, TicketManagementService>();
            services.AddScoped<IInspectionPlanManagementService, InspectionPlanManagementService>();
            services.AddScoped<IProductPriceService, ProductPriceManagementService>();

            services.AddScoped<ICrud<Brand, GetBrandDto, UpdateBrandDto>, Crud<Brand, GetBrandDto, UpdateBrandDto>>();
            services.AddScoped<IBrandManagementService, BrandManagementService>();
            services.AddScoped<ICrud<City, GetCityDto, UpdateCityDto>, Crud<City, GetCityDto, UpdateCityDto>>();
            services.AddScoped<ICityManagementService, CityManagementService>();
            services.AddScoped<ICrud<CustomerSource, GetCustomerSourceDto, UpdateCustomerSourceDto>, Crud<CustomerSource, GetCustomerSourceDto, UpdateCustomerSourceDto>>();
            services.AddScoped<ICustomerSourceManagementService, CustomerSourceManagementService>();
            services.AddScoped<ICrud<PaymentCycle, GetPaymentCycleDto, UpdatePaymentCycleDto>, Crud<PaymentCycle, GetPaymentCycleDto, UpdatePaymentCycleDto>>();
            services.AddScoped<IPaymentCycleManagementService, PaymentCycleManagementService>();
            services.AddScoped<ICrud<Dept, GetDepartmentDto, UpdateDepartmentDto>, Crud<Dept, GetDepartmentDto, UpdateDepartmentDto>>();
            services.AddScoped<IDeptManagementService, DeptManagementService>();
            services.AddScoped<ICrud<Role, GetRoleDto, UpdateRoleDto>, Crud<Role, GetRoleDto, UpdateRoleDto>>();
            services.AddScoped<IRoleManagementService, RoleManagementService>();
            services.AddScoped<ICrud<PageGroup, GetPageGroupDto, UpdatePageGroupDto>, Crud<PageGroup, GetPageGroupDto, UpdatePageGroupDto>>();
            services.AddScoped<IPageGroupManagementService, PageGroupManagementService>();
            services.AddScoped<ICrud<ProductType, GetProductTypeDto, UpdateProductTypeDto>, Crud<ProductType, GetProductTypeDto, UpdateProductTypeDto>>();
            services.AddScoped<IProductTypeManagementService, ProductTypeManagementService>();
            services.AddScoped<ICrud<RawMaterial, GetRawMaterialDto, UpdateRawMaterialDto>, Crud<RawMaterial, GetRawMaterialDto, UpdateRawMaterialDto>>();
            services.AddScoped<IRawMaterialManagementService, RawMaterialManagementService>();
            services.AddScoped<ICrud<PlateType, GetPlateTypeDto, UpdatePlateTypeDto>, Crud<PlateType, GetPlateTypeDto, UpdatePlateTypeDto>>();
            services.AddScoped<IPlateTypeManagementService, PlateTypeManagementService>();
            services.AddScoped<ICrud<PackagingType, GetPackagingTypeDto, UpdatePackagingTypeDto>, Crud<PackagingType, GetPackagingTypeDto, UpdatePackagingTypeDto>>();
            services.AddScoped<IPackagingTypeManagementService, PackagingTypeManagementService>();
            services.AddScoped<ICrud<QuotationOptionItem, GetQuotationOptionItemDto, UpdateQuotationOptionItemDto>, Crud<QuotationOptionItem, GetQuotationOptionItemDto, UpdateQuotationOptionItemDto>>();
            services.AddScoped<IQuotationOptionItemManagementService, QuotationOptionItemManagementService>();
            services.AddScoped<ICrud<DeliveryMethod, GetDeliveryMethodDto, UpdateDeliveryMethodDto>, Crud<DeliveryMethod, GetDeliveryMethodDto, UpdateDeliveryMethodDto>>();
            services.AddScoped<IDeliveryMethodManagementService, DeliveryMethodManagementService>();
            services.AddScoped<ICrud<MachineType, GetMachineTypeDto, UpdateMachineTypeDto>, Crud<MachineType, GetMachineTypeDto, UpdateMachineTypeDto>>();
            services.AddScoped<IMachineTypeManagementService, MachineTypeManagementService>();
            services.AddScoped<ICrud<Courier, GetCourierDto, UpdateCourierDto>, Crud<Courier, GetCourierDto, UpdateCourierDto>>();
            services.AddScoped<ICourierManagementService, CourierManagementService>();
            services.AddScoped<ICrud<Quarter, GetQuarterDto, UpdateQuarterDto>, Crud<Quarter, GetQuarterDto, UpdateQuarterDto>>();
            services.AddScoped<IQuarterManagementService, QuarterManagementService>();


            services.AddScoped<ICrud<CustomerGrp1, GetGroup1Dto, UpdateGroup1Dto>, Crud<CustomerGrp1, GetGroup1Dto, UpdateGroup1Dto>>();
            services.AddScoped<ICustomerGrp1ManagementService, CustomerGrp1ManagementService>();
            services.AddScoped<ICrud<CustomerGrp2, GetGroup2Dto, UpdateGroup2Dto>, Crud<CustomerGrp2, GetGroup2Dto, UpdateGroup2Dto>>();
            services.AddScoped<ICustomerGrp2ManagementService, CustomerGrp2ManagementService>();
            services.AddScoped<ICrud<CustomerGrp3, GetGroup3Dto, UpdateGroup3Dto>, Crud<CustomerGrp3, GetGroup3Dto, UpdateGroup3Dto>>();
            services.AddScoped<ICustomerGrp3ManagementService, CustomerGrp3ManagementService>();
            services.AddScoped<ICrud<CustomerGrp4, GetGroup4Dto, UpdateGroup4Dto>, Crud<CustomerGrp4, GetGroup4Dto, UpdateGroup4Dto>>();
            services.AddScoped<ICustomerGrp4ManagementService, CustomerGrp4ManagementService>();
            services.AddScoped<ICrud<CustomerGrp5, GetGroup5Dto, UpdateGroup5Dto>, Crud<CustomerGrp5, GetGroup5Dto, UpdateGroup5Dto>>();
            services.AddScoped<ICustomerGrp5ManagementService, CustomerGrp5ManagementService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                        .GetBytes(Configuration.GetSection("ApplicationSettings:JWT_Secret").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Jadcup API"
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.SetIsOriginAllowed((host) => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseHttpExceptionMiddleware();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jadcup API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
