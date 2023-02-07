using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests;

[TestClass]

public class EmployeeTests
{
    [TestMethod]
    public void Employees_WithSameInfo_AreEqual()
    {
        Student employee1 = new (new Guid(), new FullName("First", "Last", "Middle"));
        Student employee2 = new(new Guid(), new FullName("First", "Last", "Middle"));
    
        Assert.AreEqual(employee1, employee2);    
    }


    [TestMethod]
    public void Employees_WithDifferentGuid_AreNotEqual()
    {
        Student employee1 = new(Guid.Parse("00000000000000000000000000000000"), new FullName("First", "Last", "Middle"));
        Student employee2 = new(Guid.Parse("11111111111111111111111111111111"), new FullName("First", "Last", "Middle"));

        Assert.AreNotEqual(employee1, employee2);
    }


    [TestMethod]
    public void Employees_WithDifferentNames_AreNotEqual()
    {
        Student employee1 = new(Guid.Parse("00000000000000000000000000000000"), new FullName("First", "Last", "Middle"));
        Student employee2 = new(Guid.Parse("00000000000000000000000000000000"), new FullName("Just", "Some", "Words"));

        Assert.AreNotEqual(employee1, employee2);
    }
}
