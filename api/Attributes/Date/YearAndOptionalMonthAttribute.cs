using api.QueryObjects;

namespace api.Attributes;

using System;
using System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class YearAndOptionalMonthAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is TimeOffQueryParameters queryParams)
        {
            bool yearHasValue = queryParams.Year.HasValue;
            bool monthHasValue = queryParams.Month.HasValue;

            if (!yearHasValue && monthHasValue)
            {
                return new ValidationResult("Month cannot be provided without a year.");
            }
            
            return ValidationResult.Success!;
        }

        return new ValidationResult("Invalid query parameters.");
    }
}
