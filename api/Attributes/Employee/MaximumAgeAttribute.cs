using System.ComponentModel.DataAnnotations;
using api.Utils;

namespace api.Attributes.Age;

public class MaximumAgeAttribute : ValidationAttribute
{
    private readonly int _maximumAge;

    public MaximumAgeAttribute(int maximumAge)
    {
        _maximumAge = maximumAge;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string dateString)
        {
            if (DateTime.TryParse(dateString, out DateTime birthDate))
            {
                int age = AgeCalculator.CalculateAge(birthDate);
                if (age > _maximumAge)
                {
                    return new ValidationResult($"Employee cannot be older than {_maximumAge} years old.");
                }
            }
        }

        return ValidationResult.Success!;
    }
}