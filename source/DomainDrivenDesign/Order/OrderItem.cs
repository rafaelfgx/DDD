namespace DomainDrivenDesign;

public sealed record OrderItem(Product Product, Quantity Quantity) : Entity
{
    public Amount SubTotal => new(Product.Price.Value * Quantity.Value);
}
