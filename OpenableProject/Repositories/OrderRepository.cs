using OpenableProject.Models;
using OpenableProject.Storage;

namespace OpenableProject.Repositories;

public class OrderRepository
{
    public Order Add(Order order)
    {
        return OrderStorage.Add(order);
    }

    public Order Get(int orderId)
    {
        return OrderStorage.Get(orderId);
    }

    public List<Order> GetAll()
    {
        return OrderStorage.GetAll();
    }

    public List<Order> GetByMealIds(IEnumerable<int> mealIds)
    {
        return OrderStorage.GetByMealIds(mealIds);
    }

    public void Delete(int orderId)
    {
        OrderStorage.Delete(orderId);
    }

    public void Update(Order order)
    {
        OrderStorage.Update(order);
    }
}