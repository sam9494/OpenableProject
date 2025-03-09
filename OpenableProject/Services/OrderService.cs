using OpenableProject.Controllers;
using OpenableProject.DTO;
using OpenableProject.Models;
using OpenableProject.Repositories;

namespace OpenableProject.Services;

public class OrderService
{
    private readonly OrderRepository _orderRepository = new();

    public Order Add(Order order)
    {
        return _orderRepository.Add(order);
    }


    public IEnumerable<OrderResponse> GetAll()
    {
        var orders = _orderRepository.GetAll().Select(x=>new OrderResponse()
        {
            Id = x.Id,
            OrderMeals = x.OrderMeals,
            CustomerName = x.CustomerName
        });
        return orders;
    }
    
    public IEnumerable<OrderMealResponse> GetByRestaurant(int restaurantId)
    {
        var orderMeals = _orderRepository.GetByRestaurant(restaurantId).Select(x=>new OrderMealResponse()
        {
            OrderId = x.OrderId,
            MealId = x.MealId,
            MealName = x.MealName,
            Quantity = x.Quantity,
            Status = x.Status
        });
        return orderMeals;
    }

    public OrderMealResponse ChangeOrderMealStatus(int orderId,int mealId, OrderStatusEnum status)
    {
        var orderMeal = _orderRepository.ChangeOrderMealStatus(orderId, mealId, status); 
        return new OrderMealResponse()
        {
            OrderId = orderMeal.OrderId,
            MealId = orderMeal.MealId,
            MealName = orderMeal.MealName,
            Quantity = orderMeal.Quantity,
            Status = orderMeal.Status
        };
    }


    public void Delete(int orderId)
    {
        _orderRepository.Delete(orderId);
    }
}