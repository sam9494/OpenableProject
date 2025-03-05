using Microsoft.AspNetCore.Mvc;
using OpenableProject.DTO;
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
            OrderMeals = orderRequest.OrderMeals
        };
        
        return _orderService.Add(order);
    }

    [HttpGet]
    public List<OrderResponse> GetAll()
    {
        return _orderService.GetAll();
    }
    
    [HttpDelete]
    public void Delete(int orderId)
    {
        _orderService.Delete(orderId);
    }

}