using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void Create_Student_Succets()
    {
        FullName fullName = new("John", "Smith");
        Student student = new(Guid.NewGuid(), name: fullName);

        Assert.IsInstanceOfType(student, typeof(BaseEntity));
        Assert.IsNotNull(student);
        Assert.AreEqual("John Smith", student.Name);
    }

    [TestMethod]
    public void Equals_GivenTwoDifferentStudents_ReturnFalse()
    {
        FullName fullName = new("John", "Smith", "David");
        Student student = new(Guid.NewGuid(), name: fullName);
        Student student2 = new(Guid.NewGuid(), name: fullName);

        Assert.AreNotEqual(student, student2);
    }

    [TestMethod]
    public void Equals_GivenSameIds_ReturnTrue()
    {
        FullName fullName = new("John", "Smith");
        Guid guid = Guid.NewGuid();
        Student student = new(guid, name: fullName);
        Student student2 = new(guid, name: fullName);

        Assert.AreEqual(student, student2);
    }
}
