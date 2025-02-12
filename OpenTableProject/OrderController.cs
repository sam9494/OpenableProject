
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;
using OpenTableProject.Model;

namespace OpenTableProject;
[ApiController]
[Microsoft.AspNetCore.Components.Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private static readonly object Lock = new();
    private static int _nextOrderId; // 初始訂單編號
    private static readonly ConcurrentDictionary<int,Order> Orders = new(); //這邊用readonly會混淆意義嗎? 參考不變但實際上會做內容的更動
    
    private static readonly Guid BaFunId = Guid.Parse("823d165e-36e9-4ce6-aa64-01eece0d8f76");
    private static readonly Guid ChiShanId = Guid.Parse("d14517bd-73e0-478f-908d-a5c43b947f90");
    private static readonly Dictionary<Guid, Restaurant> Restaurants = new()
    {
        {BaFunId,new Restaurant(BaFunId, "八方雲集",[
            new Dish(Guid.Parse("cb398154-0770-4922-94c8-e7640b061563"),
                "https://imgur.com/lMBQXn4",
                "鍋貼10顆",
                60)])},
        {ChiShanId,new Restaurant(ChiShanId, "池上便當",[
            new Dish(Guid.Parse("e907923b-6792-4068-959f-29fba2175743"),
                "https://imgur.com/oA5Fm9w",
                "招牌便當",
                110)])},
    };
    
    // 使用者-顯示所有店家
    [HttpGet("/restaurants")]
    public ActionResult<Dictionary<Guid,string>> GetRestaurants()
    {
        return Restaurants.ToDictionary(k 
            => k.Key, v => v.Value.Name);
    }
    
    // 使用者-顯示所有店家的餐點
    [HttpGet("/dishes/{restaurantId:guid}")]
    public ActionResult<IEnumerable<Dish>> GetDishes(Guid restaurantId)
    {
        return Restaurants.TryGetValue(restaurantId, out var restaurant) ? 
            Ok(restaurant.Dishes) : StatusCode(404,"查無此餐廳");
    }
    
    // 使用者-下訂餐點
    [HttpPost("/order")]
    public IActionResult CreateOrder([FromBody] Order order)
    {
        var orderId = Interlocked.Increment(ref _nextOrderId);
        if (Orders.TryAdd(orderId, order))
        {
            return Ok();
        }
        
        return BadRequest();
    }
    
    // 平台-顯示所有訂單
    [HttpGet("/orders")]
    public ActionResult<Dictionary<int,Order>> GetOrders()
    {
        return Ok(Orders);
    }
    
    // 平台-清空訂單
    [HttpDelete("/orders")]
    public IActionResult ClearOrders()
    {
        lock (Lock)
        {
            _nextOrderId = 0;
            Orders.Clear();    
        }
        
        return Ok();
    }
    
}