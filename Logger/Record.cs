using System;
using static System.Runtime.InteropServices.OptionalAttribute;
namespace Logger;


/*
 The reason we implemented our FullName record in a class
called records is so we could keep all of our records together.
It makes it easier to navigate and understand our program
from an outside perspective.  
*/
public class Record
{
    /*
    We decided to do a reference type because it is better for storing more
    values. Our record for FullName is mutable because names can be
    occasionally changed. Exp. Changing last name after marriage.  
    */
    public record FullName(string? firstName, string? lastName, string? middleName)
    {
        public string firstName { get; } = firstName ?? throw new ArgumentNullException(nameof(firstName));
        public string lastName { get; } = lastName ?? throw new ArgumentNullException(nameof(lastName));
        public string middleName { get; } = middleName ?? throw new ArgumentNullException(nameof(middleName));

    }
    //implicitly overrding Name in Entity since we are only using Name.
    public record Person(FullName FullName) : Entity
    {
         public override string Name { get => FullName.ToString(); }

         
    }
    //implicitly overrding Name in Entity since we are only using Name.
    public record Book(string? title, string? author, int isbn) : Entity
    {

        public override string Name { get; } = title ?? throw new ArgumentNullException(nameof(title));
        public string author { get; } = author ?? throw new ArgumentNullException(nameof(author));
        public int isbn { get; } = isbn;
    }
    //implicitly overrding Name in Entity since we are only using Name.
    public record Student(int studentId, FullName FullName, int grade) : Entity
    {

        public int studentId { get; } = studentId;
        public override string Name { get => FullName.ToString(); }
        public int grade { get; } = grade;
    }
    //implicitly overrding Name in Entity since we are only using Name.
    public record Employee(FullName FullName, string? profession) : Entity
    {
        public override string Name { get => FullName.ToString(); }
        public string profession { get; } = profession ?? throw new ArgumentNullException(nameof(profession));
    }

}   