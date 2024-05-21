namespace api.Dtos.AttendanceRecord;

public class AttendanceRecordDto
{
    public int Id { get; set; }
    public int? EmployeeId { get; set; }
    public DateTime EvidenceDate { get; set; }
    public string Type { get; set; } = string.Empty;
}
