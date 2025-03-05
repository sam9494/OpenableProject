using Microsoft.AspNetCore.Mvc;

namespace OpenableProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Menu> GetByRestaurant(int restaurantId)
    {
        var menus = new List<Menu>()
        {
            new Menu()
            {
                RestaurantId = 1,
                Meals = new List<Meal>()
                {
                    new Meal { Id = 1,  Name = "雞腿便當" },
                    new Meal { Id = 2,  Name = "排骨便當" },
                }
            },
            new Menu()
            {
                RestaurantId = 2,
                Meals = new List<Meal>()
                {
                    new Meal { Id = 3,  Name = "漢堡" },
                    new Meal { Id = 4,  Name = "炸雞" }
                }
            }
        };

        return menus.Where(x => x.RestaurantId == restaurantId);
    }
}

public class Menu
{
    public List<Meal> Meals { get; set; }
    public int RestaurantId { get; set; }
}

public class Meal
{
    public int Id { get; set; }
    public string Name { get; set; }
}