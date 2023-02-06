namespace Logger;

/**
 * The interface is implemented ___Explicitly or Implicitly___, because _________.
 */
public abstract record class Entity : IEntity
{
    public Guid Id { get; init; }
    public abstract string Name { get; set; }

    // Constructor.
    protected Entity(Guid id, string? name = null)
    {
        Id = id;
    }
}

