namespace DomainDrivenDesign;

public sealed class DiscountService
{
    public Amount Calculate(Amount amount, DiscountType type)
    {
        var discount = Factory.Get<IDiscount>(x => x.IsApplicable(type));

        return discount is null ? amount : discount.Calculate(amount);
    }
}
