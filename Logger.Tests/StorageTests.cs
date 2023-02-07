using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;

[TestClass]
public class StorageTests
{
    [TestMethod]
    public void Adding_Entities_Book()
    {
        //Arrange
        //FullName fullname = new FullName("Micheal", "Meyers");
        Storage storage = new Storage();
        Employee entity = new Employee
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
}