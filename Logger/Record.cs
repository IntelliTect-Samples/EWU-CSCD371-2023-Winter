using System;
using Logger;
using static System.Runtime.InteropServices.OptionalAttribute;
namespace Logger;

public class Record
{
    //We decided to do a reference type because it is better for storing more values
    public record Person(string? firstName, string? lastName, string? middleName)
    {
        public string firstName { get; } = firstName ?? throw new ArgumentNullException(nameof(firstName));
        public string lastName { get; } = lastName ?? throw new ArgumentNullException(nameof(lastName));
        public string middleName { get; } = firstName ?? throw new ArgumentNullException(nameof(middleName));

        public string fullName => "${firstName}{lastName}{middleName}";
    }
    //implicitly implements IEntity; more control 
    public record Book(string? title, string? author, int isbn) : IEntity
    {

        public string title { get; } = title ?? throw new ArgumentNullException(nameof(title));
        public string author { get; } = author ?? throw new ArgumentNullException(nameof(author));
        public int isbn { get; } = isbn;

        public Guid Id { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        public string Name => throw new NotImplementedException();

        public string bookName => "${title} {author} {isbn}";
    }
    //implicitly implements IEntity; more control
    public record Student(int studentID, string? name, int grade) : IEntity
    {
        public int studentID { get; } = studentID;
        public string name { get; } = name ?? throw new ArgumentNullException(nameof(name));
        public int grade { get; } = grade;

        public Guid Id { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        public string Name => throw new NotImplementedException();

        public string bookName => "${studentID} {name} {grade}";
    }
    //implicitly implements IEntity; more control
    public record Employee(string? name, string? profession) : IEntity
    {
        public string name { get; } = name ?? throw new ArgumentNullException(nameof(name));
        public string profession { get; } = profession ?? throw new ArgumentNullException(nameof(profession));

        public Guid Id { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        public string Name => throw new NotImplementedException();

        public string employeeName => "${name} {profession}";
    }

}   