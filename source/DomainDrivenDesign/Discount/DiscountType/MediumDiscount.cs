namespace DomainDrivenDesign;

public sealed class MediumDiscount : IDiscount
{
    public Amount Calculate(Amount amount) => new(amount.Value * 0.25M);

    public bool IsApplicable(DiscountType type) => type == DiscountType.Medium;
}
