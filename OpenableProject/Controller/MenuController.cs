using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OpenableProject.Model;
using OpenableProject.Services;

namespace OpenableProject.Controller;
[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;

    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }
    

    [HttpGet("{restaurantid}")]
    public ActionResult<IEnumerable<Menu>> GetMenu(int restaurantid)
    {
        var menus = _menuService.GetMenuByRestaurantId(restaurantid);
        if (!menus.Any())
        {
            return NotFound();
        }
        return Ok(menus);
    }
}