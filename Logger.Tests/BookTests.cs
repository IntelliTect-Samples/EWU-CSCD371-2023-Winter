using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;
[TestClass]
public class BookTests
{
    readonly Book bookA = new("Fantastic Beasts & Where to Find Them", "Newt Schmander", "Wizarding Press", "978-0-555-88888-0");
    readonly Book bookB = new("Fantastic Beasts & Where to Find Them", "Newt Schmander", "Wizarding Press", "978-0-555-88888-0");
    readonly Book bookC = new("The Lion of the Sun", "Stellia Nocturna", "Night-flyer Publishing Co.", "978-0-111-55555-0");
    Book bookD = new("Cool Title", "Awesome Author", "Great Publishing Company", "I.S.B.N.");

    [TestMethod]
    public void NameEquality_TRUEandFALSE()
    {
        Assert.IsTrue(bookA.Name.Equals(bookB.Name));
        Assert.IsFalse(bookA.Name.Equals(bookC.Name));
    }
    
    [TestMethod]
    public void TitleEquality_TRUEandFALSE()
    {
        Assert.IsFalse(bookA.Title.Equals(bookC.Title));
        Assert.IsTrue(bookA.Title.Equals(bookB.Title));
    }

    [TestMethod]
    public void AuthorEquality_TRUEandFALSE()
    {
        Assert.IsFalse(bookA.Author.Equals(bookC.Author));
        Assert.IsTrue(bookA.Author.Equals(bookB.Author));
    }

    [TestMethod]
    public void PublisherEquality_TRUEandFALSE()
    {
        Assert.IsFalse(bookA.Publisher.Equals(bookC.Publisher));
        Assert.IsTrue(bookA.Publisher.Equals(bookB.Publisher));
    }

    [TestMethod]
    public void ISBNEquality_TRUEandFALSE()
    {
        Assert.IsFalse(bookA.ISBN.Equals(bookC.ISBN));
        Assert.IsTrue(bookA.ISBN.Equals(bookB.ISBN));
    }

    [TestMethod]
    public void IdEquality_TRUEandFALSE()
    {
        Assert.IsFalse(((IEntity)bookA).Id.Equals(((IEntity)bookB).Id));
        Assert.IsTrue(((IEntity)bookA).Id.Equals(((IEntity)bookA).Id));
    }

    [TestMethod]
    public void ObjectEquality_TRUEandFALSE()
    {
        Assert.IsFalse(bookA.Equals(bookC));
        Assert.IsFalse(bookA.Equals(bookB));
        Assert.IsTrue(bookA.Equals(bookA));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void NullTitle_ThrowsException()
    {
        bookD = new(null!, "blah", "blah", "123-456-789-0000");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void NullAuthor_ThrowsException()
    {
        bookD = new("blah", null!, "blah", "123-456-789-0000");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void NullPublisher_ThrowsException()
    {
        bookD = new("blah", "blah", null!, "123-456-789-0000");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void NullISBN_ThrowsException()
    {
        bookD = new("blah", "blah", "blah", null!);
    }
}
