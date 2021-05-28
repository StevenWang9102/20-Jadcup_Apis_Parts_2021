using System;
using System.Collections.Generic;
using System.Text;
using Jadcup.Services.Interface.OrderService;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.OrderModel;
using Jadcup.Common.Repository;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Jadcup.Common.Helper;
using System.Linq;
using Jadcup.Services.Service.OrderService;
using Jadcup.Services.Model.OrderProductModel;
using Jadcup.Services.Model.WorkOrderModel;
using Jadcup.Services.Interface.ProductService;
using Jadcup.Services.Interface.OrderProductService;
using Jadcup.Services.Interface.WorkOrderService;
using System.Collections.ObjectModel;

namespace Jadcup.Services.Service.OrderService
{
    public class OrderFromCustomerManagementService : IOrderFromCustomerManagementService
    {
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<Orders> _orderRepo;
        private readonly IGenericMySqlAccessRepository<Parameter> _parameterRepo;
        private readonly OrderManagementService _orderManagementService;
        private readonly IGenericMySqlAccessRepository<OrderProduct> _orderProductRepo;
        private readonly IProductManagementService _productManagementService;
        private readonly IOrderProductManagementService _orderProductManagementService;
        private readonly IWorkOrderManagementService _workOrderManagementSerivce;
        private readonly IGenericMySqlAccessRepository<WorkOrder> _workOrderRepo;
        private readonly IGenericMySqlAccessRepository<Suborder> _subOrderRepo;

        public OrderFromCustomerManagementService(IMapper mapper,
            IGenericMySqlAccessRepository<Orders> orderRepo,
            IGenericMySqlAccessRepository<Parameter> parameterRepo,
            OrderManagementService orderManagementService,
            IGenericMySqlAccessRepository<OrderProduct> orderProductRepo,
            IProductManagementService productManagementService,
            IOrderProductManagementService orderProductManagementService,
            IWorkOrderManagementService workOrderManagementSerivce,
            IGenericMySqlAccessRepository<WorkOrder> workOrderRepo,
            IGenericMySqlAccessRepository<Suborder> subOrderRepo)
        {
            _mapper = mapper;
            _orderRepo = orderRepo;
            _parameterRepo = parameterRepo;
            _orderManagementService = orderManagementService;
            _orderProductRepo = orderProductRepo;
            _productManagementService = productManagementService;
            _orderProductManagementService = orderProductManagementService;
            _workOrderManagementSerivce = workOrderManagementSerivce;
            _workOrderRepo = workOrderRepo;
            _subOrderRepo = subOrderRepo;
        }

        public async Task<TaskResponse<bool>> AddById(AddOrderDto2 request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();
            
            using var transaction = _orderRepo.GetContext().Database.BeginTransaction();
            try
            {
                await AddProductsForOrder(request);
                response.Data = true;
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            //await AddProductsForOrder(request);
            response.Data = true;
            return response;
        }

        public async Task AddProductsForOrder(AddOrderDto2 request)
        {
            Guid id = Guid.NewGuid();
            Orders order = _mapper.Map<Orders>(request);

            order.Paid = 0;
            order.OrderNo = await GenerateOrderNumber();
            order.OrderId = id.ToString();
            order.Active = 1;
            order.CreatedAt = DateTime.UtcNow;
            order.OrderSourceId = 1;

            _orderRepo.Insert(order);
            await _orderRepo.SaveAsync();

            Parameter para = await _parameterRepo.GetAsync((short)2);
            decimal rejectionRate = para.Value;

            if (request.OrderProduct != null)
            {
                foreach (AddOrderProductDto op in request.OrderProduct)
                {
                    op.OrderId = id.ToString();
                    TaskResponse<string> r = await _orderProductManagementService.Add(op);
                    var stocks = await _productManagementService.GetProductStocks(op.ProductId.Value);

                    if (op.Quantity > stocks.stockDto.Quantity)
                    {
                        AddWorkOrderDto workOrderRequest = new AddWorkOrderDto();

                        Guid workOrderId = Guid.NewGuid();

                        workOrderRequest.OrderProductId = r.Data;
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
                }
            }

            _orderRepo.UpdateT(order);
            await _orderRepo.SaveAsync();
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

        public async Task<TaskResponse<List<GetOrderDto2>>> GetAll()
        {
            List<Orders> dbOrders = await _orderRepo.GetQueryable()
                .Where(o => o.OrderSourceId == 1 && o.OrderStatusId != 0 && o.OrderStatusId != 0)
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.DeliveryCity)
                .Include(o => o.DeliveryMethod)
                .Include(o => o.OrderStatus)
                .Include(o => o.DeliveryMethod)
                .Include(o => o.OrderSource)
                .Include(o => o.OrderProduct)
                .ThenInclude(op => op.Product)
                .OrderByDescending(o => o.RequiredDate)
                .ToListAsync();

            TaskResponse<List<GetOrderDto2>> response = new TaskResponse<List<GetOrderDto2>>
            {
                Data = dbOrders.Select(o => _mapper.Map<GetOrderDto2>(o)).ToList()
            };
            //AssignOrderSourceType(response.Data);
            return response;
        }

        public async Task<TaskResponse<List<GetOrderDto2>>> GetById(int id)
        {
            List<Orders> dbOrders = await _orderRepo.GetQueryable()
                .Where(o => o.OrderSourceId == 1 && o.CustomerId == id && o.OrderStatusId != 0 && o.OrderStatusId != 0)
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.DeliveryCity)
                .Include(o => o.DeliveryMethod)
                .Include(o => o.OrderStatus)
                .Include(o => o.DeliveryMethod)
                .Include(o => o.OrderSource)
                .Include(o => o.OrderProduct)
                .ThenInclude(op => op.Product)
                .OrderByDescending(o => o.RequiredDate)
                .ToListAsync();

            if (dbOrders.Count == 0)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            TaskResponse<List<GetOrderDto2>> response = new TaskResponse<List<GetOrderDto2>>
            {
                Data = dbOrders.Select(o => _mapper.Map<GetOrderDto2>(o)).ToList()
            };
            //AssignOrderSourceType(response.Data);
            return response;
        }

        //public async Task<TaskResponse<bool>> DeleteById(string orderId, int customerId)
        public async Task<TaskResponse<bool>> DeleteById(string id)
        {
            Orders dbOrder = await _orderRepo.GetQueryable()
                .SingleOrDefaultAsync(o => o.OrderId == id && o.OrderSourceId == 1);

            if (dbOrder == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            if (dbOrder.OrderStatusId == 1 || dbOrder.OrderStatusId == 10)
            {
                await filterOrderProduct(id);
            }

            dbOrder.Active = 0;
            dbOrder.OrderStatusId = 0;
            _orderRepo.UpdateT(dbOrder);
            await _orderRepo.SaveAsync();

            TaskResponse<bool> response = new TaskResponse<bool>();
            response.Data = true;
            return response;
        }

        public async Task filterOrderProduct(string orderId)
        {
            List<OrderProduct> dbOrderProduct = await _orderProductRepo.GetQueryable()
                .Where(op => op.OrderId == orderId)
                .ToListAsync();

            foreach (OrderProduct op in dbOrderProduct)
            {
                await filterWorkOrder(op.OrderProductId);
            }
        }

        public async Task filterWorkOrder(string orderProductId)
        {
            WorkOrder dbWorkOrder = await _workOrderRepo.GetQueryable()
                .SingleOrDefaultAsync(wo => wo.OrderProductId == orderProductId);
            if (dbWorkOrder != null)
            {
                await filterSubOrder(dbWorkOrder.WorkOrderId);
                dbWorkOrder.WorkOrderStatusId = 0;
                _workOrderRepo.UpdateT(dbWorkOrder);
            }
        }

        public async Task filterSubOrder(string workOrderId)
        {
            List<Suborder> dbSubOrders = await _subOrderRepo.GetQueryable()
                .Where(so => so.WorkOrderId == workOrderId)
                .ToListAsync();
            if (dbSubOrders.Count != 0)
            {
                foreach(Suborder so in dbSubOrders)
                {
                    so.SuborderStatusId = 0;
                    _subOrderRepo.UpdateT(so);
                }
            }
        }

        public async Task<TaskResponse<bool>> Update(UpdateOrderDto3 request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();
            Orders dbOrder = await _orderRepo.GetQueryable()
                .SingleOrDefaultAsync(o => o.OrderId == request.OrderId && o.Active == 1 && o.OrderSourceId == 1);

            if (dbOrder == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }
            if (dbOrder.OrderStatusId > 10)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.OrderNotAllowedUpdate());
            }

            //Update the order without products first
            await UpdateOrderWithoutProducts(request, dbOrder);


            await filterOrderProduct(dbOrder.OrderId);
            _orderRepo.UpdateT(dbOrder);
            await _orderRepo.SaveAsync();
            
            //To delete all products first then add all of them.
            await DeleteAllOrderProducts(request, dbOrder);

            await AddProductsOnExistingOrder(request);
            
            //Delete all the products then post new products
            /*
            using var transaction = _orderRepo.GetContext().Database.BeginTransaction();
            try
            {
                await filterOrderProduct(dbOrder.OrderId);
                _orderRepo.UpdateT(dbOrder);
                await _orderRepo.SaveAsync();

                //To delete all products first then add all of them.
                await DeleteAllOrderProducts(request, dbOrder);

                await AddProductsOnExistingOrder(request);
                transaction.Commit();
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            */
            return response;
        }

        public async Task DeleteAllOrderProducts(UpdateOrderDto3 request, Orders dbOrder)
        {
            /*
            foreach(OrderProduct op in dbOrder.OrderProduct)
            {
                _orderProductRepo.Delete(op.OrderProductId);
                await _orderProductRepo.SaveAsync();
            }
            */
            _orderProductRepo.DeleteRange(dbOrder.OrderProduct);
            await _orderProductRepo.SaveAsync();
        }

        public async Task UpdateOrderWithoutProducts(UpdateOrderDto3 request, Orders dbOrder)
        {
            //_mapper.Map(request, dbOrder);
            dbOrder.OrderDate = request.OrderDate;
            dbOrder.CustomerId = request.CustomerId;
            dbOrder.EmployeeId = request.EmployeeId;
            dbOrder.TotalPrice = request.TotalPrice;
            dbOrder.PriceInclgst = request.PriceInclgst;
            dbOrder.RequiredDate = request.RequiredDate;
            dbOrder.DeliveryName = request.DeliveryName;
            dbOrder.DeliveryAddress = request.DeliveryAddress;
            dbOrder.PostalCode = request.PostalCode;

            dbOrder.OrderDate = request.OrderDate;
            dbOrder.DeliveryDate = request.DeliveryDate;
            dbOrder.Comments = request.Comments;
            dbOrder.DeliveryAsap = request.DeliveryAsap;
            dbOrder.Paid = request.Paid;

            dbOrder.DeliveryCityId = request.DeliveryCityId;
            dbOrder.DeliveryMethodId = request.DeliveryMethodId;
            dbOrder.OrderSourceId = request.OrderSourceId;

            dbOrder.UpdatedAt = GeneralMethods.createTime();

            // just clear all the orderProduct, and we are going to change them all anyway
            //dbOrder.OrderProduct.Clear();
            //dbOrder.OrderProduct = new Collection<OrderProduct>();
            _orderRepo.UpdateT(dbOrder);
            await _orderRepo.SaveAsync();
        }

        public async Task AddProductsOnExistingOrder(UpdateOrderDto3 request)
        {
            Parameter para = await _parameterRepo.GetAsync((short)2);
            decimal rejectionRate = para.Value;

            if (request.OrderProduct != null)
            {
                foreach (AddOrderProductDto op in request.OrderProduct)
                {
                    op.OrderId = request.OrderId;
                    TaskResponse<string> r = await _orderProductManagementService.Add(op);
                    var stocks = await _productManagementService.GetProductStocks(op.ProductId.Value);

                    if (op.Quantity > stocks.stockDto.Quantity)
                    {
                        AddWorkOrderDto workOrderRequest = new AddWorkOrderDto();

                        Guid workOrderId = Guid.NewGuid();

                        workOrderRequest.OrderProductId = r.Data;
                        workOrderRequest.ProductId = op.ProductId;
                        workOrderRequest.CreatedEmployeeId = request.EmployeeId;
                        workOrderRequest.Comments = request.Comments;
                        workOrderRequest.RequiredDate = request.RequiredDate;
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
                }
            }
        }
    }
}
