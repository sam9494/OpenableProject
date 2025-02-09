using Microsoft.AspNetCore.Mvc;

namespace OpenableProject;
[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    // GET
    [HttpGet("Get")]
    public List<Menu> Get()
    {
        return new List<Menu>()
        {
            new Menu()
            {
                Id = 100,
                Name = "雞腿便當",
                Price = 70m
            },
            new Menu()
            {
                Id = 101,
                Name = "招牌便當",
                Price = 60m
            }
        };
    }
}

public class Menu
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}