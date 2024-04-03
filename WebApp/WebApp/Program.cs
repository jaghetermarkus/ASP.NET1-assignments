using DataStore.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using WebApp.Middlewares;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<AccountService>();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));
builder.Services.AddDefaultIdentity<UserEntity>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false; // false as standard
    x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<DataContext>();

var app = builder.Build();
app.UseExceptionHandler("/Home/Error");
app.UseHsts();
app.UseMiddleware<CoursesMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
