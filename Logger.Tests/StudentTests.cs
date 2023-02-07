namespace Logger.Tests;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void IsEqual_DifferentID_ReturnsFalse()
    {
        // Arrange
        Student student1 = new(new FullName("Jordan", "Peterson"));
        Student student2 = new(new FullName("Jordan", "Peterson"));

        // Assert
        Assert.IsFalse(student1.Equals(student2));
    }

    [TestMethod]
    public void IsEqual_SameID_ReturnsTrue()
    {
        // Arrange
        Student student1 = new(new FullName("Jordan", "Peterson"));
        Student student2 = new(new FullName("Jordan", "Peterson")) { Id = student1.Id };

        // Assert
        Assert.IsTrue(student1.Equals(student2));
    }

    [TestMethod]
    public void Name_IdenticalNames_AreNotEqual()
    {
        // Arrange
        Student student1 = new(new FullName("Jordan", "Peterson"));
        Student student2 = new(new FullName("Jordan", "Peterson"));

        // Assert
        Assert.IsFalse(student1.Equals(student2));
    }
}
