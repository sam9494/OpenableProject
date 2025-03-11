using Microsoft.AspNetCore.Mvc;
using OpenableProject.Services;

public class AccountController : Controller
{
    private readonly JwtService _jwtService;

    public AccountController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // 模擬用戶驗證（正式應用應查詢資料庫）
        if (username == "admin" && password == "admin")
        {
            // 生成 JWT Token
            var token = _jwtService.GenerateToken(username);

            // 把 token 存儲在 Cookie 中
            Response.Cookies.Append("AuthToken", token, new CookieOptions
            {
                HttpOnly = true, // 防止 JS 訪問
                Secure = true, // 確保 HTTPS 上使用
                SameSite = SameSiteMode.Strict
            });
            // 登入成功後，導向到 vendoradmin 的 Dashboard
            return RedirectToAction("Index", "Dashboard");
        }

        // 登入失敗，顯示錯誤消息
        ViewBag.Error = "Invalid username or password";
        return View();
    }
}