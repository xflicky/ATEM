using System.ComponentModel.DataAnnotations;
using api.Attributes;
using api.Attributes.Date;

namespace api.QueryObjects;

public class TimeSheetQueryParameters
{
    [Required(ErrorMessage = "EmployeeId is required")]
    [ValidEmployeeId]
    public int EmployeeId { get; set; }
    
    [Required(ErrorMessage = "Month is required")]
    [MaxCurrentMonth]
    public int Month { get; set; }
    
    [Required(ErrorMessage = "Year is required")]
    [MaxCurrentYear]
    public int Year { get; set; }
}