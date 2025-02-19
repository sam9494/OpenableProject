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
}