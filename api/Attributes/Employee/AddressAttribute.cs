using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace api.Attributes;

public class AddressAttribute : ValidationAttribute
{
    public AddressAttribute()
    {
        ErrorMessage = "Address must consist of a 'street number, city'.";
    }

    public override bool IsValid(object? value)
    {
        if (value is string address)
        {
            var regex = new Regex(@"^[A-Za-z\s]+ \d+, [A-Za-z\s]+$");
            return regex.IsMatch(address);
        }
        return false;
    }
}