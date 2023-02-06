namespace Logger;

public record Person : BaseEntity
{
    public FullName FullName { get; init; }

    // Implemented explicitly to avoid conflicts betweeen implementing classes
    public override string Name => FullName.Name;
}
