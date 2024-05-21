using System.ComponentModel.DataAnnotations;
using api.Attributes;

namespace api.Dtos.Employee;

public class UpdateEmployeeRequestDto
{
    [Required(ErrorMessage = "The Name field is required.")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
    [MaxLength(15, ErrorMessage = "Name cannot be over 15 over characters")]
    public string Name { get; set; } = string.Empty;
   
    [Required(ErrorMessage = "The SurName field is required.")]
    [MinLength(2, ErrorMessage = "SurName must be at least 2 characters")]
    [MaxLength(15, ErrorMessage = "SurName cannot be over 15 over characters")]
    public string SurName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "The Address field is required.")]
    [Address]
    public string Address { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "The email field is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "The phone field is required.")]
    [Phone(ErrorMessage = "Invalid phone number.")]
    public string Phone { get; set; } = string.Empty;
}