namespace api.Models;

public class TimeOff
{
    public int Id { get; set; }
    public DateTime RequestDate { get; set; }

    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }

    public string Reason { get; set; } = string.Empty;
    public bool Approved { get; set; }

    public int? EmployeeId { get; set; }
    public Employee? Employee { get; set; }
}