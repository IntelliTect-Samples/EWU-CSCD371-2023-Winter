namespace Logger;
//We defined each record implicity to make sure data loss is preveneted and all data can be accessed
public record class Person : BaseEntity
{
    public FullName FullName { get; init; }
    public override string Name => FullName.Name;
}
