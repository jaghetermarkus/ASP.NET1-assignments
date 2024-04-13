using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class AddressModel
{
    [Required(ErrorMessage = "A valid address is required")]
    [Display(Name = "Address line 1", Prompt = "Enter your address line")]
    [MinLength(2, ErrorMessage = "A valid address is required")]
    [DataType(DataType.Text)]
    public string? AddressLine_1 { get; set; }


    [Display(Name = "Address line 2", Prompt = "Enter your second address line")]
    [MinLength(2, ErrorMessage = "A valid address is required")]
    [DataType(DataType.Text)]
    public string? AddressLine_2 { get; set; }

    [Required(ErrorMessage = "A valid postal code is required")]
    [Display(Name = "Postal code", Prompt = "Enter your postal code")]
    [StringLength(5, MinimumLength = 5, ErrorMessage = "Postal code must be exactly 5 characters")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "Postal code must contain only digits")]
    [DataType(DataType.PhoneNumber)]
    public string? PostalCode { get; set; }

    [Required(ErrorMessage = "A valid city is required")]
    [Display(Name = "City", Prompt = "Enter your city")]
    [MinLength(2, ErrorMessage = "A valid city is required")]
    [DataType(DataType.Text)]
    public string? City { get; set; }
}
