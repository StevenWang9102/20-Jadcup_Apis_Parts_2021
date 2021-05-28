using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.OrderProductService;
using Jadcup.Services.Interface.OrderService;
using Jadcup.Services.Interface.ProductService;
using Jadcup.Services.Interface.InvoiceService;
using Jadcup.Services.Interface.WorkOrderService;
using Jadcup.Services.Model.OrderModel;
using Jadcup.Services.Model.OrderOptionModel;
using Jadcup.Services.Model.OrderProductModel;
using Jadcup.Services.Model.WorkOrderModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.OrderService
{
    public class OrderManagementService : IOrderManagementService
    {
        private readonly IGenericMySqlAccessRepository<Orders> _orderRepo;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<OrderProduct> _orderProductRepo;
        private readonly IGenericMySqlAccessRepository<WorkOrder> _workOrderRepo;
        private readonly IGenericMySqlAccessRepository<Suborder> _subOrderRepo;
        private readonly IOrderProductManagementService _orderProductManagementService;
        private readonly IProductManagementService _productManagementService;
        private readonly IInvoiceManagementService _invoiceManagementService;        
        private readonly IGenericMySqlAccessRepository<Parameter> _parameterRepo;
        private readonly IWorkOrderManagementService _workOrderManagementSerivce;
        private readonly IGenericMySqlAccessRepository<Stock> _stockRepo;
        private readonly IGenericMySqlAccessRepository<Item> _itemRepo;
        private readonly IGenericMySqlAccessRepository<Dispatching> _dispatchingRepo;
        private readonly IGenericMySqlAccessRepository<OrderOption> _orderOptionRepo;
        private readonly IGenericMySqlAccessRepository<ProductTypeAction> _productTypeAction;
        private readonly IGenericMySqlAccessRepository<Product> _productRepo;        
        private readonly IGenericMySqlAccessRepository<Customer> _customerRepo;   
        const short Prepay = 6;          
        public OrderManagementService(
            IGenericMySqlAccessRepository<Orders> orderRepo,
            IMapper mapper,
            IGenericMySqlAccessRepository<OrderProduct> orderProductRepo,
            IGenericMySqlAccessRepository<WorkOrder> workOrderRepo,
            IGenericMySqlAccessRepository<Suborder> subOrderRepo,
            IOrderProductManagementService orderProductManagementService,
            IProductManagementService productManagementService,
            IGenericMySqlAccessRepository<Parameter> parameterRepo,
            IWorkOrderManagementService workOrderManagementSerivce,
            IInvoiceManagementService  invoiceManagementService,
            IGenericMySqlAccessRepository<Stock> stockRepo,
            IGenericMySqlAccessRepository<Customer> customerRepo,
            IGenericMySqlAccessRepository<Item> itemRepo,
            IGenericMySqlAccessRepository<Dispatching> dispatchingRepo,
            IGenericMySqlAccessRepository<OrderOption> orderOptionRepo,
            IGenericMySqlAccessRepository<ProductTypeAction> productTypeAction,
            IGenericMySqlAccessRepository<Product> product)
        {
            _orderProductRepo = orderProductRepo;
            _workOrderRepo = workOrderRepo;
            _subOrderRepo = subOrderRepo;
            _orderProductManagementService = orderProductManagementService;
            _productManagementService = productManagementService;
            _parameterRepo = parameterRepo;
            _workOrderManagementSerivce = workOrderManagementSerivce;
            _invoiceManagementService = invoiceManagementService;
            _stockRepo = stockRepo;
            _customerRepo = customerRepo;
            _itemRepo = itemRepo;
            _dispatchingRepo = dispatchingRepo;
            _orderOptionRepo = orderOptionRepo;
            _mapper = mapper;
            _orderRepo = orderRepo;
            _productTypeAction = productTypeAction;
            _productRepo = product;
        }

        public async Task<TaskResponse<bool>> Delete(string id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Orders order = await _orderRepo.GetAsync(id);

            if (order == null || order.Active == 0)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }


            if (order.OrderStatusId <= 10 || order.OrderStatusId >= 1)
            {
                await DeleteWorkOrderAndSuborder(id);
            }

            bool dispatched = await _dispatchingRepo.GetQueryable().AnyAsync(d => d.OrderId == order.OrderId && d.Status == 2);
            if (dispatched)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage("Order Already Dispatched. Cannot Cancel Order Now."));
            }

            List<Dispatching> dispatchings = await _dispatchingRepo.GetQueryable().Where(d => d.OrderId == id).ToListAsync();
            foreach (Dispatching dispatching in dispatchings)
            {
                dispatching.Status = 0;
                _dispatchingRepo.UpdateT(dispatching);
            }
            
            order.Active = 0;
            order.OrderStatusId = 0;

            _orderRepo.UpdateT(order);
            await _orderRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetOrderDto>>> GetAll(sbyte? orderStatusId, DateTime? start, DateTime? end)
        {
            TaskResponse<List<GetOrderDto>> response = new TaskResponse<List<GetOrderDto>>();
            List<GetOrderDto> results = new List<GetOrderDto>();

            List<Orders> orders = await _orderRepo.GetQueryable()
                .Where(o => o.Active == 1)
                .Where(o => orderStatusId == null || o.OrderStatusId == orderStatusId)
                .Where(o => start == null || o.UpdatedAt >= start)
                .Where(o => end == null || o.UpdatedAt <= end)
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.DeliveryCity)
                .Include(o => o.DeliveryMethod)
                .Include(o => o.OrderStatus)
                .Include(o => o.OrderProduct)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();

            Parameter warningDays = await _parameterRepo.GetQueryable().FirstOrDefaultAsync(p => p.ParaName == "OrderWarningDays");
            Parameter alarmDays = await _parameterRepo.GetQueryable().FirstOrDefaultAsync(p => p.ParaName == "OrderAlarmDays");

            foreach (Orders o in orders)
            {
                o.OrderProduct = await _orderProductRepo
                    .GetQueryable()
                    .Where(p => p.OrderId == o.OrderId)
                    .Include(p => p.Product)
                    .ToListAsync();
                o.OrderOption = await _orderOptionRepo.GetQueryable()
                    .Where(oo => o.OrderId == oo.OrderId)
                    .Include(oo => oo.Option)
                    .ToListAsync();

                GetOrderDto result = _mapper.Map<GetOrderDto>(o);

                if (DateTime.UtcNow.Date > o.RequiredDate.Value.Date)
                {
                    result.DueStatus = 3;
                }
                else
                {
                    int daysToRequiredDate = (o.RequiredDate.Value.Date - DateTime.UtcNow.Date).Days;
                    if (daysToRequiredDate > warningDays.Value)
                    {
                        result.DueStatus = 0;
                    }
                    else if (daysToRequiredDate <= warningDays.Value && daysToRequiredDate > alarmDays.Value)
                    {
                        result.DueStatus = 1;
                    }
                    else if (daysToRequiredDate <= alarmDays.Value)
                    {
                        result.DueStatus = 2;
                    }
                }
                results.Add(result);
            }

            response.Data = results;
            return response;
        }


        public async Task<TaskResponse<List<GetOrderDto>>> GetByCust(int customerId)
        {
            TaskResponse<List<GetOrderDto>> response = new TaskResponse<List<GetOrderDto>>();
            List<GetOrderDto> results = new List<GetOrderDto>();

            List<Orders> orders = await _orderRepo.GetQueryable()
                .Where(o => o.Active == 1)
                .Where(o => o.CustomerId == customerId)
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.DeliveryCity)
                .Include(o => o.DeliveryMethod)
                .Include(o => o.OrderStatus)
                .Include(o => o.OrderProduct)
                .OrderBy(o => o.RequiredDate)
                .ToListAsync();

            Parameter warningDays = await _parameterRepo.GetQueryable().FirstOrDefaultAsync(p => p.ParaName == "OrderWarningDays");
            Parameter alarmDays = await _parameterRepo.GetQueryable().FirstOrDefaultAsync(p => p.ParaName == "OrderAlarmDays");

            foreach (Orders o in orders)
            {
                o.OrderProduct = await _orderProductRepo
                    .GetQueryable()
                    .Where(p => p.OrderId == o.OrderId)
                    .Include(p => p.Product)
                    .ToListAsync();
                o.OrderOption = await _orderOptionRepo.GetQueryable()
                    .Where(oo => o.OrderId == oo.OrderId)
                    .Include(oo => oo.Option)
                    .ToListAsync();

                GetOrderDto result = _mapper.Map<GetOrderDto>(o);

                if (DateTime.UtcNow.Date > o.RequiredDate.Value.Date)
                {
                    result.DueStatus = 3;
                }
                else
                {
                    int daysToRequiredDate = (o.RequiredDate.Value.Date - DateTime.UtcNow.Date).Days;
                    if (daysToRequiredDate > warningDays.Value)
                    {
                        result.DueStatus = 0;
                    }
                    else if (daysToRequiredDate <= warningDays.Value && daysToRequiredDate > alarmDays.Value)
                    {
                        result.DueStatus = 1;
                    }
                    else if (daysToRequiredDate <= alarmDays.Value)
                    {
                        result.DueStatus = 2;
                    }
                }
                results.Add(result);
            }

            response.Data = results;
            return response;
        }

        public async Task<TaskResponse<GetOrderDto>> GetById(string id)
        {
            TaskResponse<GetOrderDto> response = new TaskResponse<GetOrderDto>();

            Orders order = await _orderRepo.GetQueryable()
                .Where(o => o.Active == 1)
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.DeliveryCity)
                .Include(o => o.DeliveryMethod)
                .Include(o => o.OrderStatus)
                .Include(o => o.OrderProduct)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }


            order.OrderProduct = await _orderProductRepo
                .GetQueryable()
                .Where(p => p.OrderId == id)
                .Include(p => p.Product)
                .ToListAsync();
            order.OrderOption = await _orderOptionRepo.GetQueryable()
                    .Where(oo => order.OrderId == oo.OrderId)
                    .Include(oo => oo.Option)
                    .ToListAsync();

            response.Data = _mapper.Map<GetOrderDto>(order);
            return response;
        }

        public async Task<TaskResponse<bool>> Update(UpdateOrderDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Orders order = await _orderRepo.GetQueryable().Where(o => o.Active == 1).FirstOrDefaultAsync(o => o.OrderId == request.OrderId);

            if (order == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _mapper.Map(request, order);
            order.UpdatedAt = DateTime.UtcNow;
            _orderRepo.UpdateT(order);

            List<OrderOption> dbOptions = await _orderOptionRepo.GetQueryable().Where(oo => oo.OrderId == request.OrderId).ToListAsync();
            _orderOptionRepo.DeleteRange(dbOptions);

            List<OrderOption> orderOptions = new List<OrderOption>();
            foreach (AddOrderOptionDto orderOption in request.OrderOption)
            {
                OrderOption op = _mapper.Map<OrderOption>(orderOption);
                op.OrderOptionId = Guid.NewGuid().ToString();
                op.OrderId = order.OrderId;

                orderOptions.Add(op);
            }
            _orderOptionRepo.InsertRange(orderOptions);

            await _orderRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<string>> AddAll(AddOrderDto2 request)
        {
            TaskResponse<string> response = new TaskResponse<string>();


            Customer customer =await _customerRepo.GetAsync(request.CustomerId);

            bool isPrepay = customer.PaymentCycleId==Prepay; 
            
            using var transaction = _orderRepo.GetContext().Database.BeginTransaction();
            try
            {
                bool approved = !isPrepay;
                string id = await AddFullOrder(request,approved);

                response.Data = id;
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage(ex.ToString()));
            }

            return response;

        }

        public async Task<TaskResponse<bool>> UpdateAll(UpdateOrderDto2 request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();
            Orders dbOrder = await _orderRepo.GetQueryable().Where(o => o.Active == 1).FirstOrDefaultAsync(o => o.OrderId == request.OrderId);
            if (dbOrder == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            if (dbOrder.OrderStatusId > 10)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage("Production Finished. Order cannot be updated."));
            }

            dbOrder.Active = 0;
            using var transaction = _orderRepo.GetContext().Database.BeginTransaction();

            try
            {
                _orderRepo.UpdateT(dbOrder);
                await DeleteWorkOrderAndSuborder(dbOrder.OrderId);

                AddOrderDto2 addOrder = _mapper.Map<AddOrderDto2>(request);

                string id ;
                if (dbOrder.OrderStatusId==2 ||dbOrder.OrderStatusId==4)
                    id = await AddFullOrder(addOrder,false);
                else
                    id = await AddFullOrder(addOrder,true);
                    
                Orders updatedOrder = await _orderRepo.GetAsync(id);
                updatedOrder.EmployeeId = request.EmployeeId;
                updatedOrder.Paid = request.Paid;
                updatedOrder.DeliveryDate = request.DeliveryDate;
                updatedOrder.OrderNo = dbOrder.OrderNo;
                updatedOrder.UpdatedAt = DateTime.UtcNow;
                // updatedOrder.OrderStatusId = 1;
                _orderRepo.UpdateT(updatedOrder);
                await _orderRepo.SaveAsync();

                response.Data = true;
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage(ex.ToString()));
            }


            return response;
        }

        public async Task<TaskResponse<bool>> UpdateStatus(string id, sbyte statusId)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();
            Orders order = await _orderRepo.GetAsync(id);

            order.OrderStatusId = statusId;
            _orderRepo.UpdateT(order);
            await _orderRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetOrderDto3>>> GetDispatchable()
        {
            TaskResponse<List<GetOrderDto3>> response = new TaskResponse<List<GetOrderDto3>>();

            List<Orders> dbOrders = await _orderRepo.GetQueryable()
                .Where(o => o.Active == 1)
                .Where(o => o.OrderStatusId < 15 && o.OrderStatusId != 0)
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.DeliveryCity)
                .Include(o => o.DeliveryMethod)
                .Include(o => o.OrderStatus)
                .Include(o => o.OrderProduct)
                .OrderBy(o => o.RequiredDate)
                .ToListAsync();

            List<GetOrderDto3> results = new List<GetOrderDto3>();

            foreach (Orders o in dbOrders)
            {

                o.OrderProduct = await _orderProductRepo
                    .GetQueryable()
                    .Where(p => p.OrderId == o.OrderId)
                    .Include(p => p.Product)
                    .ToListAsync();

                GetOrderDto3 result = _mapper.Map<GetOrderDto3>(o);

                // bool ready = true;

                foreach (GetOrderProductDto3 orderProductDto in result.OrderProduct)
                {

                    Item item = await _itemRepo.GetQueryable().FirstOrDefaultAsync(i => i.ProductId == orderProductDto.ProductId && i.IsSemi == 0);
                    Stock stock = await _stockRepo.GetQueryable().FirstOrDefaultAsync(s => s.ItemId == item.ItemId);
                    orderProductDto.StockQuantity = (int)stock.Quantity;
                }
                results.Add(result);
            }

            response.Data = results;
            return response;
        }



        public async Task<TaskResponse<bool>> FinishDispatch(string orderId)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();
            Orders order = await _orderRepo.GetAsync(orderId);            
            if (order==null)
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage("Can not find this order!"));
            
            List<OrderProduct> orderProducts = await _orderProductRepo.GetQueryable().Where(op => op.OrderId == orderId).ToListAsync();

            foreach (var orderProduct in orderProducts)
            {
                orderProduct.Delivered = 1;
                _orderProductRepo.UpdateT(orderProduct);
            }
            order.OrderStatusId = 15;
            _orderRepo.UpdateT(order);

            if ( order.Paid != 1)
                await _invoiceManagementService.AddInvoice(orderId);

            await _orderRepo.SaveAsync();   
            response.Data = true;
            return response;
        }
        public async Task<TaskResponse<bool>> ApproveOrder(string orderId)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();
            Orders order = await _orderRepo.GetAsync(orderId);            
            if (order==null)
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage("Can not find this order!"));
            
            List<OrderProduct> orderProducts = await _orderProductRepo.GetQueryable().Where(op => op.OrderId == orderId).ToListAsync();

            foreach (var orderProduct in orderProducts)
            {
                await GenerateWorkOrder(orderProduct, order, orderProduct.OrderProductId);
            }
            order.OrderStatusId = 3;
            _orderRepo.UpdateT(order);


            await _orderRepo.SaveAsync();   
            response.Data = true;
            return response;
        }        
        // functions
        private async Task DeleteWorkOrderAndSuborder(string orderId)
        {
            List<OrderProduct> orderProducts = await _orderProductRepo.GetQueryable().Where(op => op.OrderId == orderId).ToListAsync();
            foreach (OrderProduct op in orderProducts)
            {
                WorkOrder workOrder = await _workOrderRepo.GetQueryable().FirstOrDefaultAsync(wo => wo.OrderProductId == op.OrderProductId);
                if (workOrder != null)
                {
                    List<Suborder> suborders = await _subOrderRepo.GetQueryable().Where(so => so.WorkOrderId == workOrder.WorkOrderId).ToListAsync();
                    foreach (Suborder so in suborders)
                    {
                        so.SuborderStatusId = 0;
                        _subOrderRepo.UpdateT(so);
                    }
                    workOrder.WorkOrderStatusId = 0;
                    _workOrderRepo.UpdateT(workOrder);
                }

            }
        }

        public async Task<string> AddFullOrder(AddOrderDto2 request,bool approved)
        {
            // const short Prepay = 6;
            Guid id = Guid.NewGuid();

            Orders order = _mapper.Map<Orders>(request);

            Customer customer =await _customerRepo.GetAsync(order.CustomerId);
            if ( customer.PaymentCycleId==Prepay){
                order.OrderSourceId=3; 
                order.OrderStatusId=2; 
            }

            order.Paid = 0;
            order.OrderNo = await GenerateOrderNumber();
            order.OrderId = id.ToString();
            order.Active = 1;
            order.CreatedAt = DateTime.UtcNow;

            _orderRepo.Insert(order);
            await _orderRepo.SaveAsync();

            List<OrderOption> orderOptions = new List<OrderOption>();
            foreach (AddOrderOptionDto orderOption in request.OrderOption)
            {
                OrderOption op = _mapper.Map<OrderOption>(orderOption);
                op.OrderOptionId = Guid.NewGuid().ToString();
                op.OrderId = order.OrderId;

                orderOptions.Add(op);
            }
            _orderOptionRepo.InsertRange(orderOptions);

            Parameter para = await _parameterRepo.GetAsync((short)2);
            decimal rejectionRate = para.Value;

            if (request.OrderProduct != null)
            {
                foreach (AddOrderProductDto op in request.OrderProduct)
                {
                    op.OrderId = id.ToString();
                    TaskResponse<string> r = await _orderProductManagementService.Add(op);
                    
                    if (!approved) continue;

                    OrderProduct orderProd = _mapper.Map<OrderProduct>(op);
                    bool sucess =await GenerateWorkOrder(orderProd,order,r.Data);
                    
                    // var stocks = await _productManagementService.GetProductStocks(op.ProductId.Value);

                    // if (op.Quantity > stocks.stockDto.Quantity)
                    // {   
                    //     var product =await _productRepo.GetQueryable().Include(p => p.BaseProduct).Where(p => p.ProductId == op.ProductId).FirstOrDefaultAsync();
                    //     var productTypeAction = await _productTypeAction.GetQueryable()
                    //     .Where(pta => pta.ProductTypeId == product.BaseProduct.ProductTypeId)
                    //     .OrderBy(pta => pta.SequenceNo)
                    //     .FirstOrDefaultAsync();
                    //     if (productTypeAction == null) continue;

                    //     AddWorkOrderDto workOrderRequest = new AddWorkOrderDto();

                    //     Guid workOrderId = Guid.NewGuid();

                    //     workOrderRequest.OrderProductId = r.Data;
                    //     workOrderRequest.ProductId = op.ProductId;
                    //     workOrderRequest.CreatedEmployeeId = order.EmployeeId;
                    //     workOrderRequest.Comments = order.Comments;
                    //     workOrderRequest.RequiredDate = order.RequiredDate;
                    //     workOrderRequest.Quantity = (int)Math.Round(op.Quantity * (1 + rejectionRate));
                    //     workOrderRequest.WorkOrderSourceId = 1;
                    //     workOrderRequest.WorkOrderStatusId = -1;
                    //     if (op.Quantity > stocks.semiStockDto.Quantity * (1 + rejectionRate))
                    //     {
                    //         workOrderRequest.OrderTypeId = 1;
                    //     }
                    //     else
                    //     {
                    //         workOrderRequest.OrderTypeId = 3;
                    //     }

                    //     WorkOrder workOrder = _mapper.Map<WorkOrder>(workOrderRequest);
                    //     workOrder.WorkOrderId = workOrderId.ToString();
                    //     workOrder.CreatedAt = DateTime.UtcNow;
                    //     workOrder.WorkOrderNo = await _workOrderManagementSerivce.GenerateWorkOrderNo();

                    //     _workOrderRepo.Insert(workOrder);
                    //     await _workOrderRepo.SaveAsync();
                    // }
                }
            }

            _orderRepo.UpdateT(order);
            await _orderRepo.SaveAsync();
            return order.OrderId;
        }




        private async Task<string> GenerateOrderNumber()
        {
            List<int> numbers = (await _orderRepo.GetQueryable().Select(q => q.OrderNo).ToListAsync()).Select(n => int.Parse(n)).ToList();
            if (numbers.Count == 0)
            {
                return 1.ToString();
            }
            int max = numbers.Max();
            string number = (max + 1).ToString();

            return number;  
        }
        private async Task<bool> GenerateWorkOrder(OrderProduct op, Orders order, string id)
        {
            var stocks = await _productManagementService.GetProductStocks(op.ProductId.Value);

            Parameter para = await _parameterRepo.GetAsync((short)2);
            if (para == null )
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage("Can not find rejection Rate!"));
            decimal rejectionRate = para.Value;


            if (op.Quantity > stocks.stockDto.Quantity)
            {
                var product = await _productRepo.GetQueryable().Include(p => p.BaseProduct).Where(p => p.ProductId == op.ProductId).FirstOrDefaultAsync();
                var productTypeAction = await _productTypeAction.GetQueryable()
                .Where(pta => pta.ProductTypeId == product.BaseProduct.ProductTypeId)
                .OrderBy(pta => pta.SequenceNo)
                .FirstOrDefaultAsync();
                if (productTypeAction == null) return false;

                AddWorkOrderDto workOrderRequest = new AddWorkOrderDto();

                Guid workOrderId = Guid.NewGuid();

                workOrderRequest.OrderProductId = id;
                workOrderRequest.ProductId = op.ProductId;
                workOrderRequest.CreatedEmployeeId = order.EmployeeId;
                workOrderRequest.Comments = order.Comments;
                workOrderRequest.RequiredDate = order.RequiredDate;
                workOrderRequest.Quantity = (int)Math.Round(op.Quantity * (1 + rejectionRate));
                workOrderRequest.WorkOrderSourceId = 1;
                workOrderRequest.WorkOrderStatusId = -1;
                if (op.Quantity > stocks.semiStockDto.Quantity * (1 + rejectionRate))
                {
                    workOrderRequest.OrderTypeId = 1;
                }
                else
                {
                    workOrderRequest.OrderTypeId = 3;
                }
                WorkOrder workOrder = _mapper.Map<WorkOrder>(workOrderRequest);
                workOrder.WorkOrderId = workOrderId.ToString();
                workOrder.CreatedAt = DateTime.UtcNow;
                workOrder.WorkOrderNo = await _workOrderManagementSerivce.GenerateWorkOrderNo();

                _workOrderRepo.Insert(workOrder);
                await _workOrderRepo.SaveAsync();
            }
            return true;
        }
    }
}