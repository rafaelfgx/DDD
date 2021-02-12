namespace DomainDrivenDesign
{
    public static class CustomerFactory
    {
        public static Customer Create
        (
            string firstName,
            string lastName,
            string email
        )
        {
            return new Customer
            (
                new FullName(firstName, lastName),
                new Email(email)
            );
        }
    }
}
