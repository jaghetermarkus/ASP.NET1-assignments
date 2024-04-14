using System.ComponentModel.DataAnnotations;
using Infrastructure.Validators;

namespace Infrastructure.Models.ViewModels;

public class SignUpViewModel
{
    [Display(Name = "First Name", Prompt = "Enter your first name")]
    [Required(ErrorMessage = "A valid first name is required")]
    [MinLength(2, ErrorMessage = "A valid first name is required")]
    [DataType(DataType.Text)]
    public string FirstName { get; set; } = null!;


    [Display(Name = "Last name", Prompt = "Enter your last name")]
    [Required(ErrorMessage = "A valid last name is required")]
    [MinLength(2, ErrorMessage = "A valid last name is required")]
    [DataType(DataType.Text)]
    public string LastName { get; set; } = null!;

    [EmailAddress]
    [Display(Name = "Email address", Prompt = "Enter your email address")]
    [Required(ErrorMessage = "An valid email is required")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]{2,}$", ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;


    [Display(Name = "Password", Prompt = "Enter your password")]
    [Required(ErrorMessage = "A valid password is required")]
    [MinLength(8, ErrorMessage = "A minimun 8 characters is required")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_])(?!.*\s).{8,}$", ErrorMessage = "A valid password is required")]
    public string Password { get; set; } = null!;


    [Display(Name = "Confirm password", Prompt = "Confirm your password")]
    [Required(ErrorMessage = "Password must be confirmed")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Password don´t match")]
    public string ConfirmPassword { get; set; } = null!;


    [Display(Name = "I agree to the Terms & Conditions.")]
    [Required(ErrorMessage = "You must accept the terms and conditions")]
    [RequiredCheckbox(ErrorMessage = "You must accept the Terms and Conditions")]
    public bool TermsAndConditions { get; set; }

}
