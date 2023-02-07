namespace Logger;

public record class Student : BaseEntity
{
    public Student(Guid id, FullName name)
    {
        Id = id;
        PersonFullName = name;
    }

    // Name is implemented implicitly because a name is something that obviously applies to a person like Student.
    public FullName PersonFullName { get; }
    public override string Name
    {
        get
        {
            return PersonFullName.MiddleName is null
                ? string.Format($"{PersonFullName.FirstName} {PersonFullName.LastName}")
                : string.Format($"{PersonFullName.FirstName} {PersonFullName.MiddleName} {PersonFullName.LastName}");
        }
    }
}