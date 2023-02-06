namespace Logger;

// All three records the IEntity interface are implemented implicitly to ensure
// we avoid conflicts with members of the same properties

public record Book : IEntity
{
    public Guid Id { get; init; }
    public string BookName { get; init; } = string.Empty;
    public FullName Author { get; init; }
    public string ISBN { get; init; } = string.Empty;
    public string Name => $"{BookName} , Author: {Author.Name}, ISBN: {ISBN}";

}

// Student and Employee are made as derivatives of the Person class
public record Student : Person
{
    public StudentLevels StudentYear { get; init; }
}

public record Employee : Person
{
    public string Employer { get; init; } = string.Empty;
}