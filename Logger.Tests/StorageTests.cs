using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Logger.Record;

namespace Logger.Tests;

[TestClass]
public class StorageTests
{
	[TestMethod]
	public void TestAddSuccess()
	{
		Record.Book book = new Record.Book("Cemetery Road", "Greg Iles", 0062824627);

		Storage storage = new Storage();

		storage.Add(book);

		Assert.IsTrue(storage.Contains(book));
	}
    [TestMethod]
    public void TestRemoveSuccess()
    {
        Record.Book book = new Record.Book("Cemetery Road", "Greg Iles", 0062824627);

        Storage storage = new Storage();

        storage.Add(book);
        storage.Remove(book);
        
        Assert.IsFalse(storage.Contains(book));
    }
    [TestMethod]
    public void TestGetSuccess()
    {
        Record.Book book = new Record.Book("Cemetery Road", "Greg Iles", 0062824627);

        Storage storage = new Storage();

        Guid bookId = book.Id;

        storage.Add(book);
        Book stored = storage.Get(bookId) as Book ?? throw new ArgumentNullException();

        Assert.AreEqual<Book>(stored, book);
    }

}


