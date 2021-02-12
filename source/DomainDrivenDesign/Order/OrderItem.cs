namespace DomainDrivenDesign
{
    public sealed class OrderItem : Entity
    {
        public OrderItem(Product product, Quantity quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; private set; }

        public Quantity Quantity { get; private set; }

        public Amount SubTotal => new Amount(Product.Price.Value * Quantity.Value);
    }
}
