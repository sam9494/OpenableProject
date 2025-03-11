using Microsoft.AspNetCore.Mvc;

namespace OpenableProject.Controllers.VendorAdmin;

public class DashboardController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}