namespace Infrastructure.Models;

public class UserModel
{
    public string Id { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ProfileImage { get; set; }
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? Biography { get; set; }
    public string? AddressLine_1 { get; set; }
    public string? AddressLine_2 { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
}