namespace Logger;

public interface IEntity
{
	public Guid Id { get; init; }
    public string Name { get; }
}

