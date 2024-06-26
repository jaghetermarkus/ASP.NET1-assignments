﻿using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.ViewModels;

public class BasicInfoViewModel
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

    [Display(Name = "Phone", Prompt = "Enter your phone")]
    [MinLength(10, ErrorMessage = "A valid phone number is required")]
    [DataType(DataType.Text)]
    public string? PhoneNumber { get; set; }


    [Display(Name = "Bio", Prompt = "Add a short bio...")]
    [StringLength(200, ErrorMessage = "Bio cannot exceed 200 characters")]
    [DataType(DataType.Text)]
    public string? Biography { get; set; }
}
