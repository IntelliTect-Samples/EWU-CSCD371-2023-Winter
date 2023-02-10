namespace Logger;
//We defined each record implicity to make sure data loss is preveneted and all data can be accessed
public record class Employee : Person
{
    public string Employer { get; init; } = string.Empty;
}