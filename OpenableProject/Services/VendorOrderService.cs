using OpenableProject.Models;
using OpenableProject.Models.Enum;
using OpenableProject.Repositories;

namespace OpenableProject.Services;

public class VendorOrderService
{
    private readonly OrderRepository _orderRepository = new();
    private readonly MenuRepository _menuRepository = new();

    public IEnumerable<OrderResponse> GetAllByRestaurantId(int restaurantId)
    {
        var menus = _menuRepository.GetByRestaurantId(restaurantId);
        var mealIds = menus.SelectMany(m => m.Meals).Select(me => me.Id);
        var orders = _orderRepository.GetByMealIds(mealIds).Select(x => new OrderResponse()
        {
            Id = x.Id,
            OrderMeals = x.OrderMeals,
            CustomerName = x.CustomerName,
            Status = x.Status
        });
        return orders;
    }
    
    public void ProcessOrder(int orderId)
    {
        var order = _orderRepository.Get(orderId);
        order.Status = OrderStatus.Processing;
        _orderRepository.Update(order);
    }

    public void CompleteOrder(int orderId)
    {
        var order = _orderRepository.Get(orderId);
        order.Status = OrderStatus.Completed;
        _orderRepository.Update(order);
    }

    public void CancelOrder(int orderId)
    {
        var order = _orderRepository.Get(orderId);
        order.Status = OrderStatus.Canceled;
        _orderRepository.Update(order);
    }
}