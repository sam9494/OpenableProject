using System.Collections.Concurrent;
using OpenableProject.Enums;
using OpenableProject.Models;

namespace OpenableProject.Storage;

public static class OrderStorage
{
    private static int _orderId;
    private static readonly ConcurrentDictionary<int, Order> CurrentOrders = [];


    public static Order Add(Order order)
    {
        order.Id = Interlocked.Increment(ref _orderId);
        CurrentOrders.TryAdd(order.Id, order);
        order.Status = (int)OrderStatusEnum.Created; //訂單ID成立，訂單才算建立
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

    public static bool Delete(int orderId)
    {
        return CurrentOrders.TryRemove(orderId, out _);
    }
    
    public static void UpdateOrderStatus(int orderId, int orderStatus)
    {
        CurrentOrders[orderId].Status = orderStatus;
    }
    
    public static bool IsOrderBelongsToRestaurant(int orderId, int restaurantId)
    {
        return CurrentOrders[orderId].RestaurantId == restaurantId; // 確認訂單是否屬於該餐廳
    }

    public static bool IsOrderBelongsToCustomer(int orderId, string username)
    {
        return CurrentOrders[orderId].CustomerName == username; // 確認訂單是否屬於該餐廳
    }
}