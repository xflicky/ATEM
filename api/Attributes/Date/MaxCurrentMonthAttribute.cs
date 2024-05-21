using System.ComponentModel.DataAnnotations;

namespace api.Attributes;

public class MaxCurrentMonthAttribute : ValidationAttribute
{
    
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int month)
        {
            var now = DateTime.Now.Month;
            if (month > now)
            {
                return new ValidationResult("Invalid month. Month must be less than or equal to the current month.");
            }
        }
        return ValidationResult.Success!;
    }
}