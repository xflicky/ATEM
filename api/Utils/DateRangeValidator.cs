namespace api.Utils;

public static class DateRangeValidator
{
    public static bool IsDateWithinRange(DateOnly startDate, DateOnly endDate, int minDays, int maxDays)
    {
        DateTime startDateTime = startDate.ToDateTime(TimeOnly.MinValue);
        DateTime endDateTime = endDate.ToDateTime(TimeOnly.MinValue);
        
        TimeSpan dateSpan = endDateTime - startDateTime;
        
        return dateSpan.Days >= minDays && dateSpan.Days <= maxDays;
    }
}