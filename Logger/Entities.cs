namespace Logger;
//interface implemented implicitly
public abstract class Entities : IEntity
{
    public abstract string Name { get; }
    public Guid Id { get; init; }
}

