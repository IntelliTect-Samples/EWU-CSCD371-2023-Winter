using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class EntityTests
{
    [TestMethod]
    public void StudentsWithSamePropertiesAreEqual()
    {
        Student student1 = new Student
        {
            Id = Guid.NewGuid(),
            FullName = new FullName("Michael", "Jordan"),
            StudentYear = StudentLevels.Freshman
        };

        Student student2 = new Student
        {
            Id = student1.Id,
            FullName = student1.FullName,
            StudentYear = student1.StudentYear
        };

        Assert.AreEqual(student1, student2);
    }

    [TestMethod]
    public void BooksWithSamePropertiesAreEqual()
    {
        FullName author = new FullName("Mark", "Michaelis");

        Book book1 = new Book
        {
            Id = Guid.NewGuid(),
            BookName = "Essential C#",
            Author = author,
            ISBN = "9780135972267"
        };

        Book book2 = new Book
        {
            Id = book1.Id,
            BookName = book1.BookName,
            Author = book1.Author,
            ISBN = book1.ISBN
        };

        Assert.AreEqual(book1, book2);
        Assert.AreEqual(book1.Name, book2.Name);
    }

    [TestMethod]
    public void EmployeesWithSamePropertiesAreEqual()
    {
        Employee employee1 = new Employee
        {
            Id = Guid.NewGuid(),
            FullName = new FullName("Deion", "Sanders"),
            Employer = "University of Colorado"
        };

        Employee employee2 = new Employee
        {
            Id = employee1.Id,
            FullName = employee1.FullName,
            Employer = employee1.Employer,
        };

        Assert.AreEqual(employee1, employee2);
    }

}
