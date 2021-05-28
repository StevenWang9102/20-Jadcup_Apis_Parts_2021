using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.OrderModel;

namespace Jadcup.Services.Interface.OrderService
{
    public interface IOrderFromCustomerManagementService
    {
        Task<TaskResponse<bool>> AddById(AddOrderDto2 request);
        Task<TaskResponse<List<GetOrderDto2>>> GetAll();
        Task<TaskResponse<List<GetOrderDto2>>> GetById(int id);
        Task<TaskResponse<bool>> DeleteById(string id);
        Task<TaskResponse<bool>> Update(UpdateOrderDto3 request);
    }
}

/* AddById
 * {
        "CustomerId" : 55,
        "EmployeeId" : 37,
        "RequiredDate" : "2021-06-06T06:00:00",
        "DeliveryName" : "james013",
        "DeliveryAddress" : "To test update100",
        "PostalCode" : "0630",
        "Comments" : "TTT update",
        "DeliveryAsap" : 0,
        "TotalPrice" : 0,
        "PriceInclgst" : 0,
        "OrderStatusId" : 1,
        "DeliveryCityId" : 5,
        "DeliveryMethodId" : 3,
        "OrderProduct" : [
            {
                "OrderId" : "",
                "ProductId" : 15,
                "Quantity" : 10000,
                "UnitPrice" : 2,
                "Price" : 20000,
                "MarginOfError" : 20
            },
            {
                "OrderId" : "",
                "ProductId" : 16,
                "Quantity" : 20000,
                "UnitPrice" : 1,
                "Price" : 20000,
                "MarginOfError" : 10
            }
        ]
    }
 *  ==========================================================================
 *  
    GetAll
    http://localhost:5020/api/OrderFromCustomer/GetOrdersFromCustomer
    ==========================================================================
    
    GetByCustomerId --- Get all web order by a customer
    http://localhost:5020/api/OrderFromCustomer/GetOrdersByCustomerId?customerId=55
    ==========================================================================

    DeleteById --- not really deleting the order, to change some status
    http://localhost:5020/api/OrderFromCustomer/DeleteOrderByBothId?orderId=2d46f778-9106-4583-93b1-30f499b28ca7&customerId=55
    ==========================================================================

    Update --- The logic is to keep the order, but to delete all order product and add the new ones
    {
        "CustomerId" : 55,
        "OrderId" : "c2aa1ab1-33c4-4e27-98b9-94ea8ce3bde0",
        "EmployeeId" : 37,
        "RequiredDate" : "2021-07-06T06:00:00",
        "DeliveryName" : "james013",
        "DeliveryAddress" : "test update web order001",
        "PostalCode" : "0630",
        "Comments" : "update james013 with new products",
        "DeliveryAsap" : 0,
        "TotalPrice" : 0,
        "PriceInclgst" : 0,
        "OrderStatusId" : 1,
        "DeliveryCityId" : 5,
        "DeliveryMethodId" : 3,
        "OrderSourceId" : 1,
        "OrderProduct" : [
            {
                "OrderId" : "",
                "ProductId" : 15,
                "Quantity" : 20000,
                "UnitPrice" : 3,
                "Price" : 60000,
                "MarginOfError" : 20
            }
        ]
    }
 */
