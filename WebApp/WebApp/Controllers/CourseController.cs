using DataStore.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using WebApp.Services;
using Infrastructure.Models;

namespace WebApp.Controllers;

[Authorize]
public class CourseController(CourseService courseService, DataContext context) : Controller
{
    private readonly CourseService _courseService = courseService;
    private readonly DataContext _context = context;

    [Route("/course/courses/{page?}")]
    public async Task<IActionResult> Courses(string sortOrder, string searchString, string currentFilter, string category, int? page)
    {
        ViewBag.CurrentSort = sortOrder;

        if (searchString != null)
            page = 1;
        else
            searchString = currentFilter;

        ViewBag.CurrentFilter = searchString;
        ViewBag.CurrentCategory = category;

        var coursesQuery = from c in _context.Courses select c;

        if (!String.IsNullOrEmpty(searchString))
        {
            searchString = searchString.ToLower();
            coursesQuery = coursesQuery.Where(c => c.Title.ToLower().Contains(searchString) || c.Author.ToLower().Contains(searchString));
        }

        if (!String.IsNullOrEmpty(category) && category.ToLower() != "all")
        {
            coursesQuery = coursesQuery.Where(c => c.Category!.CategoryName.ToLower() == category.ToLower());
        }

        int pageSize = 6;
        int pageNumber = (page ?? 1);

        var courses = coursesQuery.ToPagedList(pageNumber, pageSize);
        var categories = await _context.Categories.ToListAsync();

        var viewModel = new CoursesViewModel
        {
            Courses = courses,
            Categories = categories
        };

        return View(viewModel);
    }

    [Route("/course/{page?}")]
    public async Task<IActionResult> SingleCourse(string id)
    {
        var course = await _courseService.GetOneCourseAsync(id);

        return View(course);
    }

}
