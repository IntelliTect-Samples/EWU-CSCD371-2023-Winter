namespace Logger;

public record class Person(FullName FullName) : BaseEntity
{
    public FullName FullName { get; set; } = FullName;
    // Implemented implicitely because we don't want to hide this member from the users of the class
    public override string Name { get => FullName.ToString(); }
}
