using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;

[TestClass]
public class StorageTests
{
    //Adding unit testing
    [TestMethod]
    public void Adding_Employee()
    {
        //Arrange
        Storage storage = new();
        Employee entity = new()
        {
            Id = Guid.NewGuid(),
            FullName = new FullName("Ted", "Bundy"),
            Employer = "University of Washington"
        };

        // Act
        storage.Add(entity);

        // Assert
        Assert.IsTrue(storage.Contains(entity));
    }
    [TestMethod]
    public void Adding_Student()
    {
        //Arrange
        Storage storage = new();
        Student entity = new()
        {
            Id = Guid.NewGuid(),
            FullName = new FullName("Josh", "Hess"),
            StudentGrade = GradeLevel.Sophomore
        };
        //Act
        storage.Add(entity);
        //Assert
        Assert.IsTrue(storage.Contains(entity));
    }
    [TestMethod]
    public void Adding_Book()
    {
        //Arrange
        Storage storage = new();
        Book book = new()
        {
            Name = "Princess Bride",
            Id = Guid.NewGuid(),
        };
        //Act
        storage.Add(book);
        //Assert
        Assert.IsTrue(storage.Contains(book));
    }

    //Testing the removal of all elements
    [TestMethod]
    public void Removing_Student()
    {
        //Arrange
        //Arrange
        Storage storage = new();
        Student entity = new()
        {
            Id = Guid.NewGuid(),
            FullName = new FullName("Josh", "Hess"),
            StudentGrade = GradeLevel.Senior
        };
        //Act
        storage.Add(entity);
        storage.Remove(entity);
        //Assert
        Assert.IsTrue(!storage.Contains(entity));
    }
    [TestMethod]
    public void Removing_Employee()
    {
        //Arrange
        Storage storage = new();
        Employee entity = new()
        {
            Id = Guid.NewGuid(),
            FullName = new FullName("Ted", "Bundy"),
            Employer = "University of Washington"
        };

        // Act
        storage.Add(entity);
        storage.Remove(entity);

        // Assert
        Assert.IsTrue(!storage.Contains(entity));
    }
    [TestMethod]
    public void Removing_Book()
    {
        //Arrange
        Storage storage = new();
        Book book = new()
        {
            Name = "Princess Bride",
            Id = Guid.NewGuid(),
        };
        //Act
        storage.Add(book);
        storage.Remove(book);
        //Assert
        Assert.IsTrue(!storage.Contains(book));
    }

    //Getting methods testing
}