using System.Collections.Concurrent;
using OpenableProject.DTO;
using OpenableProject.Models;

namespace OpenableProject.Storage;

public static class OrderStorage
{
    private static int _orderId;
    private static readonly ConcurrentDictionary<int, Order> CurrentOrders = [];


    public static Order Add(Order order)
    {
        order.Id = Interlocked.Increment(ref _orderId);
        
        foreach (var orderMeal in order.OrderMeals)
        {
            orderMeal.OrderId = order.Id;
        }

        CurrentOrders.TryAdd(order.Id, order);
        return order;
    }
    
    public static Order AddByOperator(Order order)
    {
        order.Id = _orderId++;
        CurrentOrders.TryAdd(order.Id, order);
        return order;
    }
    
    public static List<Order> GetAll()
    {
        return CurrentOrders.Values.ToList();
    }
    
    public static List<OrderMeal> GetByRestaurant(int restaurantId)
    {
        var orderMeals = CurrentOrders.Values.ToList().SelectMany(o => o.OrderMeals);
        return orderMeals.Where(om => om.RestaurantId == restaurantId).ToList();
    }

    public static bool Delete(int orderId)
    {
        return CurrentOrders.TryRemove(orderId, out _);
    }

    public static OrderMeal ChangeOrderMealStatus(int orderId, int mealId, OrderStatusEnum status)
    {
        var orderMeal = CurrentOrders[orderId].OrderMeals.FirstOrDefault(om => om.MealId == mealId);
        orderMeal.Status = status;
        return orderMeal;
    }
}