using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests;

[TestClass]

public class BookTests
{
    [TestMethod]
    public void Books_WithSameInfo_AreEqual()
    {
        Book book1 = new(new Guid(), "The Title");
        Book book2 = new(new Guid(), "The Title");

        Assert.AreEqual(book1, book2);
    }


    [TestMethod]
    public void Employees_WithDifferentGuid_AreNotEqual()
    {
        Book book1 = new(Guid.Parse("00000000000000000000000000000000"), "Title");
        Book book2 = new(Guid.Parse("11111111111111111111111111111111"), "Title");

        Assert.AreNotEqual(book1, book2);
    }


    [TestMethod]
    public void Employees_WithDifferentNames_AreNotEqual()
    {
        Book book1 = new(Guid.Parse("00000000000000000000000000000000"), "The First Book");
        Book book2 = new(Guid.Parse("00000000000000000000000000000000"), "The Second Book");

        Assert.AreNotEqual(book1, book2);
    }
}