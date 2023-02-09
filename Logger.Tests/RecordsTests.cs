using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class RecordsTests
{
    FullName? Author;
    FullName? someGuy;
    [TestInitialize]
    public void Init() 
    {
        Author = new("Arthuer", "Clark", "C");
        someGuy = new("John", "Doe", null);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Title_AssignNullInInitializer_ThrowException()
    {
        _ = new Book(null, Author!);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Author_AssignNullInInitializer_ThrowException()
    {
        _ = new Book("null", null!);
    }

    [TestMethod]
    public void Book_Name_EqualsTitle()
    {
        Book book = new("Neuromancer", Author!);
        Assert.AreEqual<string>(book.Title, book.Name);
        Assert.AreEqual<string>("Neuromancer", book.Name);
    }

    [TestMethod]
    public void ID_NonNull() {
        Book book = new("2001: A Space Odyssey", Author!);
        Assert.IsNotNull(book.ID);
    }

    [TestMethod]
    public void Student_NameChange_TestEqual()
    {
        Student student = new(someGuy!, "EWU")
        {
            Name = "Joe McLastname"
        };

        Assert.AreEqual<string>("Joe McLastname", student.Name);
    }

    [TestMethod]
    public void Student_SetsFirstMiddleAndLastName_ReturnsTrue()
    {
        //Arrange
        Student student = new(someGuy!, "Intellitect");

        //Act

        //Assert
        Assert.AreEqual<string>(someGuy!.FirstName, student.FullName.FirstName);
        Assert.AreEqual<string>(someGuy!.MiddleName!, student.FullName.MiddleName!);
        Assert.AreEqual<string>(someGuy!.LastName, student.FullName.LastName);
    }

    [TestMethod]
    public void Employee_SetsFirstMiddleAndLastName_ReturnsTrue()
    {
        //Arrange
        Employee employee = new(someGuy!, "Intellitect");

        //Act

        //Assert
        Assert.AreEqual<string>(someGuy!.FirstName, employee.FullName.FirstName);
        Assert.AreEqual<string>(someGuy!.MiddleName!, employee.FullName.MiddleName!);
        Assert.AreEqual<string>(someGuy!.LastName, employee.FullName.LastName);
    }

    [TestMethod]
    public void Book_ImplicitUseOfID_TestEqual()
    {
        //Arrange
        Book book = new("The Princess Bride", Author!);

        //Act
        Guid bookGuid = book.ID;

        //Assert
        Assert.AreEqual<Guid>(bookGuid, book.ID);
    }

    [TestMethod]
    public void Book_TestValueEqualityForTitle_ReturnsTrue()
    {
        //Arrange
        Book book1 = new("The Princess Bride", Author!);
        Book book2 = new("The Princess Bride", Author!);

        //Act

        //Assert
        Assert.IsTrue(book1.Title == book2.Title);
    }

    [TestMethod]
    public void Book_TestValueEqualityForAuthor_ReturnsTrue()
    {
        //Arrange
        Book book1 = new("The Princess Bride", Author!);
        Book book2 = new("The Princess Bride", Author!);

        //Act

        //Assert
        Assert.IsTrue(book1.Author == book2.Author);
    }

    [TestMethod]
    public void Book_TestValueEqualityForName_ReturnsTrue()
    {
        //Arrange
        Book book1 = new("The Princess Bride", Author!);
        Book book2 = new("The Princess Bride", Author!);

        //Act

        //Assert
        Assert.AreEqual(book1.Name, book2.Name);
        Assert.IsTrue(book1.Name == book2.Name);
    }

    [TestMethod]
    public void Student_TestValueEqualityForName_ReturnTrue()
    {
        //Arrange
        Student student1 = new(someGuy!, "EWU");
        Student student2 = new(someGuy!, "EWU");
        //Act

        //Assert
        Assert.IsTrue(student1.FullName == student2.FullName);
    }

    [TestMethod]
    public void Student_TestValueEqualityForSchool_ReturnTrue()
    {
        //Arrange
        Student student1 = new(someGuy!, "EWU");
        Student student2 = new(someGuy!, "EWU");
        //Act

        //Assert
        Assert.IsTrue(student1.School == student2.School);
    }

    [TestMethod]
    public void Employee_TestValueEqualityForName_ReturnTrue()
    {
        //Arrange
        Employee employee1 = new(someGuy!, "Intellitect");
        Employee employee2 = new(someGuy!, "Intellitect");
        //Act

        //Assert
        Assert.IsTrue(employee1.Name == employee2.Name);
    }

    [TestMethod]
    public void Employee_TestValueEqualityForEmployer_ReturnTrue()
    {
        //Arrange
        Employee employee1 = new(someGuy!, "Intellitect");
        Employee employee2 = new(someGuy!, "Intellitect");
        //Act

        //Assert
        Assert.IsTrue(employee1.Employer == employee2.Employer);
    }
}
