using System.ComponentModel.DataAnnotations;

namespace api.Attributes;

public class MaxCurrentYearAttribute : ValidationAttribute
{
    
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int year)
        {
            var now = DateTime.Now.Year;
            if (year > now)
            {
                return new ValidationResult("Invalid year. Year must be less than or equal to the current year.");
            }
        }
        return ValidationResult.Success!;
    }
}