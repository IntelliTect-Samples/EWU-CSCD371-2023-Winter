using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests;

[TestClass]
public class PersonTests
{
    static readonly string testCsvRow = "1337, Tom, Rohr, trohr@ewu.edu, 4127 S. Sullivan Rd, Veradale, WA, 99037";

    [TestMethod]
    public void Person_SetProperties_Success()
    {
        // Arrange
        string[] attributes = testCsvRow.Split(',');
        Address address = new(attributes[4].Trim(), attributes[5].Trim(), attributes[6].Trim(), attributes[7].Trim());

        // Act
        Person testPerson = new(attributes[1].Trim(), attributes[2].Trim(), address, attributes[3].Trim());

        // Assert
        Assert.AreEqual<string>("Tom", testPerson.FirstName);
        Assert.AreEqual<string>("Rohr", testPerson.LastName);
        Assert.AreEqual<string>("trohr@ewu.edu", testPerson.EmailAddress);
        Assert.AreEqual<string>("4127 S. Sullivan Rd, Veradale WA, 99037", testPerson.Address.ToString()!);
    }
}
