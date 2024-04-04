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

    public async Task<CourseEntity> GetOneCourseAsync(string id)
    {
        try
        {
            var entity = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                return entity;
            }
        }
        catch { }
        return null!;
    }



}
