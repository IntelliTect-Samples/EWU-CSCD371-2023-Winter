namespace Logger.Tests;

[TestClass]
public class EmployeeTests
{
    [TestMethod]
    public void IsEqual_DifferentID_ReturnsFalse()
    {
        // Arrange
        Student employee1 = new(new FullName("Jordan", "Peterson"));
        Student employee2 = new(new FullName("Jordan", "Peterson"));

        // Assert
        Assert.IsFalse(employee1.Equals(employee2));
    }

    [TestMethod]
    public void IsEqual_SameID_ReturnsTrue()
    {
        // Arrange
        Student employee1 = new(new FullName("Jordan", "Peterson"));
        Student employee2 = new(new FullName("Jordan", "Peterson")) { Id = employee1.Id };

        // Assert
        Assert.IsTrue(employee1.Equals(employee2));
    }

    [TestMethod]
    public void Name_IdenticalNames_AreNotEqual()
    {
        // Arrange
        Employee employee1 = new(new FullName("Jordan", "Peterson"));
        Employee employee2 = new(new FullName("Jordan", "Peterson"));

        // Assert
        Assert.IsFalse(employee1.Equals(employee2));
    }
}
