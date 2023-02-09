using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class BaseEntityTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void NullName_Throws_ArgumentNullException()
    {
        _ = new MockBaseEntity(null!);
    }

    [TestMethod]
    public void Name_TestEquals()
    {
        MockBaseEntity entity1 = new("name");
        Assert.AreEqual("name", entity1.Name);
        MockBaseEntity entity2 = entity1 with { Name = "new name" };
        Assert.AreEqual("new name", entity2.Name);
    }
}

internal record class MockBaseEntity(string Name) : BaseEntity
{
    public override string Name { get; init; } = Name ?? throw new ArgumentNullException(nameof(Name));
}