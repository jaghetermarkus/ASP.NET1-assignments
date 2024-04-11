using Infrastructure;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataStore.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<SubscriberEntity> Subscribers { get; set; }
}