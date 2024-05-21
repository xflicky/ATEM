using System.ComponentModel.DataAnnotations;

namespace api.Attributes.Date;

public class MinCurrentYearAttribute : ValidationAttribute
{
    
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int year)
        {
            if (year < DateTime.Now.Year)
            {
                return new ValidationResult("Invalid year. Year must be greater than or equal to the current year.");
            }
        }
        return ValidationResult.Success!;
    }
}