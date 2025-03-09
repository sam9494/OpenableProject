using Microsoft.AspNetCore.Mvc;
using OpenableProject.Models;

namespace OpenableProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    public static readonly Dictionary<int,List<Menu>> Menus = new()
    {
        // RestaurantId,IEnumerable<Menu>
        {1, [
                new Menu
                {
                    Id = 1,Meals =
                    [
                        new Meal(1, "雞腿便當"),
                        new Meal(2, "排骨便當")
                    ]
                }
            ]
        },
        {2, [
                new Menu
                {
                    Id = 2,Meals =
                    [
                        new Meal(3, "漢堡"),
                        new Meal(4, "炸雞")
                    ]
                }
            ]
        }
    };
    
    [HttpGet]
    public IEnumerable<Menu> Get(int restaurantId)
    {
        return Menus[restaurantId];
    }
    
    
    [HttpPost]
    public ActionResult<IEnumerable<Menu>> Post(MenuRequest request)
    {
        if (Menus[request.RestaurantId].Any(m => m.Id == request.Id))
        {
            return BadRequest("The menuId already exist");
        }

        var menu = new Menu(){ Id = request.Id,Meals = request.Meals };
        Menus[request.RestaurantId].Add(menu);
        return Menus[request.RestaurantId];
    }
}

public class MenuRequest
{
    public int Id { get; set; }
    public List<Meal> Meals { get; set; }
    public int RestaurantId { get; set; }
}