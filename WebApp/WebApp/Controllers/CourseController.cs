using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers;

[Authorize]
public class CourseController(CourseService courseService) : Controller
{
    private readonly CourseService _courseService = courseService;

    [Route("/courses")]
    public async Task<IActionResult> Courses()
    {
        var courses = await _courseService.GetAllCoursesAsync();

        ViewBag.Courses = courses;
        return View();
    }

    [Route("/course")]
    public IActionResult SingleCourse()
    {
        return View();
    }

}
