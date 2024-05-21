namespace api.Dtos.SickDay;

public class SickDayDto
{
    public int? EmployeeId { get; set; }
    
    public DateTime RequestDate { get; set; }

    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    
    public string Message { get; set; } = string.Empty;
}