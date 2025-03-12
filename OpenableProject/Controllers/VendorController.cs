using Microsoft.AspNetCore.Mvc;
using OpenableProject.Services;

namespace OpenableProject.Controllers;

public class VendorController : Controller
{
    private readonly VendorOrderService _vendorOrderService = new();

    // GET
    public IActionResult Orders(int restaurantId)
    {
        restaurantId = 1;
        var orders = _vendorOrderService.GetAllByRestaurantId(restaurantId);
        return View(orders); // 將訂單資料傳給 View
    }

    public IActionResult Process(int orderId)
    {
        _vendorOrderService.ProcessOrder(orderId);
        return RedirectToAction("Orders", "Vendor");
    }

    public IActionResult Complete(int orderId)
    {
        _vendorOrderService.CompleteOrder(orderId);
        return RedirectToAction("Orders", "Vendor");
    }

    public IActionResult Cancel(int orderId)
    {
        _vendorOrderService.CancelOrder(orderId);
        return RedirectToAction("Orders", "Vendor");
    }

    public IActionResult Profile()
    {
        return View();
    }
}