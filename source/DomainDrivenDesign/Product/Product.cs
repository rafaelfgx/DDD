namespace DomainDrivenDesign
{
    public sealed class Product : Entity
    {
        public Product(string description, Amount price)
        {
            Description = description;
            Price = price;
        }

        public string Description { get; private set; }

        public Amount Price { get; private set; }

        public void ChangeDescription(string description)
        {
            Description = description;
        }

        public void ChangePrice(Amount price)
        {
            Price = price;
        }
    }
}
