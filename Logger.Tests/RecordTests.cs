using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class RecordTests
{
	[TestMethod]
	public void Create_FullName_Success()
	{
		Record.Person name = new Record.Person("James", "King", "Martin");

		Assert.IsNotNull(name);
	}
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Create_FullName_NotSuccess()
    {
        Record.Person name = new Record.Person(null!, "King", "Martin");

        Assert.IsNull(name);
    }
    [TestMethod]
    public void Create_NewBook_Success()
    {
        Record.Book book = new Record.Book("Cemetery Road", "Greg Iles", 0062824627);

        Assert.IsNotNull(book);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Create_NewBook_NotSuccess()
    {
        Record.Book book = new Record.Book("Cemetery Road", null!, 0062824627);

        Assert.IsNull(book);

    }
    [TestMethod]
    public void Create_Student_Success()
    {
        Record.Student harry = new Record.Student(1234, "Harry", 11);

        Assert.IsNotNull(harry);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Create_Student_NotSuccess()
    {
        Record.Student harry = new Record.Student(1234, null!, 11);

        Assert.IsNull(harry);

    }
    [TestMethod]
    public void Create_Employee_Success()
    {
        Record.Employee jim = new Record.Employee("Jim", "Salesman");

        Assert.IsNotNull(jim);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Create_Employee_NotSuccess()
    {
        Record.Employee jim = new Record.Employee(null!, null!);

        Assert.IsNull(jim);

    }
}

