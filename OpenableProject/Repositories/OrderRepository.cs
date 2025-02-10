using OpenableProject.DataGateway;
using OpenableProject.Models;

namespace OpenableProject.Repositories;

public class OrderRepository
{
    public Order Insert(Order order)
    {
        var orderId = OrderStorage.Add(order);
        order.Id = orderId;
        return order;
    }
}