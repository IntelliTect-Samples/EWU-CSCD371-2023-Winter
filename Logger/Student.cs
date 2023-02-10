namespace Logger;
public record class Student(FullName StudentName, double GPA, string? Major = null) : IEntity
{
    public FullName fullName = StudentName ?? throw new ArgumentNullException(nameof(StudentName));
    public string? Major { get; set; } = Major;
    public double GPA { get; set; } = GPA;

    //Implicit, to avoid a backing field and instead use "computed"/"calculated" property, forming the student's
    //"name" from their fullName record
    public string Name
    {
        get { return fullName.toString(); }
    }

    //Explicit, because no regular user would probably care at all about an entity id, or even know what a guid was
    //ergo it can be "hidden" in the interface so only somebody searching for this specific interface functionality
    //would know and have to deal with it
    Guid IEntity.Id { get; init; } = Guid.NewGuid();
}