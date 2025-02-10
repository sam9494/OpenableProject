using System.Collections.Concurrent;
using OpenableProject.Models;

namespace OpenableProject.DataGateway;

public static class OrderStorage
{
    private static int LastOrderId { get; set; }
    public static ConcurrentDictionary<int, Order> OrderRecords { get; set; }
    private static readonly object LockObj = new object();

    public static void Reset(int orderId)
    {
        OrderRecords = new ConcurrentDictionary<int, Order>();
        LastOrderId = orderId;
    }

    public static int Add(Order order)
    {
        lock (LockObj)
        {
            var nextLastOrderId = LastOrderId + 1;
            var isSuccess = OrderRecords.TryAdd(nextLastOrderId, order);
            if (isSuccess)
            {
                LastOrderId = nextLastOrderId;
            }

            return nextLastOrderId;
        }
    }
}