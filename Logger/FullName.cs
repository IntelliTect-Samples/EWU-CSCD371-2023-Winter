namespace Logger;
//Implemented implicitly
public record struct FullName(string FirstName, string LastName, string? MiddleName = null)
{
public string FirstName { get; } = FirstName ?? throw new ArgumentNullException(nameof(FirstName));
public string LastName { get; } = LastName ?? throw new ArgumentNullException(nameof(LastName));
public string? MiddleName { get; } = MiddleName;

//Check 
public string Name => $"{FirstName} {MiddleName} {LastName}";
}
