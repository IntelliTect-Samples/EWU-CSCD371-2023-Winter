namespace Logger.Tests;

[TestClass]
public class EmployeeTests
{
    [TestMethod]
    public void Employee_Create_Success()
    {
        FullName fullName = new("Ash", "Ketchum");
        Employee employee = new(Guid.NewGuid(), name: fullName);

        Assert.IsInstanceOfType(employee, typeof(BaseEntity));
        Assert.IsNotNull(employee);
        Assert.AreEqual("Ash Ketchum", employee.Name);
    }

    [TestMethod]
    public void Equals_GivenTwoDifferentStudents_ReturnFalse()
    {
        FullName fullName = new("John", "Smith", "David");
        Employee emp = new(Guid.NewGuid(), name: fullName);
        Employee emp2 = new(Guid.NewGuid(), name: fullName);

        Assert.AreNotEqual(emp, emp2);
    }

    [TestMethod]
    public void Equals_GivenSameIds_ReturnTrue()
    {
        FullName fullName = new("John", "Smith");
        Guid guid = Guid.NewGuid();
        Employee emp = new(guid, name: fullName);
        Employee emp2 = new(guid, name: fullName);

        Assert.AreEqual(emp, emp2);
    }
}
