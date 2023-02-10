namespace Logger;

public record class Employee : BasePerson
{
    public Employee(Guid id, FullName name) : base(id, name) { }
}