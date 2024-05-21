using api.Dtos.Employee;

namespace api.Dtos.Department;

public class DepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public int? SupervisorId { get; set; }
    public List<EmployeeDto> Employees { get; set; } = [];
}