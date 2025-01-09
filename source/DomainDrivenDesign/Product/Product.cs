namespace DomainDrivenDesign;

public sealed record Product(string Description, Amount Price) : Entity
{
    public string Description { get; private set; } = Description;

    public Amount Price { get; private set; } = Price;

    public void ChangeDescription(string description) => Description = description;

    public void ChangePrice(Amount price) => Price = price;
}
