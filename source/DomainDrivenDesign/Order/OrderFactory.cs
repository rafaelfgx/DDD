namespace DomainDrivenDesign
{
    public static class OrderFactory
    {
        public static Order Create(Customer customer)
        {
            return new Order(customer);
        }
    }
}
