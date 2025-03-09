using OpenableProject.DTO;
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
    
    public List<OrderMeal> GetByRestaurant(int restaurantId)
    {
        return OrderStorage.GetByRestaurant(restaurantId);
    }
   
    public void Delete(int orderId)
    {
        OrderStorage.Delete(orderId);
    }

    public OrderMeal ChangeOrderMealStatus(int orderId, int mealId, OrderStatusEnum status)
    {
        return OrderStorage.ChangeOrderMealStatus(orderId, mealId, status);
    }
}