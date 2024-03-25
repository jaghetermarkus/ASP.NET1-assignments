using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Authorize]
public class CourseController : Controller
{
    [Route("/courses")]
    public IActionResult Courses()
    {
        return View();
    }

    [Route("/course")]
    public IActionResult SingleCourse()
    {
        return View();
    }

}
