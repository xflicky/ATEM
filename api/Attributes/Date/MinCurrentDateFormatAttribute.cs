using System.ComponentModel.DataAnnotations;
using api.Constants;

namespace api.Attributes.Date;

public class MinCurrentDateFormatAttribute : ValidationAttribute
{
    
    public MinCurrentDateFormatAttribute()
    {
        ErrorMessage = $"Date must be in the format '{DateConstants.DateFormat}' and cannot be in the past.";
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string dateString)
        {
            if (DateTime.TryParse(dateString, out DateTime date))
            {
                if (date < DateTime.Now)
                {
                    return new ValidationResult("Date cannot be in the past.");
                }
            }
            else
            {
                return new ValidationResult($"Date must be in the format '{DateConstants.DateFormat}'.");
            }
        }

        return ValidationResult.Success!;
    }
}