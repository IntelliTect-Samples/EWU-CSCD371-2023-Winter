using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class RecordsTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Title_AssignNullInInitializer_ThrowException()
    {
        _ = new Book(null, "null");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Author_AssignNullInInitializer_ThrowException()
    {
        _ = new Book("null", null);
    }

    [TestMethod]
    public void Book_Name_EqualsTitle()
    {
        Book book = new("Neuromancer", "William Gibson");
        Assert.AreEqual<string>(book.Title, book.Name);
        Assert.AreEqual<string>("Neuromancer", book.Name);
    }

    [TestMethod]
    public void ID_NonNull() {
        Book book = new("2001: A Space Odyssey", "Arthuer C Clarke");
        Assert.IsNotNull(book.ID);
    }

    [TestMethod]
    public void Student_NameChange_TestEqual()
    {
        Student student = new("Joe McSurname", "EWU")
        {
            Name = "Joe McLastname"
        };
        Assert.AreEqual<string>("Joe McLastname", student.Name);
    }

    [TestMethod]
    public void Employee_NameChange_TestEqual()
    {
        Employee employee = new("Joe McSurname", "EWU")
        {
            Name = "Joe McLastname"
        };
        Assert.AreEqual("Joe McLastname", employee.Name);
    }
}
