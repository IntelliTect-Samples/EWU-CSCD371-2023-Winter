namespace Logger;
//Implemented implicitly to prevent data interference
public record Person : BaseEntity
{
    public FullName FullName { get; init; }
    public override string Name => FullName.Name;
}
