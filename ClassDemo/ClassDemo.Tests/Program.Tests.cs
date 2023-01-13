using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ClassDemo.Tests;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void GetName_InigoMontoya_InigoMontoya()
    {
        string actual = Program.GetName("Inigo", "Montoya");
        Assert.AreEqual<string>("Inigo Montoya", actual);
    }
    [TestMethod]
    public void PlayingWithIntegers()
    {
        int number = 42;
        Assert.AreEqual("System.Int32", number.GetType().FullName);
    }
    [TestMethod]
    public void PlayingWithStrings()
    {
        string number = "forty-two";
        Assert.AreEqual("System.String", number.GetType().FullName);
    }
}