using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class StorageTests
{
	[TestMethod]
	public void Test_Add_Success()
	{
		Record.Book book = new Record.Book("Cemetery Road", "Greg Iles", 0062824627);

		Storage storage = new Storage();

		storage.Add(book);

		Assert.IsTrue(storage.Contains(book));
	}
    [TestMethod]
    public void Test_Remove_Success()
    {
        Record.Book book = new Record.Book("Cemetery Road", "Greg Iles", 0062824627);

        Storage storage = new Storage();

        storage.Add(book);
        storage.Remove(book);
        
        Assert.IsFalse(storage.Contains(book));
    }

}


