namespace Assignment;

public class Address : IAddress
{
    public Address(string streetAddress, string city, string state, string zip)
    {
        StreetAddress = streetAddress;
        City = city;
        State = state;
        Zip = zip;
    }

    public override string ToString()
    {
        return $"{StreetAddress}, {City} {State}, {Zip}";
    }

    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
}
