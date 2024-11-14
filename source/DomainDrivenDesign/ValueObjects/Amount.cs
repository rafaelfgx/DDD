using System.Globalization;

namespace DomainDrivenDesign;

public sealed record Amount(decimal Value)
{
    public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
}
