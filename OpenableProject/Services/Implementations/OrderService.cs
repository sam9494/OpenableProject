using OpenableProject.Model;

namespace OpenableProject.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly IRestaurantService _restaurantService;
    private readonly IMenuService _menuService;
    private static List<Order> _orders = new List<Order>();
    private static int _nextOrderId = 1;
    private static int _nextOrderItemId = 1;

    public OrderService(IRestaurantService restaurantService, IMenuService menuService)
    {
        _restaurantService = restaurantService;
        _menuService = menuService;
    }

    public List<Order> GetAllOrders()
    {
        return _orders.ToList();
    }

    public Order GetOrderById(int id)
    {
        return _orders.FirstOrDefault(o => o.OrderId == id);
    }

    public List<Order> GetOrdersByRestaurantId(int restaurantId)
    {
        return _orders.Where(o => o.RestaurantId == restaurantId).ToList();
    }

    public Order CreateOrder(Order order)
    {
        var restaurant = _restaurantService.GetRestaurantById(order.RestaurantId);
        if (restaurant == null)
        {
            throw new InvalidOperationException($"RestaurantID {order.RestaurantId} not found");
        }

        order.OrderId = _nextOrderId++;
        order.RestaurantName = restaurant.Name;
        order.OrderDate = DateTime.Now;
        order.Status = Order.OrderStatus.Created;

        var totalAmount = 0;
        foreach (var item in order.Items)
        {
            item.OrderId = order.OrderId;
            item.OrderItemId = _nextOrderItemId++;
            
            var menus = _menuService.GetMenuByRestaurantId(order.RestaurantId);
            var menu = menus.FirstOrDefault(m => m.MenuId == item.MenuId);
            if (menu != null)
            {
                item.MenuName = menu.Name;
                item.UnitPrice = menu.Price;
            }
            
            totalAmount += item.Quantity * item.UnitPrice;
        }
        
        order.TotalAmount = totalAmount;
        _orders.Add(order);
        return order;
    }

    public Order CompleteOrder(int orderId)
    {
        var order = GetOrderById(orderId);
        if (order == null)
        {
            throw new InvalidOperationException($"OrderID {orderId} not found");
        }

        if (order.Status == Order.OrderStatus.Cancelled || order.Status == Order.OrderStatus.Completed)
        {
            throw new InvalidOperationException($"Cannot complete an order that is already {order.Status}");
        }

        order.Status = Order.OrderStatus.Completed;
        return order;
    }
    
    public static void ResetOrders()
    {
        _orders.Clear();
        _nextOrderId = 1;
        _nextOrderItemId = 1;
    }

}