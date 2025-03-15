using Microsoft.AspNetCore.Authorization;
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
            OrderMeals = orderRequest.OrderMeals.Select(om=> new OrderMeal()
            {
                MealId = om.MealId,
                MealName = om.MealName,
                Quantity = om.Quantity,
                RestaurantId = om.RestaurantId,
                OrderId = 0,// 初始為0
                Status = OrderStatusEnum.Established
            }).ToList()
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
    [Authorize]
    public ActionResult<IEnumerable<OrderMealResponse>> GetByRestaurant()
    {
        string restaurantIdClaim = User.Claims.FirstOrDefault(c => c.Type == "RestaurantId")?.Value;

        if (string.IsNullOrEmpty(restaurantIdClaim))
        {
            return Unauthorized("Restaurant ID is missing in the token.");
        }

        int restaurantId = int.Parse(restaurantIdClaim);
        return Ok(_orderService.GetByRestaurant(restaurantId)) ;
    }
    
    [HttpPut]
    [Authorize]
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