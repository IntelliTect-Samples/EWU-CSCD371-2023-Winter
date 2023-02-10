namespace Logger;
public abstract record class BaseEntity : IEntity
{
    string IEntity.Name { get; } = "";
    public Guid Id { get; init; }
}