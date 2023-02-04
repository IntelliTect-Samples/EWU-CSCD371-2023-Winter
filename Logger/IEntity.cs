namespace Logger;

public interface IEntity
{
    Guid ID { get; init; }
    string Name { get; set; }
}
