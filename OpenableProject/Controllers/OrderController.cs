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
    
    [HttpPatch("{orderId:int}/Status")]//根據使用者切開，後續切不同模組，進一步切服務，擴展方案不同，省成本
    public void UpdateStatus(int orderId, [FromBody]OrderStatus status)
    {
        _orderService.UpdateStatus(orderId, status);
    }
}