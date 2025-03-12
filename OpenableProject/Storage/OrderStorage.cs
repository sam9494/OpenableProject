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
    
    public static List<Order> GetAll()
    {
        return CurrentOrders.Values.ToList();
    }

    public static bool Delete(int orderId)
    {
        return CurrentOrders.TryRemove(orderId, out _);
    }
    
    public static Order UpdateStatus(int orderId, OrderStatus newStatus)
    {
        var order = CurrentOrders.FirstOrDefault(o => o.Key == orderId);
        
        order.Value.Status = newStatus;
        order.Value.UpdatedTime = DateTime.Now;
        
        return order.Value;
        
    }
}