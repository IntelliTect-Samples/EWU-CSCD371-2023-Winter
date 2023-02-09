using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class RecordTests
{
	[TestMethod]
	public void CreateFullNameSuccess()
	{
		Record.FullName name = new Record.FullName("James", "King", "Martin");

		Assert.IsNotNull(name);
	}
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CreateFullNameNotSuccess()
    {
        Record.FullName name = new Record.FullName(null!, "King", "Martin");

        Assert.IsNull(name);
    }
    [TestMethod]
    public void CreateNewBookSuccess()
    {
        Record.Book book = new Record.Book("Cemetery Road", "Greg Iles", 0062824627);

        Assert.IsNotNull(book);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CreateNewBookNotSuccess()
    {
        Record.Book book = new Record.Book("Cemetery Road", null!, 0062824627);

        Assert.IsNull(book);

    }
    [TestMethod]
    public void CreateStudentSuccess()
    {
        Record.FullName name = new Record.FullName("Harry", "Edward", "Styles");
        Record.Student harry = new Record.Student(1234, FullName: name, 11);

        Assert.IsNotNull(harry);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CreateStudentNoMiddleNameSuccess()
    {
        Record.FullName name = new Record.FullName("Harry", null!, "Styles");
        Record.Student harry = new Record.Student(1234, name, 11);

        Assert.IsNotNull(harry);

    }
    [TestMethod]
    public void CreateEmployeeSuccess()
    {
        Record.FullName name = new Record.FullName("Jim", "Duncan", "Halpert");
        Record.Employee jim = new Record.Employee(FullName: name, "Salesman");

        Assert.IsNotNull(jim);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CreateEmployeeNotSuccess()
    {
        Record.Employee jim = new Record.Employee(null!, null!);

        Assert.IsNull(jim);

    }
    [TestMethod]
    public void FullNameNameComparisionByValueTrueSuccess()
    {
        Record.FullName jim = new Record.FullName("Jim", "Duncan", "Halpert");
        Record.FullName jim2 = new Record.FullName("Jim", "Duncan", "Halpert");

        Assert.AreEqual<Record.FullName>(jim, jim2);

    }
    [TestMethod]
    public void FullNameNameComparisionByValueFalseSuccess()
    {
        Record.FullName jim = new Record.FullName("Jim", " ", "Halpert");
        Record.FullName jim2 = new Record.FullName("Jim", "Duncan", "Halpert");

        Assert.AreNotEqual<Record.FullName>(jim, jim2);

    }
}

