namespace DomainDrivenDesign;

public static class ProductFactory
{
    public static Product Create(string description, decimal price)
    {
        return new(description, new Amount(price));
    }
}
