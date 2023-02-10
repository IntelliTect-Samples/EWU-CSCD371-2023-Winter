using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;
[TestClass]
public class EntityTests
{
    [TestMethod]
    public void Book_Imp_Entity()
    {
        //Arrange
        string test = "test";
        Book book = new()
        {
            Name = test,
            Id = Guid.NewGuid(),
        };
        //Assert
        Assert.AreEqual(test, book.Name);
    }
    [TestMethod]
    public void Emp_Imp_Entity()
    {
        //Arrange
        FullName f = new FullName("Steve", "Jobs");
        Employee employee = new()
        {
            Id = Guid.NewGuid(),
            FullName = new FullName("Steve", "Jobs"),
            Employer = "Employer",
        };
        //Assert
        Assert.AreEqual(f, employee.FullName);
    }
    [TestMethod]
    public void Stu_Imp_Entity()
    {
        //Arrange
        FullName f = new FullName("Stu", "Steiner");
        Student stu = new()
        {
            Id = Guid.NewGuid(),
            FullName = new FullName("Stu", "Steiner"),
            StudentGrade = GradeLevel.Sophomore
        };

        //Assert
        Assert.AreEqual(f, stu.FullName);
    }
}
