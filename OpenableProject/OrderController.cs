using System.Collections.Concurrent;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;

namespace OpenableProject;
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    // GET
    [HttpGet("Post")]
    public OrderResponse Post(OrderRequest orderRequest)
    {
        var orderService = new OrderService();
        var receivedOrder = orderService.ReceiveOrder(orderRequest.OrderItems);
        return new OrderResponse
        {
            OrderId = receivedOrder.Id,
            OrderStatus = "成功"
        };
    }
}


public class OrderService
{
    public Order ReceiveOrder(List<OrderItem> orderItems)
    {
        var orderRepository = new OrderRepository();

        var order = new Order();
        order.Init(orderItems);

        var insertedOrder = orderRepository.Insert(order);
        return insertedOrder;
    }
}

public class OrderRepository
{
    public Order Insert(Order order)
    {
        var orderId = OrderStorage.Add(order);
        order.Id = orderId;
        return order;
    }
}

public static class OrderStorage
{
    public static int LastOrderId { get; set; }
    public static ConcurrentDictionary<int, Order> OrderRecords { get; set; }

    public static void Reset(int orderId)
    {
        LastOrderId = orderId;
    }
    public static int Add(Order order)
    {
        OrderRecords.TryAdd(LastOrderId,order);
    }
}

public class Order
{
    public List<OrderItem> OrderItems { get; set; }
    public int Id { get; set; }

    public void Init(List<OrderItem> orderItems)
    {
        OrderItems = orderItems;
    }
}

public class OrderResponse 
{
    public int OrderId { get; set; }
    public string OrderStatus { get; set; }
}

public class OrderRequest
{
    public string CustomerName { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}

public class OrderItem
{
    public int MenuItemId { get; set; }
    public int Quantity { get; set; }
}