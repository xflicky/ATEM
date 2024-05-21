namespace api.Dtos.AttendanceRecord;

public class AttendanceTimeSheetDto
{
    public int? EmployeeId { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public string EmployeeSurName { get; set; } = string.Empty;
    
    public int MonthPeriod { get; set; }
    public int YearPeriod { get; set; }
    
    public List<AttendanceRecordDto> AttendanceRecords { get; set; } = [];
}