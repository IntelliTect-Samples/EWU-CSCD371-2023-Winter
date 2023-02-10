namespace Logger;
//We defined each record implicity to make sure data loss is preveneted
//And so that elements can be accessed without interference 
public record Book : IEntity
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
}
