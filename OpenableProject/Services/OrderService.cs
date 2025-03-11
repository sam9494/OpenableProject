using OpenableProject.Controllers;
using OpenableProject.DTO;
using OpenableProject.Models;
using OpenableProject.Repositories;

namespace OpenableProject.Services;

public class OrderService
{
    private readonly OrderRepository _orderRepository = new();

    public OrderRepository OrderRepository
    {
        get { return _orderRepository; }
    }

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

    public void UpdateOrderStatus(int orderId, int orderStatus)
    {
        _orderRepository.UpdateOrderStatus(orderId, orderStatus);
    }
    
    public bool IsOrderBelongsToRestaurant(int orderId, int restaurantId)
    {
        return _orderRepository.IsOrderBelongsToRestaurant(orderId, restaurantId);
    }

    public IEnumerable<OrderResponse> GetOrdersByRestaurant(int restaurantId)
    {
        var orders = _orderRepository.GetAll().Where(x=>x.RestaurantId==restaurantId)
            .Select(x=>new OrderResponse()
        {
            Id = x.Id,
            OrderMeals = x.OrderMeals,
            CustomerName = x.CustomerName
        });
        return orders;
    }

    public bool IsOrderBelongsToCustomer(int orderId, string username)
    {
        return _orderRepository.IsOrderBelongsToCustomer(orderId, username);
    }
}