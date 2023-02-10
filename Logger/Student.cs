namespace Logger;

public record class Student : BasePerson
{
    public Student(Guid id, FullName name) : base(id, name) { }
}