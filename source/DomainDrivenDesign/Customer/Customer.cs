namespace DomainDrivenDesign;

public sealed record Customer(FullName FullName, Email Email) : Entity
{
    public Email Email { get; private set; } = Email;

    public FullName FullName { get; private set; } = FullName;

    public void ChangeEmail(Email email) => Email = email;

    public void ChangeFullName(FullName fullName) => FullName = fullName;
}
