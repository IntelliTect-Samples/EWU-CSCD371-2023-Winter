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
        Student student = new("Joe", "", "McSurname", "EWU")
        {
            Name = "Joe McLastname"
        };

        Assert.AreEqual<string>("Joe McLastname", student.Name);
    }

    [TestMethod]
    public void Student_ChangeNameMethod_ChangesNameProperty()
    {
        //Arrange
        Student student = new("Joe", null, "McSurname", "EWU");

        //Act
        student = student.ChangeName("Jack", null!, "McLastName");

        //Assert
        Assert.AreEqual<string>("Jack", student.Name);
    }

    [TestMethod]
    public void Employee_NameChange_TestEqual()
    {
        Employee employee = new("Joe", "E", "McSurname", "EWU");
        Assert.AreEqual<string>("Joe", employee.Name);
    }

    [TestMethod]
    public void Book_ImplicitUseOfID_TestEqual()
    {
        //Arrange
        Book book = new("The Princess Bride", "William Goldman");

        //Act
        Guid bookGuid = book.ID;

        //Assert
        Assert.AreEqual<Guid>(bookGuid, book.ID);
    }

    [TestMethod]
    public void Book_TestValueEqualityForTitle_ReturnsTrue()
    {
        //Arrange
        Book book1 = new("The Princess Bride", "William Goldman");
        Book book2 = new("The Princess Bride", "William Goldman");

        //Act

        //Assert
        Assert.IsTrue(book1.Title == book2.Title);
    }

    [TestMethod]
    public void Book_TestValueEqualityForAuthor_ReturnsTrue()
    {
        //Arrange
        Book book1 = new("The Princess Bride", "William Goldman");
        Book book2 = new("The Princess Bride", "William Goldman");

        //Act

        //Assert
        Assert.IsTrue(book1.Author == book2.Author);
    }

    [TestMethod]
    public void Book_TestValueEqualityForName_ReturnsTrue()
    {
        //Arrange
        Book book1 = new("The Princess Bride", "William Goldman");
        Book book2 = new("The Princess Bride", "William Goldman");

        //Act

        //Assert
        Assert.AreEqual(book1.Name, book2.Name);
        Assert.IsTrue(book1.Name == book2.Name);
    }

    [TestMethod]
    public void Student_TestValueEqualityForName_ReturnTrue()
    {
        //Arrange
        Student student1 = new("John", null, "Doe", "EWU");
        Student student2 = new("John", null, "Doe", "EWU");
        //Act

        //Assert
        Assert.IsTrue(student1.FullName == student2.FullName);
    }

    [TestMethod]
    public void Student_TestValueEqualityForSchool_ReturnTrue()
    {
        //Arrange
        Student student1 = new("John", null, "Doe", "EWU");
        Student student2 = new("John", null, "Doe", "EWU");
        //Act

        //Assert
        Assert.IsTrue(student1.School == student2.School);
    }

    [TestMethod]
    public void Employee_TestValueEqualityForName_ReturnTrue()
    {
        //Arrange
        Employee employee1 = new("Jane", "E", "McLastName", "Intellitect");
        Employee employee2 = new("Jane", "E", "McLastName", "Intellitect");
        //Act

        //Assert
        Assert.IsTrue(employee1.Name == employee2.Name);
    }

    [TestMethod]
    public void Employee_TestValueEqualityForEmployer_ReturnTrue()
    {
        //Arrange
        Employee employee1 = new("Jane", "E", "McLastName", "Intellitect");
        Employee employee2 = new("Jane", "E", "McLastName", "Intellitect");
        //Act

        //Assert
        Assert.IsTrue(employee1.Employer == employee2.Employer);
    }
}
