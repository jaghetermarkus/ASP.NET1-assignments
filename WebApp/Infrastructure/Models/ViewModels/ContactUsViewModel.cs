using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.ViewModels;

public class ContactUsViewModel
{
    [Display(Name = "Full Name", Prompt = "Enter your full name")]
    [Required(ErrorMessage = "A full first name is required")]
    [MinLength(2, ErrorMessage = "A valid full name is required")]
    [DataType(DataType.Text)]
    public string FullName { get; set; } = null!;


    [EmailAddress]
    [Display(Name = "Email address", Prompt = "Enter your email address")]
    [Required(ErrorMessage = "An valid email is required")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]{2,}$", ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;


    [Display(Name = "Service", Prompt = "Choose the service you are interested in")]
    [DataType(DataType.Text)]
    public string? Service { get; set; }


    [Display(Name = "Message", Prompt = "Enter your message here...")]
    [StringLength(200, ErrorMessage = "Message cannot exceed 200 characters")]
    [DataType(DataType.Text)]
    public string Message { get; set; } = null!;
}