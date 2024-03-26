using DataStore.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
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
                else
                {
                    // dbContext.Entry(existingCourse).CurrentValues.SetValues(course);
                    // Uppdatera de icke-nyckel-egenskaperna för den befintliga kursen med egenskaperna från den nya kursen
                    existingCourse.Title = course.Title;
                    existingCourse.IsBestSeller = course.IsBestSeller;
                    existingCourse.IsDigital = course.IsDigital;
                    existingCourse.Author = course.Author;
                    existingCourse.OriginalPrice = course.OriginalPrice;
                    existingCourse.DiscountPrice = course.DiscountPrice;
                    existingCourse.Hours = course.Hours;
                    existingCourse.LikesInProcent = course.LikesInProcent;
                    existingCourse.LikesInNumbers = course.LikesInNumbers;
                    existingCourse.CourseImageUrl = course.CourseImageUrl;

                    // Markera entiteten som ändrad för att den ska sparas i databasen
                    dbContext.Entry(existingCourse).State = EntityState.Modified;
                }
                await dbContext.SaveChangesAsync();
            }
            await _next(context);
        }
    }
}