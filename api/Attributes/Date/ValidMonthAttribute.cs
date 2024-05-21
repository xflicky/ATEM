using System.ComponentModel.DataAnnotations;

namespace api.Attributes;

public class ValidMonthAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int month)
        {
            if (month < 1 || month > 12)
            {
                return new ValidationResult("Invalid month. Month must be between 1 and 12.");
            }
        }
        return ValidationResult.Success!;
    }
}