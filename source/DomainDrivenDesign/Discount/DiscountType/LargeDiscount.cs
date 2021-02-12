namespace DomainDrivenDesign
{
    public sealed class LargeDiscount : IDiscount
    {
        public Amount Calculate(Amount amount)
        {
            return new Amount(amount.Value * 0.5M);
        }

        public bool IsApplicable(DiscountType type) => type == DiscountType.Large;
    }
}
