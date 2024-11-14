using System.Globalization;

namespace DomainDrivenDesign;

public sealed record Quantity(decimal Value)
{
    public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
}
