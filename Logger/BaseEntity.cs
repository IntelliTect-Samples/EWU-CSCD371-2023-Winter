namespace Logger;

public abstract record class BaseEntity : IEntity
{
    public Guid Id { get; init; }
    public abstract string Name { get; }
}