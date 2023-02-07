namespace Logger;
public interface IEntity
{
    Guid Id { get; init; }
    string? Name { get; }
}
