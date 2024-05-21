using System.ComponentModel.DataAnnotations;

namespace api.Attributes.Date;

public class ValidYearAttribute : ValidationAttribute
{
    
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int year)
        {
            if (year < 1900 || year > DateTime.Now.Year)
            {
                return new ValidationResult("Invalid year. Year must be between 1900 and the current year.");
            }
        }
        return ValidationResult.Success!;
    }
    
}