namespace DomainDrivenDesign
{
    public sealed class DiscountService
    {
        public Amount Calculate(Amount amount, DiscountType type)
        {
            var discount = Factory.Get<IDiscount>(x => x.IsApplicable(type));

            if (discount == null) { return amount; }

            return discount.Calculate(amount);
        }
    }
}
