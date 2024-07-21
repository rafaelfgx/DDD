namespace DomainDrivenDesign;

public sealed record FullName(string FirstName, string LastName)
{
    public override string ToString() => $"{ FirstName } { LastName }";
}
