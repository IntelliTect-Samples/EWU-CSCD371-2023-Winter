using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logger
{
    /*
    Value or Reference: 
    Reference, because it is possible for multiple people to have the same name
    without being the same person

    Immutability:
    It is immutable because names generally do not change

    */

    public record class FullName(string FirstName, string LastName, string? MiddleName)
    {
        public string FirstName { get; } = FirstName ?? throw new ArgumentNullException(nameof(FirstName));
        public string LastName { get; } = LastName ?? throw new ArgumentNullException(nameof(LastName));
        public string? MiddleName { get; } = MiddleName;

    }
}
