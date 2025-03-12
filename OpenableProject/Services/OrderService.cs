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


    public void Delete(int orderId)
    {
        _orderRepository.Delete(orderId);
    }
    
    public OrderResponse UpdateStatus(int orderId, OrderStatus newStatus)
    {
        var updatedOrder = _orderRepository.UpdateStatus(orderId, newStatus);

        return new OrderResponse
        {
            Id = updatedOrder.Id,
            OrderMeals = updatedOrder.OrderMeals,
            CustomerName = updatedOrder.CustomerName,
            Status = updatedOrder.Status,
            CreatedTime = updatedOrder.CreatedTime,
            UpdatedTime = updatedOrder.UpdatedTime
        };
    }
}