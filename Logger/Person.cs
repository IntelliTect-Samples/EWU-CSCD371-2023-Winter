namespace Logger;
public record class Person : BaseEntity
{
    public FullName FullName { get; init; }
    public override string Name => FullName.Name;
}