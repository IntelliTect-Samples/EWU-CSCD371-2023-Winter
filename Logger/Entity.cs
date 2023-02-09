namespace Logger;
//interface implemented implicitly
public abstract record class Entity : IEntity
{
    public abstract string Name { get; }
    public Guid Id { get; init; } = Guid.NewGuid();
}

