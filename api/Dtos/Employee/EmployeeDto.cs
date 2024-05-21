using System.Text.Json.Serialization;
using api.Utils;

namespace api.Dtos.Employee;

public class EmployeeDto
{
    public int Id { get; set; }
    public int? DepartmentId { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string SurName { get; set; } = string.Empty;
    
    public DateOnly BirthDate { get; set; }
    public string Address { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public bool IsPresent { get; set; } = false;
}   