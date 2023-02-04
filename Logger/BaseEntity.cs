namespace Logger;

public abstract class BaseEntity : IEntity
{
    public Guid ID { get; init; }

    public string Name { get => _Name!; set => _Name = value ?? throw new ArgumentNullException(nameof(Name)); }
    public string? _Name;

    public BaseEntity()
    {
        ID = Guid.NewGuid();
    }
}
