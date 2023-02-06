namespace Logger;
public abstract record class BaseEntity : IEntity
{
    string? IEntity.Name { get; set; }
    public Guid Id { get; init; }
}