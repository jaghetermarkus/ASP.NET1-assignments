using DataStore.Contexts;
using Infrastructure.Entities;
using Newtonsoft.Json;

namespace WebApp.Middlewares;

public class CoursesMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context, DataContext dbContext)
    {
        var coursesJson = File.ReadAllText("courses.json");
        var courses = JsonConvert.DeserializeObject<List<CourseEntity>>(coursesJson);

        if (courses != null)
        {
            foreach (var course in courses)
            {
                var existingCourse = dbContext.Courses.FirstOrDefault(x => x.CourseNumber == course.CourseNumber);

                if (existingCourse == null)
                {
                    dbContext.Courses.Add(course);
                }
            }
            await dbContext.SaveChangesAsync();
        }
        await _next(context);
    }
}
