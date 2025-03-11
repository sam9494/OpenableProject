using Microsoft.AspNetCore.Mvc;

namespace OpenableProject.Controllers;

public class VendorController : Controller
{
    // GET
    public IActionResult Orders()
    {
        return View();
    }
    public IActionResult Profile()
    {
        return View();
    }
}