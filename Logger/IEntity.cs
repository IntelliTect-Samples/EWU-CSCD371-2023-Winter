namespace Logger;

public interface IEntity
{
    Guid Id { get; init; }
    public string Name { get; }
}
