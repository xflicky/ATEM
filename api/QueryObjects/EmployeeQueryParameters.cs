using System.ComponentModel.DataAnnotations;
using api.Attributes;

namespace api.QueryObjects;


public class EmployeeQueryParameters
{
    
    [Required(ErrorMessage = "Employee ID is required.")]
    [ValidEmployeeId]
    public int EmployeeId { get; set; }
    
    [Required(ErrorMessage = "Activity type is required.")]
    public bool Active { get; set; }
}