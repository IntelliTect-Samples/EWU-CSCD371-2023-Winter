namespace Assignment
{
    public class Address : IAddress, IComparable, IComparable<Address>
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

        public int CompareTo(Address? other)
        {
            if (other is null)
                return -1;

            if (string.Compare(State, other.State, StringComparison.OrdinalIgnoreCase) != 0)
                return string.Compare(State, other.State, StringComparison.OrdinalIgnoreCase);
            else if (string.Compare(City, other.City, StringComparison.OrdinalIgnoreCase) != 0)
                return string.Compare(City, other.City, StringComparison.OrdinalIgnoreCase);
            else
                return string.Compare(Zip, other.Zip, StringComparison.OrdinalIgnoreCase);
        }

        public int CompareTo(object? obj)
        {
            if (obj is not null && obj is Address)
                return CompareTo((Address)obj);

            throw new ArgumentException("The other comparable needs to be an Address.");
        }
    }
}
