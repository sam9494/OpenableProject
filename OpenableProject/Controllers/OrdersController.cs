using Microsoft.AspNetCore.Mvc;

namespace OpenableProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private static List<Order> orders = new();
    private static List<MenuItem> menu = MenuController.menu;

    [HttpGet]
    public ActionResult<IEnumerable<Order>> GetOrders() => Ok(orders);

    [HttpPost]
    public ActionResult<Order> CreateOrder(OrderRequest request)
    {
        var order = new Order
        {
            Id = orders.Count + 1,
            Items = request.Items,
            Total = request.Items.Sum(i => menu.First(m => m.Id == i).Price)
        };
        orders.Add(order);
        return CreatedAtAction(nameof(GetOrders), new { id = order.Id }, order);
    }

    [HttpGet("{id}")]
    public ActionResult<Order> GetOrder(int id)
    {
        var order = orders.FirstOrDefault(o => o.Id == id);
        return order == null ? NotFound() : Ok(order);
    }
}