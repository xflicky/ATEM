using System.ComponentModel.DataAnnotations;

namespace api.Attributes.Date;

public class MinCurrentMonthAttribute : ValidationAttribute
{
    
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int month)
        {
            if (month < DateTime.Now.Month)
            {
                return new ValidationResult("Invalid month. Month must be greater than or equal to the current month.");
            }
        }
        return ValidationResult.Success!;
    }
}