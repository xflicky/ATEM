using api.Attributes;
using api.Attributes.Date;

namespace api.QueryObjects;

[YearAndOptionalMonth] 
public class TimeOffQueryParameters
{
    [ValidEmployeeId]
    public int? EmployeeId { get; set; }
    
    [ValidMonth]
    public int? Month { get; set; }
    
    [ValidYear]
    public int? Year { get; set; }
}