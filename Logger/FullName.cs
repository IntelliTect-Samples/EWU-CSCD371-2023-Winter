namespace Logger;
public record struct FullName(string FirstName, string LastName, string? MiddleName = null)
{
    public string FirstName { get; set; } = FirstName ?? throw new ArgumentNullException(nameof(FirstName));
    public string LastName { get; set; } = LastName ?? throw new ArgumentNullException(nameof(LastName));
    public string? MiddleName { get; set; } = MiddleName;
}

//All 3 fields are reference types because it would be weird for your name to be a number or boolean (i.e. a value type)
//The only thing that would make sense potentially as a value type might be MiddleName, because you could do "MiddleInitial"
  //instead (i.e. a char) as most forms and such hardly ever require your full middle name

//All 3 fields are immutable because *strings*
  //However, I added a set alongside the get because in my opinion, it is logical for someone to potentially change their name
  //Whether legally because they want to or because of marriage, divorce, etc etc
  //So the type is immutable but the field isn't? Maybe I'm using that term wrong but that's how it seems to me.