namespace Logger;

public abstract record class BaseEntity : IEntity
{
    /*
     * We chose to use the implicit version of the method because the source 
     * type is irrelevent for a Name or an ID.
     * 
     * We chose to use the implicit versions of the properties because we want all instances
     * that implement the IEntity interface to be able to use those properties without having
     * to explicitly cast an instance of Book, Student, or Employee to an IEntity every time we want to access 
     * said properties.
     */
    public Guid ID { get; init; } = Guid.NewGuid();
    public abstract string Name { get; init; }
}

public record class Book(string? Title, FullName Author) : BaseEntity
{
    public string Title { get; set; } = Title ?? throw new ArgumentNullException(nameof(Title));
    public FullName Author { get; set; } = Author?? throw new ArgumentNullException(nameof(Author));
    public override string Name { get; init; } = Title?? throw new ArgumentNullException(nameof(Author));
}

/*
 * Person class created to refactor the FullName and Name code in Student and Employee
 */
public record class Person(FullName FullName) : BaseEntity
{ 
    public FullName FullName { get; init; } = FullName ?? throw new ArgumentNullException();
    public override string Name { get; init; } = FullName.FirstName ?? throw new ArgumentNullException(nameof(FullName));
}

public record class Student(FullName FullName, string? School) : Person(FullName)
{
    public string School { get; init; } = School ?? throw new ArgumentNullException(nameof(School));
}

public record class Employee(FullName FullName, string? Employer) : Person(FullName)
{
    public string Employer { get; set; } = Employer ?? throw new ArgumentNullException(nameof(Employer));
}