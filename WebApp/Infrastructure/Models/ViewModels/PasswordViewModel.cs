using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.ViewModels;

public class PasswordViewModel
{
    [Display(Name = "Current password", Prompt = "Enter your password")]
    [Required(ErrorMessage = "A valid password is required")]
    [DataType(DataType.Password)]
    public string CurrentPassword { get; set; } = null!;


    [Display(Name = "New password", Prompt = "Enter your new password")]
    [Required(ErrorMessage = "A valid password is required")]
    [MinLength(8, ErrorMessage = "A minimun 8 characters is required")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_])(?!.*\s).{8,}$", ErrorMessage = "A valid password is required")]
    public string NewPassword { get; set; } = null!;


    [Display(Name = "Confirm new password", Prompt = "Confirm your new password")]
    [Required(ErrorMessage = "Password must be confirmed")]
    [Compare(nameof(NewPassword), ErrorMessage = "Password don´t match")]
    [DataType(DataType.Password)]
    public string ConfirmNewPassword { get; set; } = null!;
}
