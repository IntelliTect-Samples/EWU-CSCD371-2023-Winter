namespace Logger;

public abstract record class BaseRecord(string? Name) : IEntity
{
    /*
     * We chose to use the implicit version of the method because the source 
     * type is irrelevent for a Name or an ID.
     * 
     * We chose to use the implicit versions of the properties because we want all instances
     * that implement the IEntity interface to be able to use those properties.
     */
    public Guid ID { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = Name ?? throw new ArgumentNullException(nameof(Name));
}

public record class Book(string? Title, string? Author) : BaseRecord(Title)
{
    public string Title { get; set; } = Title ?? throw new ArgumentNullException(nameof(Title));
    public string Author { get; set; } = Author?? throw new ArgumentNullException(nameof(Author));
    
}

public record class Student(string? Name, string? School) : BaseRecord(Name)
{
    public string School { get; set; } = School ?? throw new ArgumentNullException(nameof(School));
}

public record class Employee(string? Name, string? Employer) : BaseRecord(Name)
{
    public string Employer { get; set; } = Employer ?? throw new ArgumentNullException(nameof(Employer));
}