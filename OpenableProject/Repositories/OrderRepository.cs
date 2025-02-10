using OpenableProject.DataGateways;
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

    public List<Order> GetAll()
    {
        return OrderStorage.GetAll();
    }
}