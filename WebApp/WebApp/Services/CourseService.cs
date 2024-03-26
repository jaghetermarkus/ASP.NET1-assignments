using DataStore.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Services;

public class CourseService(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<List<CourseEntity>> GetAllCoursesAsync()
    {
        try
        {
            return await _context.Courses.ToListAsync();
        }
        catch { }
        return null!;
    }



}
