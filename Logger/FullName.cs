namespace Logger;
//Defined as immutable because the name is static and does not change. Creation of new name would be needed
//We defined each as a reference type to make it easier when creating in other classes
public record struct FullName(string FirstName, string LastName, string? MiddleName = null)
{
public string FirstName { get; } = FirstName ?? throw new ArgumentNullException(nameof(FirstName));
public string LastName { get; } = LastName ?? throw new ArgumentNullException(nameof(LastName));
public string? MiddleName { get; } = MiddleName;
public string Name => $"{FirstName} {MiddleName} {LastName}";
}
