using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class ServiceEntity
{
    [Key]
    public int Id { get; set; }
    public string ServiceName { get; set; } = null!;
}