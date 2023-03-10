using System.Linq;
using System.Collections.Generic;
using System;

namespace Assignment
{
    public class Person : IPerson
    {
        public Person(string firstName, string lastName, IAddress address, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            EmailAddress = emailAddress;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAddress Address { get;set; }
        public string EmailAddress { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Person person &&
                   FirstName == person.FirstName &&
                   LastName == person.LastName &&
                   EqualityComparer<IAddress>.Default.Equals(Address, person.Address) &&
                   EmailAddress == person.EmailAddress;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, Address, EmailAddress);
        }

        public static bool operator ==(
       Person a,
       Person b)
        {

            if(a is null || b is null){
                return false; 
            }
            if (a.FirstName == b.FirstName &&
               a.LastName == b.LastName &&
               a.Address.Equals(b.Address) &&
               a.EmailAddress == b.EmailAddress)
            {
                return true; 
            }
            return false; 

        }

        public static bool operator !=(Person a, Person b)
        {

            return !(a == b);
        }


    }
}
