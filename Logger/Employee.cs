namespace Logger;
public record class Employee(FullName EmployeeName, string Position, double HourlyWage) : IEntity
{
    public FullName fullName = EmployeeName ?? throw new ArgumentNullException(nameof(EmployeeName));
    public string Position { get; set; } = Position ?? throw new ArgumentNullException(nameof(Position));
    public double HourlyWage { get; set; } = HourlyWage;


    //Implicit, to avoid a backing field and instead use "computed"/"calculated" property, forming the employee's
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