using System.ComponentModel.DataAnnotations;
using api.Attributes;
using api.Attributes.Date;
using api.Constants;

namespace api.Dtos.SickDay;

public class CreateSickDayAnnouncementDto
{
    [Required(ErrorMessage = "Start date is required.")]
    [MinCurrentDateFormat]
    public string StartDate { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "End date is required.")]
    [MinCurrentDateFormat]
    public string EndDate { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Message is required.")]
    [MinLength(10, ErrorMessage = "Message must be at least 10 characters")]
    [MaxLength(200, ErrorMessage = "Message cannot be over 100 characters")]
    public string Message { get; set; } = string.Empty;
}