using System.ComponentModel.DataAnnotations;

namespace api.QueryObjects;

public class ActivityQueryParameter
{
    [Required(ErrorMessage = "Activity is required.")]
    public bool Active { get; set; } 
}