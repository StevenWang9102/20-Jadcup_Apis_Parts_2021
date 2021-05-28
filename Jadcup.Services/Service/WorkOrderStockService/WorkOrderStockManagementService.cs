using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.WorkOrderStockService;
using Jadcup.Services.Model.InventoryWorkOrderModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.WorkOrderStockService
{
    public class WorkOrderStockManagementService : IWorkOrderStockManagementService
    {
        private readonly IGenericMySqlAccessRepository<Stock> _stockRepo;
        private readonly IGenericMySqlAccessRepository<Product> _productRepo;
        private readonly IGenericMySqlAccessRepository<WorkOrder> _workOrderRepo;
        private readonly IGenericMySqlAccessRepository<Orders> _orderRepo;
        private readonly IGenericMySqlAccessRepository<Item> _itemRepo;
        private readonly IGenericMySqlAccessRepository<OrderProduct> _orderProductRepo;
        private readonly IMapper _mapper;

        public WorkOrderStockManagementService(IGenericMySqlAccessRepository<Stock> stockRepo,
            IGenericMySqlAccessRepository<Product> productRepo,
            IGenericMySqlAccessRepository<WorkOrder> workOrderRepo,
            IGenericMySqlAccessRepository<Orders> orderRepo,
            IGenericMySqlAccessRepository<Item> itemRepo,
            IGenericMySqlAccessRepository<OrderProduct> orderProductRepo,
            IMapper mapper)
        {
            _stockRepo = stockRepo;
            _productRepo = productRepo;
            _workOrderRepo = workOrderRepo;
            _orderRepo = orderRepo;
            _itemRepo = itemRepo;
            _orderProductRepo = orderProductRepo;
            _mapper = mapper;
        }
        public async Task<TaskResponse<List<GetInventoryWorkOrderDto>>> GetAll(bool? low)
        {
            TaskResponse<List<GetInventoryWorkOrderDto>> response = new TaskResponse<List<GetInventoryWorkOrderDto>>();

            List<Product> products = await _productRepo.GetQueryable().Where(p => p.Active == 1 && p.Manufactured != 1).ToListAsync();

            List<GetInventoryWorkOrderDto> info = new List<GetInventoryWorkOrderDto>();

            foreach (Product p in products)
            {
                GetInventoryWorkOrderDto inventoryInfo = await GetInventoryInfo(p);


                info.Add(inventoryInfo);
            }

            response.Data = info.Where(i => low == null || i.Low == low).ToList();
            return response;

        }

        public async Task<TaskResponse<GetInventoryWorkOrderDto>> GetByProductId(short productId)
        {
            TaskResponse<GetInventoryWorkOrderDto> response = new TaskResponse<GetInventoryWorkOrderDto>();

            Product product = await _productRepo.GetAsync(productId);

            GetInventoryWorkOrderDto inventoryInfo = await GetInventoryInfo(product);

            response.Data = inventoryInfo;
            return response;
        }



        //function
        public async Task<GetInventoryWorkOrderDto> GetInventoryInfo(Product p)
        {
            List<Item> items = await _itemRepo.GetQueryable().Where(i => i.ProductId == p.ProductId).ToListAsync();
            List<Stock> stocks = await _stockRepo.GetQueryable().Where(s => items.Select(i => i.ItemId).ToList().Contains(s.ItemId.Value)).Include(s => s.Item).ToListAsync();
            int productStockQuantity = (int)stocks.FirstOrDefault(s => s.Item.IsSemi == 0).Quantity;
            int semiStockQuantity = (int)stocks.FirstOrDefault(s => s.Item.IsSemi != 0).Quantity;

            List<OrderProduct> orderProducts = await _orderProductRepo.GetQueryable().Where(o => o.ProductId == p.ProductId).Include(o => o.Order).ToListAsync();
            int orderQuantity = 0;
            foreach (OrderProduct op in orderProducts)
            {
                if (op.Order.OrderStatusId < 15 && op.Order.OrderStatusId != 0)
                {
                    orderQuantity += op.Quantity;
                }
            }

            List<WorkOrder> workOrders = await _workOrderRepo.GetQueryable().Where(w => w.ProductId == p.ProductId && w.WorkOrderStatusId < 10 && w.WorkOrderStatusId != 0).ToListAsync();
            int semiWorkOrderQuantity = 0;
            int workOrderQuantity = 0;
            foreach (WorkOrder wo in workOrders)
            {
                if (wo.OrderTypeId == 2)
                {
                    semiWorkOrderQuantity += wo.Quantity;
                }
                else
                {
                    workOrderQuantity += wo.Quantity;
                }
            }

            GetInventoryWorkOrderDto inventoryInfo = new GetInventoryWorkOrderDto
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                ProductInventoryInfo = new GetProductInventoryDto
                {
                    ProductInStock = productStockQuantity,
                    ProductMsl = p.ProductMsl.Value,
                    PendingOrderQuantity = orderQuantity,
                    PendingWorkOrderQuantity = workOrderQuantity,
                    SuggestedQuantity = -(productStockQuantity - orderQuantity + workOrderQuantity - p.ProductMsl.Value)
                },
                SemiProductInventoryInfo = new GetSemiProductInventory
                {
                    SemiProductInStock = semiStockQuantity,
                    SemiProductMsl = p.SemiMsl.Value,
                    PendingWorkOrderQuantity = semiWorkOrderQuantity,
                    SuggestedSemiQuantity = -(semiStockQuantity + semiWorkOrderQuantity - p.SemiMsl.Value)
                }
            };

            if (inventoryInfo.ProductInventoryInfo.SuggestedQuantity < 0)
            {
                inventoryInfo.ProductInventoryInfo.SuggestedQuantity = 0;
            }

            if (inventoryInfo.SemiProductInventoryInfo.SuggestedSemiQuantity < 0)
            {
                inventoryInfo.SemiProductInventoryInfo.SuggestedSemiQuantity = 0;
            }

            if (inventoryInfo.ProductInventoryInfo.SuggestedQuantity > 0 || inventoryInfo.SemiProductInventoryInfo.SuggestedSemiQuantity > 0)
            {
                inventoryInfo.Low = true;
            }

            return inventoryInfo;
        }
    }
}