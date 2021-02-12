namespace DomainDrivenDesign
{
    public interface IDiscount
    {
        Amount Calculate(Amount amount);

        bool IsApplicable(DiscountType type);
    }
}
