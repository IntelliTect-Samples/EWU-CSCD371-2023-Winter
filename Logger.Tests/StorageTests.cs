using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;

[TestClass]
public class StorageTests
{
    [TestMethod]
    public void Add_GivenStudent_Success()
    {
        FullName fullName = new("John", "Smith");
        Student student = new(Guid.NewGuid(), name: fullName);
        Storage storage = new();
        storage.Add(student);

        Assert.IsTrue(storage.Contains(student));
    }

    [TestMethod]
    public void Add_GivenEmployee_Success()
    {
        FullName fullName = new("Ash", "Ketchum");
        Employee employee = new(Guid.NewGuid(), name: fullName);
        Storage storage = new();
        storage.Add(employee);

        Assert.IsTrue(storage.Contains(employee));
    }

    [TestMethod]
    public void Add_GivenBook_Success()
    {
        FullName authorName = new("J.R.R.", "Tolkien");
        Book book = new(Guid.NewGuid(), title: "Book Title", author: authorName);
        Storage storage = new();
        storage.Add(book);

        Assert.IsTrue(storage.Contains(book));
    }

    [TestMethod]
    public void Remove_GivenStudent_Success()
    {
        FullName fullName = new("John", "Smith");
        Student student = new(Guid.NewGuid(), name: fullName);
        Storage storage = new();
        storage.Add(student);
        storage.Remove(student);

        Assert.IsFalse(storage.Contains(student));
    }

    [TestMethod]
    public void Remove_GivenEmployee_Success()
    {
        FullName fullName = new("Ash", "Ketchum");
        Employee employee = new(Guid.NewGuid(), name: fullName);
        Storage storage = new();
        storage.Add(employee);
        storage.Remove(employee);

        Assert.IsFalse(storage.Contains(employee));
    }

    [TestMethod]
    public void Remove_GivenBook_Success()
    {
        FullName authorName = new("J.R.R.", "Tolkien");
        Book book = new(Guid.NewGuid(), title: "Book Title", author: authorName);
        Storage storage = new();
        storage.Add(book);
        storage.Remove(book);

        Assert.IsFalse(storage.Contains(book));
    }

    [TestMethod]
    public void Get_GivenStudent_ReturnsStudent()
    {
        FullName fullName = new("John", "Smith");
        Student student = new(Guid.NewGuid(), name: fullName);
        Storage storage = new();
        storage.Add(student);
        IEntity? retrievedStudent = storage.Get(student.Id);

        Assert.AreEqual(student, retrievedStudent);
    }

    [TestMethod]
    public void Get_GivenEmployee_ReturnsEmployee()
    {
        FullName fullName = new("Ash", "Ketchum");
        Employee employee = new(Guid.NewGuid(), name: fullName);
        Storage storage = new();
        storage.Add(employee);
        IEntity? retrievedEmployee = storage.Get(employee.Id);

        Assert.AreEqual(employee, retrievedEmployee);
    }

    [TestMethod]
    public void Get_GivenBook_ReturnsBook()
    {
        FullName authorName = new("J.R.R.", "Tolkien");
        Book book = new(Guid.NewGuid(), title: "Book Title", author: authorName);
        Storage storage = new();
        storage.Add(book);
        IEntity? retrievedBook = storage.Get(book.Id);

        Assert.AreEqual(book, retrievedBook);
    }
}
