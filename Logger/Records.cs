namespace Logger
{   //All the records are implemented implicitly so it wouldn't conflict with values with the same class

    public record class Book : IEntity
    {
        public Guid Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public FullName Author { get; init; }
        public string ISBN { get; init; } = string.Empty;

        public string Name => $"{Title}, Author: {Author.Name}, ISBN: {ISBN}";

    }


    public record class Student : Person
    {
        public int StudentID;
    }


    public record class Employee : Person
    {
        public string Employer { get; init; } = string.Empty;
    }

}
