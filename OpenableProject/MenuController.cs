using Microsoft.AspNetCore.Mvc;

namespace OpenableProject;
[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    // GET
    [HttpGet("Get")]
    public Menu Get()
    {
        return new Menu()
        {
            MenuItems = new List<MenuItem>()
            {
                new MenuItem()
                {
                    Id = 100,
                    Name = "雞腿便當",
                    Price = 70m
                },
                new MenuItem()
                {
                    Id = 101,
                    Name = "招牌便當",
                    Price = 60m
                }
            }
        };
    }
}

public class Menu
{
    public List<MenuItem> MenuItems { get; set; }
}

public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}