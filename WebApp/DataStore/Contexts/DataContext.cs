using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataStore.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<UserEntity>(options)
{
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<CourseDetailsEntity> CourseDetails { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
}
