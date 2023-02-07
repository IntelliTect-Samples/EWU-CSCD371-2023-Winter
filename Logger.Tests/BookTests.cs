using System.Reflection;

namespace Logger.Tests;

[TestClass]
public class BookTests
{
    [TestMethod]
    public void Create_Book_Success()
    {
        FullName authorName = new("J.R.R.", "Tolkien");
        Book book = new(Guid.NewGuid(), title: "Book Title", author: authorName);

        Assert.IsInstanceOfType(book, typeof(BaseEntity));
        Assert.IsNotNull(book);
        Assert.AreEqual("Book Title by J.R.R. Tolkien", book.Name);
    }

    [TestMethod]
    public void Equals_GivenTwoDifferentStudents_ReturnFalse()
    {
        FullName authorName = new("J.R.R.", "Tolkien");
        Book book = new(Guid.NewGuid(), title: "Book Title", author: authorName);
        Book book2 = new(Guid.NewGuid(), title: "Book Title", author: authorName);

        Assert.AreNotEqual(book, book2);
    }

    [TestMethod]
    public void Equals_GivenSameIds_ReturnTrue()
    {
        Guid guid = Guid.NewGuid();
        FullName authorName = new("J.R.R.", "Tolkien");
        Book book = new(guid, title: "Book Title", author: authorName);
        Book book2 = new(guid, title: "Book Title", author: authorName);

        Assert.AreEqual(book, book2);
    }
}
