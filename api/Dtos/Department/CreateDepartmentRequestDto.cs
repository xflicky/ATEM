using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Department;

public class CreateDepartmentRequestDto
{
    [MinLength(2, ErrorMessage = "Department must be at least 2 characters")]
    [MaxLength(15, ErrorMessage = "Department cannot be over 15 over characters")]
    public string Name { get; set; } = string.Empty;
}