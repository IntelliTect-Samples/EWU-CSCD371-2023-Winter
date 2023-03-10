using System;

namespace Assignment
{
    public class Address : IAddress
    {
        public Address(string streetAddress, string city, string state, string zip)
        {
            StreetAddress = streetAddress;
            City = city;
            State = state;
            Zip = zip;
        }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Address address &&
                   StreetAddress == address.StreetAddress &&
                   City == address.City &&
                   State == address.State &&
                   Zip == address.Zip;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StreetAddress, City, State, Zip);
        }

        public static bool operator ==(Address left, Address right) {
            if (left is null || right is null) {
                return false; 
            }
            if (left.StreetAddress == right.StreetAddress && 
                left.State == right.State &&
                left.Zip == right.Zip &&
                left.City == right.City)
            {
                return true; 

            }
            return false; 
        }

        public static bool operator !=(Address left, Address right)
        {
            return !(left == right);
        }
    }
}
