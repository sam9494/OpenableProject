using Microsoft.AspNetCore.Mvc;
using OpenableProject.Model;
using OpenableProject.Services;

namespace OpenableProject.Controller;
[ApiController]
[Route("api/[controller]")]
public class RestaurantsController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;

    public RestaurantsController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Restaurant>> GetRestaurants()
    {
        var restaurants = _restaurantService.GetAllRestaurants();
        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public ActionResult<Restaurant> GetRestaurant(int id)
    {
        var restaurant = _restaurantService.GetRestaurantById(id);
        return Ok(restaurant);
    }
    
}