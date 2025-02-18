using Microsoft.AspNetCore.Mvc;
using OpenableProject.Entities;

namespace OpenableProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantController : ControllerBase
{
    [HttpGet]
    public List<Restaurant> GetAll()
    {
        return
        [
            new Restaurant { Id = 1, Name = "便當店" },
            new Restaurant { Id = 2, Name = "速食店" }
        ];
    }
}