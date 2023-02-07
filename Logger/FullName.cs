namespace Logger;

// FullName is declared as a record struct (value type) because they are simply storing name values, not instances of those names
// The properties of this record are immutable because we don't want the name of something to be able to be changed on demand
public record struct FullName(string FirstName, string LastName, string? MiddleName = null)
{
    public string FirstName { get; } = FirstName??throw new ArgumentNullException(nameof(FirstName));
    public string LastName { get; } = LastName??throw new ArgumentNullException(nameof(LastName));
    public string? MiddleName { get; } = MiddleName;
}
