namespace DomainDrivenDesign
{
    public static class ProductFactory
    {
        public static Product Create(string description, decimal price)
        {
            return new Product(description, new Amount(price));
        }
    }
}
