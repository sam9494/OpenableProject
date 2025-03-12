using System.Collections.Concurrent;
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
        return order;
    }

    public static Order AddByOperator(Order order)
    {
        order.Id = _orderId++;
        CurrentOrders.TryAdd(order.Id, order);
        return order;
    }

    public static Order Get(int orderId)
    {
        return CurrentOrders.Values.First(o => o.Id == orderId);
    }

    public static List<Order> GetAll()
    {
        return CurrentOrders.Values.ToList();
    }

    public static bool Delete(int orderId)
    {
        return CurrentOrders.TryRemove(orderId, out _);
    }

    public static List<Order> GetByMealIds(IEnumerable<int> mealIds)
    {
        return CurrentOrders.Values.Where(o => o.OrderMeals.Any(om => mealIds.Contains(om.MealId))).ToList();
    }

    public static void Update(Order order)
    {
        if (order == null || !CurrentOrders.ContainsKey(order.Id))
        {
            throw new KeyNotFoundException($"Order with ID {order?.Id} not found.");
        }

        CurrentOrders.AddOrUpdate(order.Id, order, (key, existingOrder) =>
        {
            existingOrder.CustomerName = order.CustomerName;
            existingOrder.OrderMeals = order.OrderMeals; // 替換餐點列表
            existingOrder.Status = order.Status; // 更新訂單狀態
            return existingOrder;
        });
    }
}