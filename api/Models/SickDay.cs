namespace api.Models;

public class SickDay
{
    public int Id { get; set; }
    public DateTime RequestDate { get; set; }

    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string Message { get; set; } = string.Empty;

    public int? EmployeeId { get; set; }
    public Employee? Employee { get; set; }
}