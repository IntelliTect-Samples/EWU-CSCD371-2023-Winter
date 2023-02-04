using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class BaseEntityTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void NullName_Throws_ArgumentNullException()
    {
        _ = new MockBaseEntity(null);
    }

    [TestMethod]
    public void Name_TestEquals()
    {
        MockBaseEntity entity = new("name");
        Assert.AreEqual("name", entity.Name);
        entity.Name = "new name";
        Assert.AreEqual("new name", entity.Name);
    }
}

internal class MockBaseEntity : BaseEntity
{
    public MockBaseEntity(string? name) {
        Name = name!;
    }
}