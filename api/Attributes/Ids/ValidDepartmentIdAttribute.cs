using System.ComponentModel.DataAnnotations;
using api.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Attributes;

public class ValidDepartmentIdAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int departmentId)
        {
            var dbContext = validationContext.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            var departmentExists = dbContext!.Departments.AnyAsync(e => e.Id == departmentId).Result;
            if (!departmentExists)
            {
                return new ValidationResult("Invalid department ID.");
            }
        }

        return ValidationResult.Success!;
    }
}