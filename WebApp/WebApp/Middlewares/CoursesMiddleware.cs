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

        /// CATEGORIES
        var categoriesJson = File.ReadAllText("courseCategories.json");
        var categories = JsonConvert.DeserializeObject<List<CategoryEntity>>(categoriesJson);

        if (categories != null)
        {
            foreach (var category in categories)
            {
                var existingCategory = dbContext.Categories.FirstOrDefault(x => x.Id == category.Id);

                if (existingCategory == null)
                {
                    dbContext.Categories.Add(category);
                }
                // else
                // {
                //     existingCategory.Id = category.Id;
                //     existingCategory.CategoryName = category.CategoryName;

                //     dbContext.Entry(existingCategory).State = EntityState.Modified;
                // }
            }
            // await dbContext.SaveChangesAsync();
        }



        /// COURSES
        var coursesJson = File.ReadAllText("courses.json");
        var courses = JsonConvert.DeserializeObject<List<CourseEntity>>(coursesJson);

        if (courses != null)
        {
            foreach (var course in courses)
            {
                var existingCourse = dbContext.Courses.Include(c => c.Details).FirstOrDefault(x => x.CourseNumber == course.CourseNumber);

                if (existingCourse == null)
                {
                    dbContext.Courses.Add(course);
                }
                else
                {
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
                    existingCourse.Reviews = course.Reviews;
                    existingCourse.Articles = course.Articles;
                    existingCourse.Downloads = course.Downloads;
                    existingCourse.Subscribers = course.Subscribers;
                    existingCourse.Followers = course.Followers;
                    existingCourse.Description = course.Description;

                    existingCourse.Learn.Clear();
                    existingCourse.Learn.AddRange(course.Learn);

                    // existingCourse.Details.Clear();

                    // foreach (var detail in course.Details)
                    // {
                    //     existingCourse.Details.Add(detail);
                    // }

                    existingCourse.CategoryId = course.CategoryId;

                    dbContext.Entry(existingCourse).State = EntityState.Modified;
                }
            }
            await dbContext.SaveChangesAsync();
        }
        await _next(context);
    }
}