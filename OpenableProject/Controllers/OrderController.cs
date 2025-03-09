using Microsoft.AspNetCore.Mvc;
using OpenableProject.DTO;
using OpenableProject.Models;
using OpenableProject.Services;

namespace OpenableProject.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
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
    public IEnumerable<OrderResponse> GetAll()
    {
        return _orderService.GetAll();
    }
    
    [HttpDelete]
    public void Delete(int orderId)
    {
        _orderService.Delete(orderId);
    }
    
    // 廠商(餐廳)
    [HttpGet]
    public IEnumerable<OrderMealResponse> GetByRestaurant()
    {
        //透過權限驗證拿Id?
        var restaurantId = 1;
        return _orderService.GetByRestaurant(restaurantId);
    }
    
    [HttpPut]
    public OrderMealResponse ChangeOrderMealStatus(OrderMealStatusRequest statusRequest)
    {
        return _orderService.ChangeOrderMealStatus(statusRequest.OrderId,statusRequest.MealId, statusRequest.Status);
    }
}

public class OrderMealStatusRequest
{
    public int OrderId { get; set; }
    public int MealId { get; set; }
    public OrderStatusEnum Status { get; set; }
}