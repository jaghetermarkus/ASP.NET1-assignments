﻿using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Validators;

public class RequiredCheckbox : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return value is bool b && b;
    }
}
