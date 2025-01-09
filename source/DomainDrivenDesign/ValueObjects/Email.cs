using System.Text.RegularExpressions;

namespace DomainDrivenDesign;

public sealed record Email(string Value)
{
    public bool Invalid => !Valid;

    public bool Valid
    {
        get
        {
            if (string.IsNullOrWhiteSpace(Value)) return false;

            const string regex = @"^([a-z0-9_\.\-]{3,})@([\da-z\.\-]{3,})\.([a-z\.]{2,6})$";

            return new Regex(regex).IsMatch(Value);
        }
    }

    public override string ToString() => Value;
}
