using System.ComponentModel.DataAnnotations;
using api.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Attributes;

public class ValidSickDayIdAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int sickDayId)
        {
            var dbContext = validationContext.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            var sickDayExists = dbContext!.SickDays.AnyAsync(e => e.Id == sickDayId).Result;
            if (!sickDayExists)
            {
                return new ValidationResult("Invalid sick day ID.");
            }
        }

        return ValidationResult.Success!;
    }
}