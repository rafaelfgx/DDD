using System.Collections.Generic;
using System.Linq;

namespace DomainDrivenDesign
{
    public sealed class Order : Entity
    {
        public Order(Customer customer)
        {
            Customer = customer;
            Discount = new Amount(0);
            Items = new List<OrderItem>();
        }

        public Customer Customer { get; private set; }

        public Amount Discount { get; private set; }

        public IReadOnlyList<OrderItem> Items { get; private set; }

        public Amount Total => new Amount(Items.Sum(item => item.SubTotal.Value) - Discount.Value);

        public void AddItem(OrderItem item)
        {
            Items = new List<OrderItem>(Items) { item };
        }

        public void ApplyDiscount(Amount discount)
        {
            Discount = discount;
        }
    }
}
