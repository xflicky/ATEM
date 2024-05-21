namespace api.Models;

public class Employee
{
    public int Id { get; set; }
    public DateTime RegistrationDate { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string SurName { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public string Address { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    
    public bool IsPresent { get; set; } = false;
    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
    
    public bool IsDeleted { get; set; } = false;
}