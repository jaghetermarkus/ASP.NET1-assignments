using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class ContactEntity
{
    [Key]
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public virtual ICollection<ContactMessageEntity> Messages { get; set; } = new List<ContactMessageEntity>();
}
