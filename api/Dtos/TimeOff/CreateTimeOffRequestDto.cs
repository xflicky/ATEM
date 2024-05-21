using System.ComponentModel.DataAnnotations;
using api.Attributes;
using api.Attributes.Date;
using api.Constants;

namespace api.Dtos.TimeOff;

public class CreateTimeOffRequestDto
{
    [Required(ErrorMessage = "Start date is required.")]
    [ValidDateFormat(DateConstants.DateFormat)]
    [MinCurrentDateFormat]
    public string StartDate { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "End date is required.")]
    [ValidDateFormat(DateConstants.DateFormat)]
    [MinCurrentDateFormat]
    public string EndDate { get; set; } = string.Empty;

    [Required(ErrorMessage = "Reason is required.")]
    [MinLength(10, ErrorMessage = "Reason must be at least 10 characters")]
    [MaxLength(200, ErrorMessage = "Reason cannot be over 200 characters")]
    public string Reason { get; set; } = string.Empty;
}