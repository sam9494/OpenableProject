using Microsoft.AspNetCore.Mvc;

namespace OpenableProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    [HttpGet]
    public List<Meal> GetByRestaurant(int restaurantId)
    {
        return
            new List<Meal>
                {
                    new Meal { Id = 1, RestaurantId = 1, Name = "雞腿便當" },
                    new Meal { Id = 2, RestaurantId = 1, Name = "排骨便當" },
                    new Meal { Id = 3, RestaurantId = 2, Name = "漢堡" },
                    new Meal { Id = 4, RestaurantId = 2, Name = "炸雞" }
                }
                .Where(m => m.RestaurantId == restaurantId)
                .ToList();
    }
}

public class Meal
{
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public string Name { get; set; }
}