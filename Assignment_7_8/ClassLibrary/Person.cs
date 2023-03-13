using InterfaceLibrary;

namespace ClassLibrary;
public class Person : IPerson
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public IAddress Address { get; set; }
}