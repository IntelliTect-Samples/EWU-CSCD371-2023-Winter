using Calculate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class Tests
{
    [TestMethod]
    public void TestDelegatorWriter()
    {
        string testString = "test_string";
        PreparedCalc calc = new();
        calc.DummyWriter.WriteLine(testString);
        Assert.AreEqual<string>(testString, calc.DummyWriter.Line);
    }

    [TestMethod]
    public void TestDelegatorReader()
    {
        string testString = "test_string";
        PreparedCalc calc = new(testString);
        Assert.AreEqual<string>(testString, calc.DummyReader.Readline());
    }

    [TestMethod]
    public void TestAdd()
    {
        PreparedCalc calc = new("1 + 2");
        Assert.IsTrue(calc.Calculate.TryCalculate());
        Assert.AreEqual<string>("3", calc.DummyWriter.Line);
    }

    [TestMethod]
    public void TestSubtract()
    {
        PreparedCalc calc = new("2 - 1");
        Assert.IsTrue(calc.Calculate.TryCalculate());
        Assert.AreEqual<string>("1", calc.DummyWriter.Line);
    }

    [TestMethod]
    public void TestMultiply()
    {
        PreparedCalc calc = new("2 * 3");
        Assert.IsTrue(calc.Calculate.TryCalculate());
        Assert.AreEqual<string>("6", calc.DummyWriter.Line);
    }

    [TestMethod]
    public void TestDivide()
    {
        PreparedCalc calc = new("6 / 2");
        Assert.IsTrue(calc.Calculate.TryCalculate());
        Assert.AreEqual<string>("3", calc.DummyWriter.Line);
    }

    [TestMethod]
    public void FalseOnExtraArgs()
    {
        PreparedCalc calc = new("6 + 4 / 9");
        Assert.IsFalse(calc.Calculate.TryCalculate());
    }

    [TestMethod]
    public void FalseOnNonInt()
    {
        PreparedCalc calc = new("6.9 + 4.2 / 9.8");
        Assert.IsFalse(calc.Calculate.TryCalculate());
    }

    [TestMethod]
    public void FalseOnIllegalOperator()
    {
        PreparedCalc calc = new("6 ^ 8");
        Assert.IsFalse(calc.Calculate.TryCalculate());
    }

    [TestMethod]
    public void FalseOnNoSpacing()
    {
        PreparedCalc calc = new("6+8");
        Assert.IsFalse(calc.Calculate.TryCalculate());
    }

    [TestMethod]
    public void FalseOnBadOrder()
    {
        PreparedCalc calc = new("+ 7 8");
        Assert.IsFalse(calc.Calculate.TryCalculate());
    }
}

public class PreparedCalc
{
    public PreparedCalc(string? readString = null)
    {
        DummyWriter = new DummyWriter();
        DummyReader = new DummyReader(readString);
        Program = new Program(DummyWriter.WriteLine, DummyReader.Readline);
        Calculate = Program.GetCalculator();
    }

    public DummyWriter DummyWriter { get; }
    public DummyReader DummyReader { get; }
    public Program Program { get; }
    public Calculate.Calculate Calculate { get; }
}

public class DummyWriter
{
    public DummyWriter() => Line = "";
    public string Line { get; private set; }

    public void WriteLine(string message) => Line = message;
}

public class DummyReader
{
    public DummyReader(string? message) => Line = message;
    public string? Line { get; }

    public string Readline() => Line!;
}