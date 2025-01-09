# Domain-Driven Design

Domain-Driven Design is a software development approach in which it utilizes concepts and good practices related to object-oriented programming.

## Books

Domain-Driven Design: Tackling Complexity in the Heart of Software - Eric Evans | Implementing Domain-Driven Design - Vaughn Vernon
:-------------------------:|:-------------------------:
![](https://dddcommunity.org/wp-content/uploads/files/images/cover_medium.jpg) | ![](https://dddcommunity.org/wp-content/uploads/2013/02/implementing-domain-driven-design-400x400-imae6dr5trk3uycd.jpeg)

## Tests

```cs
[TestClass]
public class Tests
{
    [TestMethod]
    public void Email()
    {
        Assert.IsTrue(new Email("domain.com").Invalid);
        Assert.IsTrue(new Email(string.Empty).Invalid);
        Assert.IsTrue(new Email("email@domain.com").Valid);
    }

    [TestMethod]
    public void Order()
    {
        var customer = CustomerFactory.Create("Luke", "Skywalker", "luke.skywalker@starwars.com");

        var product = ProductFactory.Create("Millennium Falcon", 500_000_000);

        var item = OrderItemFactory.Create(product, 1);

        var order = OrderFactory.Create(customer);

        order.AddItem(item);

        var discount = new DiscountService().Calculate(order.Total, DiscountType.Large);

        order.ApplyDiscount(discount);

        Assert.AreEqual(250_000_000, order.Total.Value);
    }
}
```

## Customer

```cs
public sealed record Customer(FullName FullName, Email Email) : Entity
{
    public Email Email { get; private set; } = Email;

    public FullName FullName { get; private set; } = FullName;

    public void ChangeEmail(Email email) => Email = email;

    public void ChangeFullName(FullName fullName) => FullName = fullName;
}
```

```cs
public static class CustomerFactory
{
    public static Customer Create(string firstName, string lastName, string email)
    {
        return new(new FullName(firstName, lastName), new Email(email));
    }
}
```

## Product

```cs
public sealed record Product(string Description, Amount Price) : Entity
{
    public string Description { get; private set; } = Description;

    public Amount Price { get; private set; } = Price;

    public void ChangeDescription(string description) => Description = description;

    public void ChangePrice(Amount price) => Price = price;
}
```

```cs
public static class ProductFactory
{
    public static Product Create(string description, decimal price)
    {
        return new(description, new Amount(price));
    }
}
```

## Order

```cs
public sealed record Order(Customer Customer) : Entity
{
    public Amount Discount { get; private set; } = new(0);

    public IReadOnlyList<OrderItem> Items { get; private set; } = new List<OrderItem>();

    public Amount Total => new(Items.Sum(item => item.SubTotal.Value) - Discount.Value);

    public void AddItem(OrderItem item) => Items = new List<OrderItem>(Items) { item };

    public void ApplyDiscount(Amount discount) => Discount = discount;
}
```

```cs
public static class OrderFactory
{
    public static Order Create(Customer customer) => new(customer);
}
```

## Order Item

```cs
public sealed record OrderItem(Product Product, Quantity Quantity) : Entity
{
    public Amount SubTotal => new(Product.Price.Value * Quantity.Value);
}
```

```cs
public static class OrderItemFactory
{
    public static OrderItem Create(Product product, decimal quantity)
    {
        return new(product, new Quantity(quantity));
    }
}
```

## Discount

```cs
public enum DiscountType
{
    Small = 1,
    Medium = 2,
    Large = 3
}
```

```cs
public sealed class DiscountService
{
    public Amount Calculate(Amount amount, DiscountType type)
    {
        var discount = Factory.Get<IDiscount>(x => x.IsApplicable(type));

        if (discount is null) { return amount; }

        return discount.Calculate(amount);
    }
}
```

```cs
public interface IDiscount
{
    Amount Calculate(Amount amount);

    bool IsApplicable(DiscountType type);
}
```

```cs
public sealed class SmallDiscount : IDiscount
{
    public Amount Calculate(Amount amount) => new(amount.Value * 0.1M);

    public bool IsApplicable(DiscountType type) => type == DiscountType.Small;
}
```

```cs
public sealed class MediumDiscount : IDiscount
{
    public Amount Calculate(Amount amount) => new(amount.Value * 0.25M);

    public bool IsApplicable(DiscountType type) => type == DiscountType.Medium;
}
```

```cs
public sealed class LargeDiscount : IDiscount
{
    public Amount Calculate(Amount amount) => new(amount.Value * 0.5M);

    public bool IsApplicable(DiscountType type) => type == DiscountType.Large;
}
```

## Value Objects

```cs
public sealed record Amount(decimal Value)
{
    public override string ToString() => Value.ToString();
}
```

```cs
public sealed record Email(string Value)
{
    public bool Invalid => !Valid;

    public bool Valid
    {
        get
        {
            if (string.IsNullOrWhiteSpace(Value)) return false;

            const string regex = @"^([a-z0-9_\.\-]{3,})@([\da-z\.\-]{3,})\.([a-z\.]{2,6})$";

            return new Regex(regex).IsMatch(Value);
        }
    }

    public override string ToString() => Value.ToString();
}
```

```cs
public sealed record FullName(string FirstName, string LastName)
{
    public override string ToString() => $"{ FirstName } { LastName }";
}
```

```cs
public sealed record Quantity(decimal Value)
{
    public override string ToString() => Value.ToString();
}
```
