using Microsoft.AspNetCore.Mvc;
using OpenableProject.Models;

namespace OpenableProject.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    // GET
    [HttpGet()]
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