
using Microsoft.AspNetCore.Mvc;

namespace OpenableProject;
[ApiController]
[Microsoft.AspNetCore.Components.Route("api/[controller]")]
public class RestaurantController : ControllerBase
{
    // GET
    [HttpGet("Get")]
    public List<Restaurant> Get()
    {
       return new List<Restaurant>()
       {
           new Restaurant
           {
               Id = 0,
               Name = "池上便當",
               ImageUrl = new Uri("http://池上便當url.com") 
           },
           new Restaurant
           {
               Id = 1,
               Name = "八方雲集",
               ImageUrl = new Uri("http://八方雲集url.com")
           }
       };
    }
}

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Uri ImageUrl { get; set; }
}