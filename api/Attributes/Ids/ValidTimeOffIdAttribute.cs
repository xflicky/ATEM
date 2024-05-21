using System.ComponentModel.DataAnnotations;
using api.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Attributes;

public class ValidTimeOffIdAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int timeOffId)
        {
            var dbContext = validationContext.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            var timeOffExists = dbContext!.TimeOffs.AnyAsync(e => e.Id == timeOffId).Result;
            if (!timeOffExists)
            {
                return new ValidationResult("Invalid time off ID.");
            }
        }

        return ValidationResult.Success!;
    }
}
