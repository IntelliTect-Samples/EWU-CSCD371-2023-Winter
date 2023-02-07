namespace Logger;

public record class Employee : BaseEntity
{
    public Employee(Guid id, FullName name)
    {
        Id = id;
        EmployeeFullName = name;
    }

    // Name is implemented implicitly because a name is something that obviously applies to a person like Employee.
    public FullName EmployeeFullName { get; }
    public override string Name
    {
        get
        {
            return EmployeeFullName.MiddleName is null
                ? string.Format($"{EmployeeFullName.FirstName} {EmployeeFullName.LastName}")
                : string.Format($"{EmployeeFullName.FirstName} {EmployeeFullName.MiddleName} {EmployeeFullName.LastName}");
        }
    }
}