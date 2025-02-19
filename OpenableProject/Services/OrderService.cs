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


    public List<Order> GetAll()
    {
        return _orderRepository.GetAll();
    }


    public void Delete(int orderId)
    {
        _orderRepository.Delete(orderId);
    }
}