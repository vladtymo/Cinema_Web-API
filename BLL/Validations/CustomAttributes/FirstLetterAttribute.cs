﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Validators
{
    public class FirstLetterAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult("The property must not be empty!");

            if (!char.IsUpper(value.ToString()[0]))
                return new ValidationResult("The first letter must be in upper case!");

            return ValidationResult.Success;
        }
    }
}
