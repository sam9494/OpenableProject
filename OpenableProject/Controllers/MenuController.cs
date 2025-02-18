using Microsoft.AspNetCore.Mvc;

namespace OpenableProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    public static List<MenuItem> menu = new()
    {
        new MenuItem { Id = 1, Name = "Burger", Price = 5.99M },
        new MenuItem { Id = 2, Name = "Pizza", Price = 8.99M }
    };

    [HttpGet]
    public ActionResult<IEnumerable<MenuItem>> GetMenu() => Ok(menu);

    [HttpPost]
    public ActionResult<MenuItem> AddMenuItem(MenuItem item)
    {
        item.Id = menu.Count + 1;
        menu.Add(item);
        return CreatedAtAction(nameof(GetMenu), new { id = item.Id }, item);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteMenuItem(int id)
    {
        var item = menu.FirstOrDefault(m => m.Id == id);
        if (item == null) return NotFound();
        menu.Remove(item);
        return NoContent();
    }
}