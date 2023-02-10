namespace Logger
{
    //The FullName is a value type that could be modified through copies when called upon
    //while keeping the main copy unchanged.
    //The FullName record will be immutable since the changes will be performed on copies.
    public readonly record struct FullName(string FirstName, string LastName, string? MiddleName = null)

    {
        
        public string FirstName { get; } = FirstName ?? throw new ArgumentNullException(nameof(FirstName));
        public string LastName { get; } = LastName ?? throw new ArgumentNullException(nameof(LastName));
        public string? MiddleName { get; } = MiddleName;


        public string Name => $"{FirstName} {MiddleName} {LastName}";
    }
}