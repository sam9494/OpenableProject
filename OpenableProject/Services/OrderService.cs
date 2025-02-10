using OpenableProject.Models;
using OpenableProject.Repositories;

namespace OpenableProject.Services;

public class OrderService
{
    public Order ReceiveOrder(List<OrderItem> orderItems)
    {
        var orderRepository = new OrderRepository();

        var order = new Order();
        order.Init(orderItems);

        var insertedOrder = orderRepository.Insert(order);
        return insertedOrder;
    }

    public List<Order> GetAll()
    {
        var orderRepository = new OrderRepository(); 
        return orderRepository.GetAll();
    }
}