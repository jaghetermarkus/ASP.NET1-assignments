using Infrastructure.Entities;
using X.PagedList;

namespace Infrastructure.Models;

public class CoursesViewModel
{
    public IPagedList<CourseEntity>? Courses { get; set; }
    public List<CategoryEntity>? Categories { get; set; }
}
