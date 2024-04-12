using DataStore.Contexts;
using Infrastructure.Entities;

namespace WebApi.Middlewares;

public class ServicesMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context, DataContext dbContext)
    {
        if (!dbContext.Services.Any())
        {
            var servicesList = new List<ServiceEntity>
            {
                new() {ServiceName = "General"},
                new() {ServiceName = "Collaboration"},
                new() {ServiceName = "Pricing"},
                new() {ServiceName = "Courses"}
            };

            dbContext.Services.AddRange(servicesList);
            await dbContext.SaveChangesAsync();
        }
        await _next(context);
    }
}
