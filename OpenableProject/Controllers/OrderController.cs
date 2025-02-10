using Microsoft.AspNetCore.Mvc;
using OpenableProject.Models;
using OpenableProject.Services;

namespace OpenableProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    // GET
    [HttpPost("Post")]
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