namespace Logger;
//We defined each interface implicity to make sure data loss is preveneted, and we avoid conflicts with elements of the same type.
public record Book : IEntity
{
    public Guid Id { get; init; }
    public string BookTitle { get; init; } = string.Empty;
    public string ISBN { get; init; } = string.Empty;
    public string? BookAuthor { get; init; }
    public FullName FullName { get; init; }
    public string FullDescription => $"{BookTitle} , Author: {FullName.Name}, ISBN: {ISBN}";
}

public record Student : Person
{
    public GradeLevel StudentGrade { get; init; }
}

public record Employee : Person
{
    public string Employer { get; init; } = string.Empty;
}