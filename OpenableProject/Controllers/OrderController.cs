using Microsoft.AspNetCore.Mvc;
using OpenableProject.DataGateways;
using OpenableProject.Models;
using OpenableProject.Services;

namespace OpenableProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    [HttpPost]
    public OrderResponse Post(AddOrderRequest addOrderRequest)
    {
        var orderService = new OrderService();
        var receivedOrder = orderService.ReceiveOrder(addOrderRequest.OrderItems);
        return new OrderResponse
        {
            OrderId = receivedOrder.Id,
            OrderStatus = "成功"
        };
    }
    
    [HttpGet]
    public List<Order> GetAll()
    {
        var orderService = new OrderService();
        return orderService.GetAll();
    }
    
    
    [HttpDelete("Reset")]
    public void Reset()
    {
        OrderStorage.Reset(0);
    }

}