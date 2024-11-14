namespace DomainDrivenDesign;

public sealed record Order(Customer Customer) : Entity
{
    public Amount Discount { get; private set; } = new(0);

    public IReadOnlyList<OrderItem> Items { get; private set; } = new List<OrderItem>();

    public Amount Total => new(Items.Sum(item => item.SubTotal.Value) - Discount.Value);

    public void AddItem(OrderItem item) => Items = new List<OrderItem>(Items) { item };

    public void ApplyDiscount(Amount discount) => Discount = discount;
}
