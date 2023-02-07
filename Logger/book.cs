namespace Logger;
//We defined each record implicity to make sure data loss is preveneted
//And so that elements can be accessed without interference 
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
