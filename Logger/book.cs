namespace Logger;
//We defined each interface implicity to make sure data loss is preveneted, and we avoid conflicts with elements of the same type.
public record Book : IEntity
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    //public string Name { get; } = Name;
}