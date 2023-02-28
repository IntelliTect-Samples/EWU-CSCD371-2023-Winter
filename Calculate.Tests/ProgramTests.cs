namespace Calculate.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void ReadLine_True()
    {
   
        Program program = new ();


        string input = "Fly you fools";
        Console.SetIn(new System.IO.StringReader(input));
        string? result = program.ReadLine?.Invoke();

        Assert.AreEqual(input, result);
    }

    [TestMethod]
    public void WriteLine_True()
    {

        Program program = new ();

        string results = "Fool of a Took";
        TextWriter writer = new System.IO.StringWriter();
        Console.SetOut(writer);
        program.WriteLine.Invoke(results);

        Assert.AreEqual(results + Environment.NewLine, writer.ToString());
    }
}