using OpenableProject.Model;

namespace OpenableProject.Services;

public interface IOrderService
{
    List<Order> GetAllOrders();
    Order GetOrderById(int id);
    List<Order> GetOrdersByRestaurantId(int restaurantId);
    Order CreateOrder(Order order);
    Order CompleteOrder(int orderId);

}