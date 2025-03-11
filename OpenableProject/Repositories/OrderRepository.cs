using OpenableProject.Models;
using OpenableProject.Storage;

namespace OpenableProject.Repositories;

public class OrderRepository
{
    public Order Add(Order order)
    {
        return OrderStorage.Add(order);
    }


    public List<Order> GetAll()
    {
        return OrderStorage.GetAll();
    }


    public void Delete(int orderId)
    {
        OrderStorage.Delete(orderId);
    }

    public void UpdateOrderStatus(int orderId, int orderStatus)
    {
        OrderStorage.UpdateOrderStatus(orderId, orderStatus);
    }
    
    public bool IsOrderBelongsToRestaurant(int orderId, int restaurantId)
    {
        return OrderStorage.IsOrderBelongsToRestaurant(orderId, restaurantId);
    }

    public bool IsOrderBelongsToCustomer(int orderId, string username)
    {
        return OrderStorage.IsOrderBelongsToCustomer(orderId, username);
    }
}