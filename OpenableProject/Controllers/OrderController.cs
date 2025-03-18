using Microsoft.AspNetCore.Mvc;
using OpenableProject.DTO;
using OpenableProject.Enum;
using OpenableProject.Models;
using OpenableProject.Services;

namespace OpenableProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService = new();
    
    [HttpPost]
    public Order Post(OrderRequest orderRequest)
    {
        var order = new Order
        {
            CustomerName = orderRequest.CustomerName,
            OrderMeals = orderRequest.OrderMeals,
            Status = OrderStatus.Pending
        };
        
        return _orderService.Add(order);
    }

    [HttpGet]
    public IEnumerable<OrderResponse> GetAll()
    {
        return _orderService.GetAll();
    }
    
    [HttpDelete("{orderId:int}")]
    public void Delete(int orderId)
    {
        _orderService.Delete(orderId);
    }
    
    [HttpPatch("{orderId:int}/Status")]
    public IActionResult UpdateStatus(int orderId, [FromBody]OrderStatus status)
    {
        var result = _orderService.UpdateStatus(orderId, status);

        if (!result.IsSuccess)
            return NotFound(result.Error);
        
        return Ok();
    }
}