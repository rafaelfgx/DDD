namespace DomainDrivenDesign
{
    public sealed class Customer : Entity
    {
        public Customer(FullName fullName, Email email)
        {
            FullName = fullName;
            Email = email;
        }

        public Email Email { get; private set; }

        public FullName FullName { get; private set; }

        public void ChangeEmail(Email email)
        {
            Email = email;
        }

        public void ChangeFullName(FullName fullName)
        {
            FullName = fullName;
        }
    }
}
