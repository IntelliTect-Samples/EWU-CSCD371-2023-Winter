namespace Logger;
//interface implemented implicitly
public abstract class Person : IEntity
{
    public abstract string Name { get; }

    public virtual Guid Id { get; init; } = Guid.NewGuid();
}

