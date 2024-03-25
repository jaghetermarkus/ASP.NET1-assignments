using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class DeleteAccountViewModel
{
    [Display(Name = "Yes, I want to delete my account.")]
    [Required(ErrorMessage = "You must confirm to delete your account")]
    public bool DeleteAccount { get; set; }
}
