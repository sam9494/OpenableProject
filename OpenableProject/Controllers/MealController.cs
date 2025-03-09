using Microsoft.AspNetCore.Mvc;
using OpenableProject.DTO;
using OpenableProject.Models;

namespace OpenableProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MealController:ControllerBase
{
    [HttpPost]
    public IActionResult Post(MealRequest request)
    {
        var meal = new Meal(request.Id,request.Name);
        var originalMenu = MenuController.Menus[request.RestaurantId].FirstOrDefault(m=>m.Id == request.MenuId);
        
        if (originalMenu == null)
        {
            return BadRequest("Not found Menu");
        }
        originalMenu.Meals.Add(meal);
        
        return Ok();
    }

}