namespace api.Models;

public class AttendanceRecord
{
    public int Id { get; set; }
    public DateTime EvidenceDate { get; set; }
    
    public string Type { get; set; } = string.Empty;
    
    public int? EmployeeId { get; set; }
    public Employee? Employee { get; set; }
}