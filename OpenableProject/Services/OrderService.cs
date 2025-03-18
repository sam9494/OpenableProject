using OpenableProject.DTO;
using OpenableProject.Enum;
using OpenableProject.Errors;
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
            CustomerName = x.CustomerName,
            Status = x.Status
        });
        return orders;
    }


    public void Delete(int orderId)
    {
        _orderRepository.Delete(orderId);
    }

    public Result<bool> UpdateStatus(int orderId, OrderStatus status)
    {
        var order = _orderRepository.GetById(orderId);
        
        if (order == null) 
            return Result<bool>.Failure(new NotFoundError<Order>());
        
        order.Status = status;
        _orderRepository.Update(order);
        return Result<bool>.Success(true);
    }
}