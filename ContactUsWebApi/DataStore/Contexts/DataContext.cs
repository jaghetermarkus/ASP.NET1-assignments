using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataStore.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<ServiceEntity> Services { get; set; }
    public DbSet<ContactMessageEntity> Messages { get; set; }
}
