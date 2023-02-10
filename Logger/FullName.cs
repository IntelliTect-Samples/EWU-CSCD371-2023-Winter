namespace Logger;
public record class FullName(string FirstName, string LastName, string? MiddleName = null)
{
    public string FirstName { get; } = FirstName ?? throw new ArgumentNullException(nameof(FirstName));
    public string LastName { get; } = LastName ?? throw new ArgumentNullException(nameof(LastName));
    public string? MiddleName { get; } = MiddleName;
    
    public string toString()
    {
        if (MiddleName is not null)
        {
            return $"{FirstName} {MiddleName} {LastName}";
        } else
        {
            return $"{FirstName} {LastName}";
        }
    }

}

//All 3 fields are reference types because it would be weird for your name to be a number or boolean (i.e. a value type)
//The only thing that would make sense potentially as a value type might be MiddleName, because you could do "MiddleInitial"
  //instead (i.e. a char) as most forms and such hardly ever require your full middle name

//Immutable because while I don't like having it immutable (people can and will change names),
  //idk how to make it null check within the setter as well as in the initial assignment