using System.ComponentModel.DataAnnotations;
using System.Globalization;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ValidDateFormatAttribute : ValidationAttribute
{
    private readonly string _format;

    public ValidDateFormatAttribute(string format)
    {
        _format = format;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var dateString = value as string;

        if (string.IsNullOrEmpty(dateString))
        {
            // Date string is null or empty, no need to validate further
            return ValidationResult.Success;
        }

        if (!DateTime.TryParseExact(dateString, _format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
        {
            return new ValidationResult($"The date format for {validationContext.DisplayName} must be {_format}.");
        }

        return ValidationResult.Success;
    }
}