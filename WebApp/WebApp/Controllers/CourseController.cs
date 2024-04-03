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

    // [Route("/courses")]
    // public async Task<IActionResult> Courses()
    // {
    //     var courses = await _courseService.GetAllCoursesAsync();

    //     ViewBag.Courses = courses;
    //     return View();
    // }

    [Route("/courses/{page?}")]

    public async Task<IActionResult> Courses(string sortOrder, string searchString, string currentFilter, string category, int? page)
    {
        ViewBag.CurrentSort = sortOrder;
        // ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

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
            coursesQuery = coursesQuery.Where(c => c.Category.CategoryName.ToLower() == category.ToLower());
        }

        // switch (sortOrder)
        // {
        //     case "name_desc":
        //         courses = courses.OrderByDescending(s => s.Author);
        //         break;
        //     default:
        //         courses = courses.OrderBy(s => s.Author);
        //         break;
        // }

        // var coursesList = await courses.ToListAsync();

        int pageSize = 3;
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


    public override bool Equals(object? obj)
    {
        return obj is CourseController controller &&
               EqualityComparer<DataContext>.Default.Equals(_context, controller._context);
    }

    [Route("/course")]
    public IActionResult SingleCourse()
    {
        return View();
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
