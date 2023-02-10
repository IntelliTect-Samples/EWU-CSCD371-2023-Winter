using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;
[TestClass]
public class StudentTests
{
    readonly Student studentA = new(new FullName("Aslan", "Magnificient", "the"), 3.89, "Magic Tricks");
    readonly Student studentB = new(new FullName("Aslan", "Magnificient", "the"), 3.89, "Magic Tricks");
    readonly Student studentC = new(new FullName("Fenris", "Devourer", "the Ancient"), 4.0, "Destruction");
    Student studentD = new(new FullName("Great First Name", "Epic Last Name"), 5.5, "Popular Major");

    [TestMethod]
    public void FullNameEquality_FirstName_TRUEandFALSE()
    {
        Assert.IsTrue(studentA.fullName.FirstName.Equals(studentB.fullName.FirstName));
        Assert.IsFalse(studentA.fullName.FirstName.Equals(studentC.fullName.FirstName));
    }

    [TestMethod]
    public void FullNameEquality_MiddleName_TRUEandFALSE()
    {
        Assert.IsTrue(studentA.fullName.MiddleName!.Equals(studentB.fullName.MiddleName));
        Assert.IsFalse(studentA.fullName.MiddleName.Equals(studentC.fullName.MiddleName));
    }

    [TestMethod]
    public void FullNameEquality_LastName_TRUEandFALSE()
    {
        Assert.IsTrue(studentA.fullName.LastName.Equals(studentB.fullName.LastName));
        Assert.IsFalse(studentA.fullName.LastName.Equals(studentC.fullName.LastName));
    }

    [TestMethod]
    public void NameEquality_TRUEandFALSE()
    {
        Assert.IsTrue(studentA.Name.Equals(studentB.Name));
        Assert.IsFalse(studentA.Name.Equals(studentC.Name));
    }

    [TestMethod]
    public void MajorEquality_TRUEandFALSE()
    {
        Assert.IsFalse(studentA.Major!.Equals(studentC.Major));
        Assert.IsTrue(studentA.Major.Equals(studentB.Major));
    }

    [TestMethod]
    public void GPAEquality_TRUEandFALSE()
    {
        Assert.IsFalse(studentA.GPA.Equals(studentC.GPA));
        Assert.IsTrue(studentA.GPA.Equals(studentB.GPA));
    }

    [TestMethod]
    public void IdEquality_TRUEandFALSE()
    {
        Assert.IsFalse(((IEntity)studentA).Id.Equals(((IEntity)studentB).Id));
        Assert.IsTrue(((IEntity)studentA).Id.Equals(((IEntity)studentA).Id));
    }

    [TestMethod]
    public void ObjectEquality_TRUEandFALSE()
    {
        Assert.IsFalse(studentA.Equals(studentC));
        Assert.IsFalse(studentA.Equals(studentB));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void NullName_ThrowsException()
    {
        studentD = new(null!, 0, "blah");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void NullFirstName_ThrowsException()
    {
        studentD = new(new FullName(null!, "Epic Last Name"), 0, "blah");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void NullLastName_ThrowsException()
    {
        studentD = new(new FullName("Great First Name", null!), 0, "blah");
    }

    [TestMethod]
    public void SetMajor()
    {
        studentD.Major = "Newer, Better Major";
        Assert.AreEqual("Newer, Better Major", studentD.Major);
    }

    [TestMethod]
    public void SetGPA()
    {
        studentD.GPA = 1.2;
        Assert.AreEqual(1.2, studentD.GPA);
    }
}