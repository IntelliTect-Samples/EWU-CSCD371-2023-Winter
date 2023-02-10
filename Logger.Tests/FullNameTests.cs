using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.ExceptionServices;

namespace Logger.Tests;
[TestClass]
public class FullNameTests
{
    [TestMethod]
    public void FullNameInitializes()
    {
        //Arrange
        string first = "first";
        string middle = "middle";
        string last = "last";
        //Act
        FullName f = new FullName(first, last, middle);
        //Assert
        Assert.AreEqual<string>(first, f.FirstName);
        Assert.AreEqual<string>(middle, actual: f.MiddleName);
        Assert.AreEqual<string>(last, f.LastName);
    }
    [TestMethod]
    public void FullName_Null_Check()
    {
        ArgumentNullException Firstname = null!;
        try
        {
            FullName f = new(null!, "m", "l");
        }
        catch (ArgumentNullException ex) { Firstname = ex; }
        Assert.IsNotNull(Firstname);

        ArgumentNullException Middlename = null!;
        try
        {
            FullName f = new("f", null!, "l");
        }
        catch (ArgumentNullException ex) { Middlename = ex; }
        Assert.IsNotNull(Middlename);

        ArgumentNullException Lastname = null!;
        try
        {
            FullName f = new("f", "m", null);
        }
        catch (ArgumentNullException ex) { Lastname = ex; }
        Assert.IsNull(Lastname);
    }
}

