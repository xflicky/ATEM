using System.ComponentModel.DataAnnotations;
using api.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Attributes;

public class ValidEmployeeIdAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int employeeId)
        {
            var dbContext = validationContext.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            var employeeExists = dbContext!.Employees.AnyAsync(e => e.Id == employeeId).Result;
            if (!employeeExists)
            {
                return new ValidationResult("Invalid employee ID.");
            }
        }

        return ValidationResult.Success!;
    }
}