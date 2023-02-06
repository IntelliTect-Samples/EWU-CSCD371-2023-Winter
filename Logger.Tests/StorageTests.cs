using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class StorageTests
{
    [TestMethod]
    public void Adding_Entities()
    {
        Storage storage = new Storage();
        Employee entity = new Employee
        {
            Id = Guid.NewGuid(),
            FullName = new FullName("Dieon", "Sanders"),
            Employer = "University of Colorado"
        };

        // Act
        storage.Add(entity);

        // Assert
        Assert.IsTrue(storage.Contains(entity));
    }
}