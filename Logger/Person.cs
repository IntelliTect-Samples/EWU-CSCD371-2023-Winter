namespace Logger;
public record Person : BaseEntity
{
    public FullName FullName { get; init; }
    public override string Name => FullName.Name;
}