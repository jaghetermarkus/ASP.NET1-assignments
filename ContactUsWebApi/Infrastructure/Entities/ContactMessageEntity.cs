using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class ContactMessageEntity
{
    [Key]
    public int Id { get; set; }
    public int ContactId { get; set; }
    public virtual ContactEntity Contact { get; set; } = null!;
    public int? ServiceId { get; set; }
    public virtual ServiceEntity? Service { get; set; }
    public string Message { get; set; } = null!;
    public DateTime Created { get; set; }

}
