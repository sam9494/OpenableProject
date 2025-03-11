using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
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
            OrderMeals = orderRequest.OrderMeals,
            RestaurantId = orderRequest.RestaurantId
        };
        
        return _orderService.Add(order);
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Restaurant")] // 平台管理者可看全部，餐廳業者可看自己餐廳的訂單
    public IEnumerable<OrderResponse> GetAll()
    {
        // return _orderService.GetAll();
        var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
        var userRestaurantId = User.FindFirst("RestaurantId")?.Value;

        if (userRole == "Admin")
        {
            return _orderService.GetAll(); // 平台管理者可看所有訂單
        }
        else if (userRole == "Restaurant" && int.TryParse(userRestaurantId, out int restaurantId))
        {
            return _orderService.GetOrdersByRestaurant(restaurantId); // 只顯示該餐廳的訂單
        }
        return null;
    }
    
    [HttpDelete]
    [Authorize(Roles = "Customer")] // 只有消費者可以刪除自己的訂單
    public void Delete(int orderId)
    {
        // _orderService.Delete(orderId);
        var username = User.Identity.Name;
        if (_orderService.IsOrderBelongsToCustomer(orderId, username))
        {
            _orderService.Delete(orderId);
        }
    }
    
    [HttpPut]
    [Authorize(Roles = "Admin,Restaurant")] // 只能修改自己餐廳的訂單
    public void Put(int orderId, int orderStatus)
    {
        // _orderService.UpdateOrderStatus(orderId, orderStatus);
        var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
        var userRestaurantId = User.FindFirst("RestaurantId")?.Value;

        if (userRole == "Admin")
        {
            _orderService.UpdateOrderStatus(orderId, orderStatus);
        }
        else if (userRole == "Restaurant" && int.TryParse(userRestaurantId, out int restaurantId))
        {
            if (_orderService.IsOrderBelongsToRestaurant(orderId, restaurantId))
            {
                _orderService.UpdateOrderStatus(orderId, orderStatus);
            }
        }
    }
    
    
    

}