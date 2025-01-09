namespace DomainDrivenDesign;

public abstract record Entity
{
    public Guid Id { get; } = Guid.NewGuid();
}
