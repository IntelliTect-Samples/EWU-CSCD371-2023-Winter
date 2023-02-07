using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests;

[TestClass]

public class StudentTests
{
    [TestMethod]
    public void Students_WithSameInfo_AreEqual()
    {
        Student student1 = new(new Guid(), new FullName("First", "Last", "Middle"));
        Student student2 = new(new Guid(), new FullName("First", "Last", "Middle"));

        Assert.AreEqual(student1, student2);
    }


    [TestMethod]
    public void Students_WithDifferentGuid_AreNotEqual()
    {
        Student student1 = new(Guid.Parse("00000000000000000000000000000000"), new FullName("First", "Last", "Middle"));
        Student student2 = new(Guid.Parse("11111111111111111111111111111111"), new FullName("First", "Last", "Middle"));

        Assert.AreNotEqual(student1, student2);
    }


    [TestMethod]
    public void Students_WithDifferentNames_AreNotEqual()
    {
        Student student1 = new(Guid.Parse("00000000000000000000000000000000"), new FullName("First", "Last", "Middle"));
        Student student2 = new(Guid.Parse("00000000000000000000000000000000"), new FullName("Just", "Some", "Words"));

        Assert.AreNotEqual(student1, student2);
    }
}

