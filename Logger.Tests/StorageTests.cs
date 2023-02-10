using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;
[TestClass]
public class StorageTests
{
    readonly Book bookA = new("Fantastic Beasts & Where to Find Them", "Newt Schmander", "Wizarding Press", "978-0-555-88888-0");
    readonly Student studentA = new(new FullName("Aslan", "Magnificient", "the"), 3.89, "Magic Tricks");

    [TestMethod]
    public void StorageFunctionTests()
    {
        Storage store = new();
        store.Add(bookA);
        Assert.IsTrue(store.Contains(bookA));
        Assert.IsFalse(store.Contains(studentA));
        store.Remove(bookA);
        store.Add(studentA);
        Assert.IsFalse(store.Contains(bookA));
        Assert.IsTrue(store.Contains(studentA));
        //Testing "Get" method keeps giving error, saying "student" class doesn't have an Id
          //attribute even when cast as an IEntity
          //Unsure if this is "bug" or just user error on my part
    }
}