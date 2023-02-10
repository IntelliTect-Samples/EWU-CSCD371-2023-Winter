using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;
[TestClass]
public class EmployeeTests
{
    readonly Employee employeeA = new(new FullName("Seraphina", "Basira", "Almalexia"), "Wisewoman", 25.55);
    readonly Employee employeeB = new(new FullName("Seraphina", "Basira", "Almalexia"), "Wisewoman", 25.55);
    readonly Employee employeeC = new(new FullName("Nyssandra", "Emberleaf", "Isha"), "King's Guard", 47.96);
    Employee employeeD = new(new FullName("First Name", "Last Name"), "Cool Job", 101.67);

    [TestMethod]
    public void FullNameEquality_FirstName_TRUEandFALSE()
    {
        Assert.IsTrue(employeeA.fullName.FirstName.Equals(employeeB.fullName.FirstName));
        Assert.IsFalse(employeeA.fullName.FirstName.Equals(employeeC.fullName.FirstName));
    }

    [TestMethod]
    public void FullNameEquality_MiddleName_TRUEandFALSE()
    {
        Assert.IsTrue(employeeA.fullName.MiddleName!.Equals(employeeB.fullName.MiddleName));
        Assert.IsFalse(employeeA.fullName.MiddleName.Equals(employeeC.fullName.MiddleName));
    }

    [TestMethod]
    public void FullNameEquality_LastName_TRUEandFALSE()
    {
        Assert.IsTrue(employeeA.fullName.LastName.Equals(employeeB.fullName.LastName));
        Assert.IsFalse(employeeA.fullName.LastName.Equals(employeeC.fullName.LastName));
    }

    [TestMethod]
    public void NameEquality_TRUEandFALSE()
    {
        Assert.IsTrue(employeeA.Name.Equals(employeeB.Name));
        Assert.IsFalse(employeeA.Name.Equals(employeeC.Name));
    }

    [TestMethod]
    public void PositionEquality_TRUEandFALSE()
    {
        Assert.IsTrue(employeeA.Position.Equals(employeeB.Position));
        Assert.IsFalse(employeeA.Position.Equals(employeeC.Position));
    }

    [TestMethod]
    public void WageEquality_TRUEandFALSE()
    {
        Assert.IsTrue(employeeA.HourlyWage.Equals(employeeB.HourlyWage));
        Assert.IsFalse(employeeA.HourlyWage.Equals(employeeC.HourlyWage));
    }

    [TestMethod]
    public void IdEquality_TRUEandFALSE()
    {
        Assert.IsFalse(((IEntity)employeeA).Id.Equals(((IEntity)employeeB).Id));
        Assert.IsTrue(((IEntity)employeeA).Id.Equals(((IEntity)employeeA).Id));
    }

    [TestMethod]
    public void ObjectEquality_TRUEandFALSE()
    {
        Assert.IsFalse(employeeA.Equals(employeeC));
        Assert.IsFalse(employeeA.Equals(employeeB));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void NullName_ThrowsException()
    {
        employeeD = new(null!, "blah", 0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void NullFirstName_ThrowsException()
    {
        employeeD = new(new FullName(null!, "Epic Last Name"), "blah", 0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void NullLastName_ThrowsException()
    {
        employeeD = new(new FullName("Great First Name", null!), "blah", 0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void InitialNullPosition_ThrowsException()
    {
        employeeD = new(new FullName("Great First Name", "Epic Last Name"), null!, 0);
    }

    [TestMethod]
    public void SetPosition()
    {
        employeeD.Position = "Cooler Job";
        Assert.AreEqual("Cooler Job", employeeD.Position);
        employeeD.Position = null!;
        Assert.AreEqual(null, employeeD.Position);
    }

    [TestMethod]
    public void SetWage()
    {
        employeeD.HourlyWage = 12.2;
        Assert.AreEqual(12.2, employeeD.HourlyWage);
    }
}