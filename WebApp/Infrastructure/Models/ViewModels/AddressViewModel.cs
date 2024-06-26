﻿using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.ViewModels;

public class AddressViewModel
{
    [Display(Name = "Address line 1", Prompt = "Enter your address line")]
    public string AddressLine_1 { get; set; } = null!;


    [Display(Name = "Address line 2", Prompt = "Enter your second address line")]
    public string? AddressLine_2 { get; set; }


    [Display(Name = "Postal code", Prompt = "Enter your postal code")]
    public string PostalCode { get; set; } = null!;


    [Display(Name = "City", Prompt = "Enter your city")]
    public string City { get; set; } = null!;

}
