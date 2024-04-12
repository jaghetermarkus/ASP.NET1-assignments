namespace Infrastructure.Models;

public class ContactFormModel
{
    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int ServiceId { get; set; }

    public string Message { get; set; } = null!;
}
