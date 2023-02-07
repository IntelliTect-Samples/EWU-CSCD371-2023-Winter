using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests;

[TestClass]

public class StorageTests
{
    protected Storage storage = new();
    [TestInitialize]
    public void CreateMockStorage()
    {
        Storage storage = new();
    }


    [TestMethod]
    public void Storage_Add_AddsEntityToHashset()
    {
        Student employee = new(new Guid(), new FullName("one", "three", "two"));
        storage.Add(employee);

        Assert.IsTrue(storage.Contains(employee));
    }


    [TestMethod]
    public void Storage_Remove_RemovesEntityFromHashset()
    {
        Book book = new(new Guid(), "the book");
        storage.Add(book);

        storage.Remove(book);

        Assert.IsFalse(storage.Contains(book));
    }


    [TestMethod]
    public void Storage_GetWithExistentGuid_ReturnsIEntity()
    {
        Student student = new(new Guid(), new FullName("First", "Last", "Middle"));
        storage.Add(student);

        IEntity fromStorage = storage.Get(new Guid())!;

        Assert.AreEqual(student, fromStorage);
    }
}
    
