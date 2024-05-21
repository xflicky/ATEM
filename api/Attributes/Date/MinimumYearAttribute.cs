using System.ComponentModel.DataAnnotations;

namespace api.Attributes.Date;

public class MinimumYearAttribute : ValidationAttribute
{
    private int _minYear;
    
    public MinimumYearAttribute(int minYear)
    {
        _minYear = minYear;
        ErrorMessage = $"Invalid year. Year must be greater than or equal to {_minYear}.";
    }
    
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int year)
        {
            if (year < _minYear || year > DateTime.Now.Year)
            {
                return new ValidationResult($"Invalid year. Year must be between {_minYear} and {DateTime.Now.Year}.");
            }
        }
        return ValidationResult.Success!;
    }
}
