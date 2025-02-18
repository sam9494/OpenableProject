
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;
using OpenTableProject.Interface;
using OpenTableProject.Model;

namespace OpenTableProject;
[ApiController]
[Microsoft.AspNetCore.Components.Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IDishRepository _dishRepository;
    private readonly IOrderRepository _orderRepository;

    public OrderController(IRestaurantRepository restaurantRepository, IDishRepository dishRepository, IOrderRepository orderRepository)
    {
        _restaurantRepository = restaurantRepository;
        _dishRepository = dishRepository;
        _orderRepository = orderRepository;
    }

    // 使用者-顯示所有店家
    [HttpGet("/restaurants")]
    public async Task<ActionResult<Dictionary<Guid,string>>> GetRestaurants()
    {
        var dto = await _restaurantRepository.GetAll();
        return dto.ToDictionary(k => k.Id, v => v.Name);
    }
    
    // 使用者-顯示所有店家的餐點
    [HttpGet("/dishes/{restaurantId:guid}")]
    public async Task<ActionResult<IEnumerable<Dish>>> GetDishes(Guid restaurantId)
    {
        var dto = await _dishRepository.GetByRestaurantId(restaurantId);
        return dto.Select(d => new Dish(d.Id, d.ImgUrl, d.Name, d.Price)).ToList();
    }
    
    // 使用者-下訂餐點
    [HttpPost("/order")]
    public async Task<IActionResult> CreateOrder([FromBody] OrderRequest order)
    {
        if (await _orderRepository.CreateOrder(order))
        {
            return Ok();
        }
        
        return BadRequest();
    }
    
    // 平台-顯示所有訂單
    [HttpGet("/orders")]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        var orders = await _orderRepository.GetAll();
        var restaurantDic = (await _restaurantRepository.GetAll()).ToDictionary(r => r.Id, r => r.Name);
        var dishDic = (await _dishRepository.GetAll()).ToDictionary(d=>d.Id, d => d);
        var result = new List<Order>();
        
        foreach (var order in orders)
        {
            var dish = dishDic[order.DishId];
            result.Add(new Order(
                restaurantDic[dish.RestaurantId],
                dish.Name,
                order.Amount,
                dish.Price * order.Amount, // 錢每次都重算是好的嗎? 反正規化?
                order.CustomName,
                order.CreateTime));
        }

        return result.OrderBy(o => o.CreateTime).ToList();
    }
    
    // 平台-清空訂單
    [HttpDelete("/orders")]
    public async Task<IActionResult> ClearOrders()
    {
        if (await _orderRepository.ClearAll())
        {
            return Ok();
        }
        
        return BadRequest();
    }
    
}