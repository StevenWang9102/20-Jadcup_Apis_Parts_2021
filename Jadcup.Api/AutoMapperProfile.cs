using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Services.Model.ActionModel;
using Jadcup.Services.Model.BaseProductModel;
using Jadcup.Services.Model.BrandModel;
using Jadcup.Services.Model.CityModel;
using Jadcup.Services.Model.CustomerModel;
using Jadcup.Services.Model.CustomerSourceModel;
using Jadcup.Services.Model.CustomerStatusModel;
using Jadcup.Services.Model.DeliveryMethodModel;
using Jadcup.Services.Model.DepartmentModel;
using Jadcup.Services.Model.EmployeeModel;
using Jadcup.Services.Model.HumanResource;
using Jadcup.Services.Model.HumanResource.Contract;
using Jadcup.Services.Model.HumanResource.AttachedRecord;
using Jadcup.Services.Model.HumanResource.SalaryFactor;
using Jadcup.Services.Model.ItemModel;
using Jadcup.Services.Model.MachineModel;
using Jadcup.Services.Model.MachineTypeModel;
using Jadcup.Services.Model.OrderModel;
using Jadcup.Services.Model.OrderProductModel;
using Jadcup.Services.Model.OrderStatusModel;
using Jadcup.Services.Model.OrderTypeModel;
using Jadcup.Services.Model.PackagingTypeModel;
using Jadcup.Services.Model.PageGroupModel;
using Jadcup.Services.Model.PageModel;
using Jadcup.Services.Model.ParameterModel;
using Jadcup.Services.Model.PaymentCycleModel;
using Jadcup.Services.Model.PlateTypeModel;
using Jadcup.Services.Model.PriceModel;
using Jadcup.Services.Model.ProductModel;
using Jadcup.Services.Model.ProductTypeActionModel;
using Jadcup.Services.Model.ProductTypeModel;
using Jadcup.Services.Model.QuotationItemModel;
using Jadcup.Services.Model.QuotationModel;
using Jadcup.Services.Model.QuotationOptionItemModel;
using Jadcup.Services.Model.QuotationOptionModel;
using Jadcup.Services.Model.RawMaterialModel;
using Jadcup.Services.Model.RoleModel;
using Jadcup.Services.Model.RolePageModel;
using Jadcup.Services.Model.StockModel;
using Jadcup.Services.Model.SuborderModel;
using Jadcup.Services.Model.SuborderStatusModel;
using Jadcup.Services.Model.WorkOrderModel;
using Jadcup.Services.Model.WorkOrderSourceModel;
using Jadcup.Services.Model.WorkOrderStatusModel;
using Jadcup.Services.Model.ZoneModel;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup1;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup2;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup3;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup4;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup5;
using static Jadcup.Services.Model.EmployeeModel.EmployeeRegister;
using Jadcup.Services.Model.RawMaterialBoxModel;
using Jadcup.Services.Model.SuborderLogModel;
using Jadcup.Services.Model.ApplicationDetailsModel;
using Jadcup.Services.Model.RawMaterialApplicationModel;
using Jadcup.Services.Model.WorkingArrangementModel;
using Jadcup.Services.Model.BoxModel;
using Jadcup.Services.Model.BoxStatusModel;
using Jadcup.Services.Model.Ticket;
using Jadcup.Services.Model.TicketProcessModel;
using Jadcup.Services.Model.PlateModel;
using Jadcup.Services.Model.PlateBoxModel;
using Jadcup.Services.Model.ReturnItemModel;
using Jadcup.Services.Model.InspectionPlanModel;
using Jadcup.Services.Model.InspectionLogModel;
using Jadcup.Services.Model.StandardModel;
using Jadcup.Services.Model.TempZoneModel;
using Jadcup.Services.Model.StockLogModel;
using Jadcup.Services.Model.ShelfModel;
using Jadcup.Services.Model.CellModel;
using Jadcup.Services.Model.ContractTypeModel;
using Jadcup.Services.Model.ShelfPlateModel;
using Jadcup.Services.Model.ExtraAddressModel;
using Jadcup.Services.Model.DispatchingStatusModel;
using Jadcup.Services.Model.CourierModel;
using Jadcup.Services.Model.DispatchingDetailsModel;
using Jadcup.Services.Model.DispatchingModel;
using Jadcup.Services.Model.OrderSourceModel;
using Jadcup.Services.Model.SupplierModel;
using Jadcup.Services.Model.QualificationModel;
using Jadcup.Services.Model.OnlineUserModel;
using Jadcup.Services.Model.SupplierRawMaterialModel;
using Jadcup.Services.Model.PoStatusModel;
using Jadcup.Services.Model.PoDetailModel;
using Jadcup.Services.Model.PurchaseOrderModel;
using Jadcup.Services.Model.UnloadingInspectionModel;
using Jadcup.Services.Model.ProductMachineMappingModel;
using Jadcup.Services.Model.ProductOptionModel;
using Jadcup.Services.Model.RawMaterialStockModel;
using Jadcup.Services.Model.OrderOptionModel;
using Jadcup.Services.Model.HumanResource.Quarter;
using Jadcup.Services.Model.PalletStackingModel;
using Jadcup.Services.Model.InvoiceModel;
using Jadcup.Services.Model.InvoiceItemModel;
using Jadcup.Services.Model.TicketTypeModel;
using Jadcup.Services.Model.ProductPriceModel;
using Jadcup.Services.Model.SalesVistModel;
using Jadcup.Services.Model.NotificationModel;
using Jadcup.Services.Model.NotificationModal;
using Jadcup.Services.Model.ProductForShowingModel;
using Jadcup.Services.Model.RecordTypeModel;
using Jadcup.Services.Model.SalesReportModel;
using Jadcup.Services.Model.ZoneTypeModel;
using Jadcup.Services.Model.AssessmentModel;

namespace Jadcup.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Sales Visit Map
            CreateMap<SalesVisitPlan, GetSalesVisitDto>();
            CreateMap<AddSaleVistDto, SalesVisitPlan>();
            CreateMap<UpdateSalesVisit, SalesVisitPlan>();

            // Notification Map
            CreateMap<Notification, GetNotificationDto>();
            CreateMap<AddNotificationDto, Notification>();
            CreateMap<UpdateNotification, Notification>();

            // Invoice Report Map
            CreateMap<Invoice, GetSalesReportDto>();
            CreateMap<Invoice, GetSalesReportBySalesDto>();
            CreateMap<Invoice, AllSalesReportByCustomerDto>();
            CreateMap<Orders, OrderForSalesReportDto>();

            // Assessment Standard Map
            CreateMap<AddStandardDto, AccessmentStandards>();
            CreateMap<AccessmentStandards, GetAllAssessmentStandardDto>();
            CreateMap<UpdateStandardDto, AccessmentStandards>();

            // Assessment Standard Details Map
            CreateMap<AddStandardDetailsDto, AccessmentStandardsDetail>();
            CreateMap<AccessmentStandardsDetail, GetAllAssessmentStandardDetailsDto>();
            CreateMap<UpdateStandardDetailsDto, AccessmentStandardsDetail>();

            // Assessment Plan Map
            CreateMap<AddAssessmentPlanDto, AccessmentPlan>();
            CreateMap<AccessmentPlan, AssessmentPlanDto>();
            CreateMap<AccessmentPlan, AssessmentPlanDto2>();
            CreateMap<UpdateAssessmentPlanDto, AccessmentPlan>();

            // Assessment Map
            CreateMap<AddOneAssessmentDto, Accessment>();
            CreateMap<Accessment, AccessmentDto>();
            CreateMap<UpdateOneAssessmentDto, Accessment>();


            // Assessment Details Map
            CreateMap<AddAssessmentDetailsDto, AccessmentDetail>();
            CreateMap<AccessmentDetail, AccessmentDetailsDto>();
            CreateMap<UpdateAssessmentDetailDto, AccessmentDetail>();


            CreateMap<EmployeeRegisterDto, Employee>();
            CreateMap<Employee, GetEmployeeDto>();
            CreateMap<GetEmployeeDto, Employee > ();
            CreateMap<Employee, GetEmployeeDto2>();
            CreateMap<Employee, GetEmployeeDto3>();
            CreateMap<UpdateEmployeeDto, Employee>();

            CreateMap<AddCustomerDto, Customer>().ForMember(dest => dest.ExtraAddress, opt => opt.Ignore());
            CreateMap<AddCustomerDto2, Customer>();
            CreateMap<Customer, AddCustomerDto2>();
            CreateMap<Customer, GetCustomerDto>();
            CreateMap<Customer, GetCustomerDto2>();
            CreateMap<Customer, CustomerExistDto>();
            CreateMap<Invoice, CustomerExistDto>();
            CreateMap<UpdateCustomerDto, Customer>();

            CreateMap<RawMaterial, GetRawMaterialStockDto>();

            CreateMap<AddItemDto, Item>();

            CreateMap<Action, GetActionDto>();

            CreateMap<Stock, GetStockDto>();

            CreateMap<OrderStatus, GetOrderStatusDto>();

            CreateMap<SuborderStatus, GetSuborderStatusDto>();

            CreateMap<Parameter, GetParameterDto>();

            CreateMap<OrderType, GetOrderTypeDto>();

            CreateMap<DispatchingStatus, GetDispatchingStatusDto>();

            CreateMap<Dispatching, GetDispatchingDto>();

            CreateMap<PoStatus, GetPoStatusDto>();

            CreateMap<TempZone, GetTempZoneDto>();
            CreateMap<TempZone, GetTempZoneDto2>();
            

            CreateMap<WorkOrderSource, GetWorkOrderSourceDto>();
   
            CreateMap<WorkOrderStatus, GetWorkOrderStatusDto>();

            CreateMap<Box, GetBoxDto>();
            CreateMap<Box, GetBoxDto2>();
            CreateMap<Box, GetBoxDto3>();
            CreateMap<Box, GetBoxDto4>();
            CreateMap<AddBoxDto, Box>();

            CreateMap<BoxStatus, GetBoxStatusDto>();

            CreateMap<ApplicationDetails, GetApplicationDetailsDto>();
            CreateMap<AddApplicationDetailsDto, ApplicationDetails>();

            CreateMap<Orders, GetOrderDto>();
            CreateMap<Orders, GetOrderDto3>();
            CreateMap<Orders, GetOrderDto4>();
            CreateMap<Orders, GetOrderDto5>();
            CreateMap<UpdateOrderDto, Orders>().ForMember(dest => dest.OrderOption, opt => opt.Ignore());
            CreateMap<UpdateOrderDto2, Orders>().ForMember(dest => dest.OrderProduct, opt => opt.Ignore());
            CreateMap<UpdateOrderDto2, AddOrderDto2>();
            CreateMap<AddOrderDto, Orders>();
            CreateMap<AddOrderDto2, Orders>().ForMember(dest => dest.OrderProduct, opt => opt.Ignore()).ForMember(dest => dest.OrderOption, opt => opt.Ignore());

            CreateMap<AddRoleDto, Role>();
            CreateMap<Role, GetRoleDto>();
            CreateMap<UpdateRoleDto, Role>();

            CreateMap<AddBrandDto, Brand>();
            CreateMap<Brand, GetBrandDto>();
            CreateMap<UpdateBrandDto, Brand>();

            CreateMap<AddCityDto, City>();
            CreateMap<City, GetCityDto>();
            CreateMap<UpdateCityDto, City>();

            CreateMap<AddGroup1Dto, CustomerGrp1>();
            CreateMap<CustomerGrp1, GetGroup1Dto>();
            CreateMap<UpdateGroup1Dto, CustomerGrp1>();

            CreateMap<AddGroup2Dto, CustomerGrp2>();
            CreateMap<CustomerGrp2, GetGroup2Dto>();
            CreateMap<UpdateGroup2Dto, CustomerGrp2>();

            CreateMap<AddGroup3Dto, CustomerGrp3>();
            CreateMap<CustomerGrp3, GetGroup3Dto>();
            CreateMap<UpdateGroup3Dto, CustomerGrp3>();

            CreateMap<AddGroup4Dto, CustomerGrp4>();
            CreateMap<CustomerGrp4, GetGroup4Dto>();
            CreateMap<UpdateGroup4Dto, CustomerGrp4>();

            CreateMap<AddGroup5Dto, CustomerGrp5>();
            CreateMap<CustomerGrp5, GetGroup5Dto>();
            CreateMap<UpdateGroup5Dto, CustomerGrp5>();

            CreateMap<AddCustomerSourceDto, CustomerSource>();
            CreateMap<CustomerSource, GetCustomerSourceDto>();
            CreateMap<UpdateCustomerSourceDto, CustomerSource>();

            CreateMap<AddPaymentCycleDto, PaymentCycle>();
            CreateMap<PaymentCycle, GetPaymentCycleDto>();
            CreateMap<UpdatePaymentCycleDto, PaymentCycle>();

            CreateMap<CustomerStatus, GetCustomerStatusDto>();

            CreateMap<AddDepartmentDto, Dept>();
            CreateMap<Dept, GetDepartmentDto>();
            CreateMap<Dept, GetDepartmentWithStandardDto>();
            CreateMap<UpdateDepartmentDto, Dept>();

            CreateMap<AddPageDto, Page>();
            CreateMap<Page, GetPageDto>();
            CreateMap<Page, GetPageDto2>();
            CreateMap<GetPageDto2,Page>();   
            CreateMap<GetPageGroupDto2, PageGroup>();                     
            CreateMap<UpdatePageDto, Page>();

            CreateMap<AddPageGroupDto, PageGroup>();
            CreateMap<PageGroup, GetPageGroupDto>();
            CreateMap<UpdatePageGroupDto, PageGroup>();
            CreateMap<Page, PageGroupPageDto>();

            CreateMap<AddRolePageDto, RolePageMapping>();
            CreateMap<RolePageMapping, GetRolePageDto>();

            CreateMap<AddProductTypeDto, ProductType>();
            CreateMap<ProductType, GetProductTypeDto>();
            CreateMap<UpdateProductTypeDto, ProductType>();

            CreateMap<AddRawMaterialDto, RawMaterial>();
            CreateMap<RawMaterial, GetRawMaterialDto>();
            CreateMap<UpdateRawMaterialDto, RawMaterial>();

            CreateMap<AddBaseProductDto, BaseProduct>();
            CreateMap<BaseProduct, GetBaseProductDto>();
            CreateMap<BaseProduct, GetBaseProductDto2>();
            CreateMap<BaseProduct, GetBaseProductDto3>();
            CreateMap<UpdateBaseProductDto, BaseProduct>();

            CreateMap<AddPlateTypeDto, PlateType>();
            CreateMap<PlateType, GetPlateTypeDto>();
            CreateMap<UpdatePlateTypeDto, PlateType>();

            
            CreateMap<AddProductDto, Product>();
            CreateMap<Product, GetProductDto>();
            CreateMap<Product, GetProductDto2>();
            CreateMap<Product, GetProductDto3>();
            CreateMap<Product, GetProductDto4>();
            CreateMap<Product, GetProductDtoImage>();
            CreateMap<UpdateProductDto, Product>();

            CreateMap<Price, GetPriceDto>();
            CreateMap<Price, GetPriceDto2>();
            CreateMap<UpdatePriceDto, Price>();
            CreateMap<AddPriceDto, Price>();

            CreateMap<AddQuotationOptionItemDto, QuotationOptionItem>();
            CreateMap<QuotationOptionItem, GetQuotationOptionItemDto>();
            CreateMap<UpdateQuotationOptionItemDto, QuotationOptionItem>();

            CreateMap<AddQuotationOptionDto, QuotationOption>();
            CreateMap<QuotationOption, GetQuotationOptionDto>();
            CreateMap<UpdateQuotationOptionDto, QuotationOption>();

            CreateMap<AddQuotationItemDto, QuotationItem>();
            CreateMap<QuotationItem, GetQuotationItemDto>();
            CreateMap<QuotationItem, GetQuotationItemDto2>();
            CreateMap<UpdateQuotationItemDto, QuotationItem>();

            CreateMap<AddPackagingTypeDto, PackagingType>();
            CreateMap<PackagingType, GetPackagingTypeDto>();
            CreateMap<UpdatePackagingTypeDto, PackagingType>();

            CreateMap<AddDeliveryMethodDto, DeliveryMethod>();
            CreateMap<DeliveryMethod, GetDeliveryMethodDto>();
            CreateMap<UpdateDeliveryMethodDto, DeliveryMethod>();

            CreateMap<AddQuotationDto, Quotation>();
            CreateMap<Quotation, GetQuotationDto>();
            CreateMap<UpdateQuotationDto, Quotation>().ForMember(d => d.QuotationItem, opt => opt.Ignore()).ForMember(d => d.QuotationOption, opt => opt.Ignore());
            CreateMap<AddQuotationDto2, Quotation>().ForMember(d => d.QuotationItem, opt => opt.Ignore()).ForMember(d => d.QuotationOption, opt => opt.Ignore());

            CreateMap<AddOrderProductDto, OrderProduct>();
            CreateMap<OrderProduct, GetOrderProductDto>();
            CreateMap<OrderProduct, GetOrderProductDto2>();
            CreateMap<OrderProduct, GetOrderProductDto3>();
            CreateMap<UpdateOrderProductDto, OrderProduct>();

            CreateMap<AddProductTypeActionDto, ProductTypeAction>();
            CreateMap<ProductTypeAction, GetProductTypeActionDto>();
            CreateMap<UpdateProductTypeActionDto, ProductTypeAction>();

            CreateMap<AddMachineTypeDto, MachineType>();
            CreateMap<MachineType, GetMachineTypeDto>();
            CreateMap<UpdateMachineTypeDto, MachineType>();

            CreateMap<AddMachineDto, Machine>();
            CreateMap<Machine, GetMachineDto>();
            CreateMap<Machine, GetMachineDto2>();
            CreateMap<UpdateMachineDto, Machine>();

            CreateMap<Suborder, GetSuborderDto>();
            CreateMap<Suborder, GetSuborderDto2>();
            CreateMap<Suborder, GetSuborderDto3>();
            CreateMap<Suborder, GetSuborderDto4>();
            CreateMap<GetSuborderDto4, GetSuborderDto5>();            
            CreateMap<AddSuborderDto, Suborder>();
            CreateMap<Suborder, AddSuborderDto>();

            CreateMap<Zone, GetZoneDto>();
            CreateMap<Zone, GetZoneDto2>();
            CreateMap<ZoneType, GetZoneTypeDto>();
            CreateMap<UpdateZoneDto, Zone>();
            CreateMap<AddZoneDto, Zone>();

            CreateMap<WorkOrder, GetWorkOrderDto>();
            CreateMap<WorkOrder, GetWorkOrderDto2>();
            CreateMap<AddWorkOrderDto, WorkOrder>();

            CreateMap<RawMaterialBox, GetRawMaterialBoxDto>();
            CreateMap<RawMaterialBox, GetRawMaterialBoxDto2>();
            CreateMap<RawMaterialBox, GetRawMaterialBoxDto3>();
            CreateMap<AddRawMaterialBoxDto, RawMaterialBox>();
            CreateMap<UpdateRawmaterialBoxDto, RawMaterialBox>();


            CreateMap<RawMaterialApplication, GetRawMaterialApplicationDto>();
            CreateMap<AddRawMaterialApplicationDto, RawMaterialApplication>();

            CreateMap<AddSuborderLogDto, SuborderLog>();
            CreateMap<SuborderLog, GetSuborderLogDto>();
            CreateMap<SuborderLog, GetSuborderLogDto2>();

            CreateMap<AddWorkingArrangementDto, WorkingArrangement>();
            CreateMap<WorkingArrangement, GetWorkingArrangementDto>();
            CreateMap<UpdateWorkingArrangementDto, WorkingArrangement>();

            CreateMap<Plate, GetPlateDto>();
            CreateMap<Plate, GetPlateDto2>();
            CreateMap<UpdatePlateDto, Plate>();

            CreateMap<AddPlateBoxDto, PlateBox>();
            CreateMap<AddPlateBoxDto2, PlateBox>();
            CreateMap<PlateBox, GetPlateBoxDto>();
            CreateMap<PlateBox, GetPlateBoxDto2>();
            CreateMap<UpdatePlateBoxDto, PlateBox>();
            CreateMap<UpdatePlateBoxDto2, PlateBox>();

            CreateMap<AddStockLogDto, StockLog>();

            CreateMap<Shelf, GetShelfDto>();
            CreateMap<Shelf, GetShelfDto2>();
            CreateMap<AddShelfDto, Shelf>();
            CreateMap<UpdateShelfDto, Shelf>();

            CreateMap<Cell, GetCellDto>();
            CreateMap<Cell, GetCellDto2>();
            CreateMap<Cell, GetCellDto3>();
            CreateMap<AddCellDto, Cell>();
            CreateMap<UpdateCellDto, Cell>();

            CreateMap<ShelfPlate, GetShelfPlateDto>();
            CreateMap<AddShelfPlateDto, ShelfPlate>();
            CreateMap<UpdateShelfPlateDto, ShelfPlate>();

            CreateMap<AddExtraAddressDto, ExtraAddress>();
            CreateMap<ExtraAddress, GetExtraAddressDto>();
            CreateMap<UpdateExtraAddressDto, ExtraAddress>();

            CreateMap<Courier, GetCourierDto>();
            CreateMap<AddCourierDto, Courier>();
            CreateMap<UpdateCourierDto, Courier>();

            CreateMap<DispatchingDetails, GetDispatchingDetailsDto>();
            CreateMap<AddDispatchingDetailsDto, DispatchingDetails>();

            CreateMap<Suplier, GetSupplierDto>();
            CreateMap<Suplier, GetSupplierDto2>();
            CreateMap<AddSupplierDto, Suplier>();
            CreateMap<AddSupplierDto2, Suplier>().ForMember(d => d.Qualification, opt => opt.Ignore());
            CreateMap<UpdateSupplierDto, Suplier>();

            CreateMap<Qualification, GetQualificationDto>();
            CreateMap<AddQualificationDto, Qualification>();
            CreateMap<UpdateQualificationDto, Qualification>();

            CreateMap<SuplierRawMaterial, GetSupplierRawMaterialDto>();
            CreateMap<AddSupplierRawMaterialDto, SuplierRawMaterial>();
            CreateMap<GetSupplierRawMaterialDto, SuplierRawMaterial>();

            CreateMap<PoDetail, GetPoDetailDto>();
            CreateMap<AddPoDetailDto, PoDetail>();

            CreateMap<PurchaseOrder, GetPurchaseOrderDto>();
            CreateMap<PurchaseOrder, GetPurchaseOrderDto2>();
            CreateMap<AddPurchaseOrderDto, PurchaseOrder>().ForMember(dest => dest.PoDetail, opt => opt.Ignore());
            CreateMap<UpdatePurchaseOrderDto, PurchaseOrder>().ForMember(dest => dest.PoDetail, opt => opt.Ignore());

            CreateMap<UnloadingInspection, GetUnloadingInspectionDto>();
            CreateMap<UnloadingInspection, GetUnloadingInspectionDto2>();
            CreateMap<AddUnloadingInspectionDto, UnloadingInspection>();
            CreateMap<UpdateUnloadingInspectionDto, UnloadingInspection>();

            CreateMap<ProductMachineMapping, GetProductMachineMappingDto>();
            CreateMap<AddProductMachineMappingDto, ProductMachineMapping>();

            CreateMap<ProductOption, GetProductOptionDto>();
            CreateMap<AddProductOptionDto, ProductOption>();
            CreateMap<UpdateProductOptionDto, ProductOption>();

            CreateMap<OrderOption, GetOrderOptionDto>();
            CreateMap<AddOrderOptionDto, OrderOption>();
            CreateMap<UpdateOrderOptionDto, OrderOption>();

            CreateMap<Quarter, GetQuarterDto>();
            CreateMap<AddQuarterDto, Quarter>();
            CreateMap<UpdateQuarterDto, Quarter>();

            CreateMap<HumanResource, GetHumanResourceDto>();
            CreateMap<AddHumanResourceDto, HumanResource>();
            CreateMap<UpdateHumanResourceDto, HumanResource>();

            CreateMap<SalaryFactor, GetSalaryFactorDto>();
            CreateMap<AddSalaryFactorDto, SalaryFactor>();
            CreateMap<UpdateSalaryFactorDto, SalaryFactor>();

            CreateMap<AttachedRecord, GetAttachedRecordDto>();
            CreateMap<AddAttachedRecordDto, AttachedRecord>();
            CreateMap<UpdateAttachedRecordDto, AttachedRecord>();

            CreateMap<Contract, GetContractDto>();   
            CreateMap<RecordType, GetRecordTypeDto>();   
            CreateMap<ContractType, GetContractTypeDto>();

            CreateMap<BaseProduct, GetProductForShowingDto>();

            CreateMap<AddContractDto, Contract>();
            CreateMap<UpdateContractDto, Contract>();

            CreateMap<PalletStacking, GetPalletStackingDto>();          
            CreateMap<AddPalletStackingDto, PalletStacking>();
            CreateMap<UpdatePalletStackingDto, PalletStacking>();
                

            CreateMap<AddTicketDto, Ticket>().ForMember(dest => dest.TicketProcess, opt => opt.Ignore());
            CreateMap<Ticket, GetTicketDto>();
            CreateMap<UpdateTicketDto, Ticket>();
            CreateMap<UpdateTicketDto2, Ticket>().ForMember(dest => dest.RedeliveryOrder, opt => opt.Ignore());

            CreateMap<TicketProcess, GetTicketProcessDto>();
            CreateMap<AddTicketProcessDto, TicketProcess>();
            CreateMap<UpdateTicketProcessDto, TicketProcess>();
            
            CreateMap<AddReturnItemDto, ReturnItem>();
            CreateMap<ReturnItem, GetReturnItemDto>();
            CreateMap<UpdateReturnItemDto, ReturnItem>();
            CreateMap<UpdateReturnItemDto2, ReturnItem>();

            CreateMap<TicketType, GetTicketTypeDto>();

            CreateMap<AddInspectionPlanDto, InspectionPlan>().ForMember(dest => dest.StartTime, opt => opt.Ignore()).ForMember(dest => dest.EndTime, opt => opt.Ignore());
            CreateMap<InspectionPlan, GetInspectionPlanDto>();
            CreateMap<UpdateInspectionPlanDto, InspectionPlan>().ForMember(dest => dest.StartTime, opt => opt.Ignore()).ForMember(dest => dest.EndTime, opt => opt.Ignore());
            CreateMap<Standard, GetStandardDto>();
            CreateMap<InspectionLog, GetInspectionLogDto>();
            CreateMap<UpdateInspectionLogDto, InspectionLog>();

            CreateMap<Invoice, GetInvoiceDto>();
            CreateMap<UpdateInvoiceDto, Invoice>().ForMember(dest => dest.InvoiceItem, opt => opt.Ignore());

            CreateMap<InvoiceItem, GetInvoiceItemDto>();
            CreateMap<UpdateInvoiceItemDto, InvoiceItem>();
           

            CreateMap<AddOrderFromCustomerDto, Orders>();
            CreateMap<AddOrderFromCustomerDto, AddOrderDto2>();
            CreateMap<Orders, GetOrderDto2>();
            CreateMap<OrderSource, GetOrderSourceDto>();
            CreateMap<UpdateOrderDto3, Orders>();

            CreateMap<AddOnlineUserDto, OnlineUser>();
            CreateMap<AddProductPriceDto, ProductPrice>();
            CreateMap<UpdateProductPriceDto, ProductPrice>();
            CreateMap<ProductPrice, GetProductPriceDto>();            

        }
    }
}
