using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;

[TestClass]
public class BookTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Book_GivenNullTitle_ThrowsExpected()
    {
        _ = new Book(null!, "Jordan Peterson", "ISBN 978-321");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Book_GivenNullAuthor_ThrowsExpected()
    {
        _ = new Book("Beyond Order", null!, "ISBN 978-321");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Book_GivenNullISBN_ThrowsExpected()
    {
        _ = new Book("Beyond Order", "Jordan Peterson", null!);
    }

    [TestMethod]
    public void IsEqual_DifferentInstancesIdenticalISBN_ReturnsTrue()
    {
        // Arrange
        Book book1 = new("Beyond", "Jordan ", "ISBN 978-321");
        Book book2 = new("Beyond Order", "Jordan Peterson", "ISBN 978-321");

        // Act

        // Assert
        Assert.IsTrue(book1.Equals(book2));
    }

    [TestMethod]
    public void IsEqual_DifferentISBN_ReturnsFalse()
    {
        // Arrange
        Book book1 = new("Beyond", "Jordan ", "ISBN 978-32");
        Book book2 = new("Beyond Order", "Jordan Peterson", "ISBN 978-321");

        // Act

        // Assert
        Assert.IsFalse(book1.Equals(book2));
    }

    [TestMethod]
    public void Name_ReturnsExpectedBookName()
    {
        // Arrange
        string title = "Beyond Order";
        string author = "Jordan Peterson";
        string isbn = "ISBN 978-321";

        Book book = new(title, author, isbn);

        // Act
        string expected = $"{title} by {author} ({isbn})";

        // Assert
        Assert.AreEqual(expected, book.Name);
    }
}
