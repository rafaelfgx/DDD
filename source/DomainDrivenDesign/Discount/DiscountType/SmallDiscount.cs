namespace DomainDrivenDesign
{
    public sealed class SmallDiscount : IDiscount
    {
        public Amount Calculate(Amount amount)
        {
            return new Amount(amount.Value * 0.1M);
        }

        public bool IsApplicable(DiscountType type) => type == DiscountType.Small;
    }
}
