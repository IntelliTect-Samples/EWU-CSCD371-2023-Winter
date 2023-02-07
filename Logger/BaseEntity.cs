namespace Logger;
implemented implicitly to prevent data loss/interference
public abstract record class BaseEntity : IEntity
{
    public Guid Id { get; init; }
    public abstract string Name { get; }
}
