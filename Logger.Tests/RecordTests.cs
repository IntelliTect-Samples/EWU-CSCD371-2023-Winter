using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;
[TestClass]
public class RecordTests
{
    readonly Book BookA = new("Fantastic Beasts & Where to Find Them", "Newt Schmander", "Wizarding Press", "978-0-555-88888-0");
    readonly Book BookB = new("Fantastic Beasts & Where to Find Them", "Newt Schmander", "Wizarding Press", "978-0-555-88888-0");
    readonly Book BookC = new("The Lion of the Sun", "Stellia Nocturna", "Night-flyer Publishing Co.", "978-0-111-55555-0");

    readonly Student studentA = new(new FullName("Aslan", "Magnificient", "the"), "Junior", "Magic Tricks", 3.89);
    readonly Student studentB = new(new FullName("Aslan", "Magnificient", "the"), "Junior", "Magic Tricks", 3.89);
    readonly Student studentC = new(new FullName("Fenris", "Devourer", "the Ancient"), "Senior", "Destruction", 4.0);

    readonly Employee employeeA = new(new FullName("Seraphina", "Basira", "Almalexia"), "Wisewoman", 25.55);
    readonly Employee employeeB = new(new FullName("Seraphina", "Basira", "Almalexia"), "Wisewoman", 25.55);
    readonly Employee employeeC = new(new FullName("Nyssandra", "Emberleaf", "Isha"), "King's Guard", 47.96);

    [TestMethod]
    public void BookEqualityTests()
    {
        Assert.IsTrue(BookA.Name.Equals(BookB.Name));
        Assert.IsTrue(BookA.Title.Equals(BookB.Title));
        Assert.IsTrue(BookA.Author.Equals(BookB.Author));
        Assert.IsTrue(BookA.Publisher.Equals(BookB.Publisher));
        Assert.IsTrue(BookA.ISBN.Equals(BookB.ISBN));
        Assert.IsTrue(BookA.Equals(BookB));
        Assert.IsFalse(BookA.Name.Equals(BookC.Name));
        Assert.IsFalse(BookA.Title.Equals(BookC.Title));
        Assert.IsFalse(BookA.Author.Equals(BookC.Author));
        Assert.IsFalse(BookA.Publisher.Equals(BookC.Publisher));
        Assert.IsFalse(BookA.ISBN.Equals(BookC.ISBN));
        Assert.IsFalse(BookA.Equals(BookC));
    }

    [TestMethod]
    public void StudentEqualityTests()
    {
        Assert.IsTrue(studentA.Name.Equals(studentB.Name));
        Assert.IsTrue(studentA.fullName.FirstName.Equals(studentB.fullName.FirstName));
        Assert.IsTrue(studentA.fullName.LastName.Equals(studentB.fullName.LastName));
        Assert.IsTrue(studentA.fullName.MiddleName!.Equals(studentB.fullName.MiddleName));
        Assert.IsTrue(studentA.ClassStanding.Equals(studentB.ClassStanding));
        Assert.IsTrue(studentA.Major.Equals(studentB.Major));
        Assert.IsTrue(studentA.GPA.Equals(studentB.GPA));
        Assert.IsTrue(studentA.Equals(studentB));
        Assert.IsFalse(studentA.Name.Equals(studentC.Name));
        Assert.IsFalse(studentA.fullName.FirstName.Equals(studentC.fullName.FirstName));
        Assert.IsFalse(studentA.fullName.LastName.Equals(studentC.fullName.LastName));
        Assert.IsFalse(studentA.fullName.MiddleName!.Equals(studentC.fullName.MiddleName));
        Assert.IsFalse(studentA.ClassStanding.Equals(studentC.ClassStanding));
        Assert.IsFalse(studentA.Major.Equals(studentC.Major));
        Assert.IsFalse(studentA.GPA.Equals(studentC.GPA));
        Assert.IsFalse(studentA.Equals(studentC));
    }

    [TestMethod]
    public void EmployeeEqualityTests()
    {
        Assert.IsTrue(employeeA.Name.Equals(employeeB.Name));
        Assert.IsTrue(employeeA.fullName.FirstName.Equals(employeeB.fullName.FirstName));
        Assert.IsTrue(employeeA.fullName.LastName.Equals(employeeB.fullName.LastName));
        Assert.IsTrue(employeeA.fullName.MiddleName!.Equals(employeeB.fullName.MiddleName));
        Assert.IsTrue(employeeA.Position.Equals(employeeB.Position));
        Assert.IsTrue(employeeA.HourlyWage.Equals(employeeB.HourlyWage));
        Assert.IsTrue(employeeA.Equals(employeeB));
        Assert.IsFalse(employeeA.Name.Equals(employeeC.Name));
        Assert.IsFalse(employeeA.fullName.FirstName.Equals(employeeC.fullName.FirstName));
        Assert.IsFalse(employeeA.fullName.LastName.Equals(employeeC.fullName.LastName));
        Assert.IsFalse(employeeA.fullName.MiddleName!.Equals(employeeC.fullName.MiddleName));
        Assert.IsFalse(employeeA.Position.Equals(employeeC.Position));
        Assert.IsFalse(employeeA.HourlyWage.Equals(employeeC.HourlyWage));
        Assert.IsFalse(employeeA.Equals(employeeC));
    }

    [TestMethod]
    public void StorageFunctionTests()
    {
        Storage store = new();
        store.Add(BookA);
        Assert.IsTrue(store.Contains(BookA));
        Assert.IsFalse(store.Contains(studentA));
        store.Remove(BookA);
        store.Add(studentA);
        Assert.IsFalse(store.Contains(BookA));
        Assert.IsTrue(store.Contains(studentA));
    }
}