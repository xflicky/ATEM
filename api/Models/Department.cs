namespace api.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    
    public int? SupervisorId { get; set; }
    public Employee? Supervisor { get; set; }
    public List<Employee> Employees { get; set; } = [];
    
    public DateTime RegistrationDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}