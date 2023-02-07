namespace Logger.Tests;

[TestClass]
public class FullNameTests
{
    [TestMethod]
    public void Name_IdenticalNames_AreEqual()
    {
        // Arrange
        FullName name1 = new("Jordan", "Peterson");
        FullName name2 = new("Jordan", "Peterson");

        // Assert
        Assert.IsTrue(name1.Equals(name2));
    }

    [TestMethod]
    public void Name_MiddleNameDefault_IsNull()
    {
        // Arrange
        FullName name1 = new("Jordan", "Peterson");
        FullName name2 = new("Jordan", "Peterson", null);

        // Assert
        Assert.IsTrue(name1.Equals(name2));
    }
}
