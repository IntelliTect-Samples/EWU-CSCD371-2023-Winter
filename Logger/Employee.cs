namespace Logger;
public record class Employee : Person
{
    public string Employer { get; init; } = string.Empty;
}