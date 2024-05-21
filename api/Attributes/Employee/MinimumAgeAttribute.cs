using System.ComponentModel.DataAnnotations;
using api.Utils;

namespace api.Attributes.Age;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class MinimumAgeAttribute : ValidationAttribute
{
    private readonly int _minimumAge;

    public MinimumAgeAttribute(int minimumAge)
    {
        _minimumAge = minimumAge;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string dateString)
        {
            if (DateTime.TryParse(dateString, out DateTime birthDate))
            {
                int age = AgeCalculator.CalculateAge(birthDate);
                if (age < _minimumAge)
                {
                    return new ValidationResult($"Employee must be at least {_minimumAge} years old.");
                }
            }
        }

        return ValidationResult.Success!;
    }
}