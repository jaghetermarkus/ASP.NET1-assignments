using System.ComponentModel.DataAnnotations;
using Infrastructure.Validators;

namespace Infrastructure.Models.ViewModels;

public class DeleteAccountViewModel
{
    [Display(Name = "Yes, I want to delete my account.")]
    [Required(ErrorMessage = "You must confirm to delete your account")]
    [RequiredCheckbox(ErrorMessage = "You must confirm to delete your account")]
    public bool DeleteAccount { get; set; }
}
