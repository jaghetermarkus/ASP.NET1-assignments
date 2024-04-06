using System.ComponentModel.DataAnnotations;
using WebApp.Validators;

namespace WebApp.Models;

public class DeleteAccountViewModel
{
    [Display(Name = "Yes, I want to delete my account.")]
    [Required(ErrorMessage = "You must confirm to delete your account")]
    [RequiredCheckbox(ErrorMessage = "You must accept the Terms and Conditions")]
    public bool DeleteAccount { get; set; }
}
