using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class SiteSettings : Controller
{
    public IActionResult ThemeMode(string mode)
    {
        var option = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(30),
        };
        Response.Cookies.Append("theme", mode, option);

        return Ok();
    }

    public IActionResult ConsentCookies(string mode)
    {
        var option = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(1),
            HttpOnly = true,
            Secure = true
        };
        Response.Cookies.Append("consent", "true", option);

        return Ok();
    }
}
