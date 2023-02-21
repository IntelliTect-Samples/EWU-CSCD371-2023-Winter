using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.Text;
using System.Xml.XPath;

namespace Calculate.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Program_CreateProgram_Success()
        {
            Program program = new();
            StringWriter writer = new();
            StringReader reader = new("Test input");
            System.Console.SetOut(writer);
            System.Console.SetIn(reader);

            program.WriteLine("Test string");

            Assert.AreEqual<string>("Test string", writer.ToString().Trim());
            Assert.AreEqual<string>("Test input", program.ReadLine()!.Trim());
        }

        [TestMethod]
        public void Program_GiveExpression_CalculateResult()
        {
            Program program = new();
            StringWriter writer = new();
            StringReader reader = new("1 + 2");
            System.Console.SetOut(writer);
            System.Console.SetIn(reader);

            string? input = program.ReadLine();
            bool success = program.Calc.TryCalculate(input!, out int result);
            program.WriteLine(result.ToString());

            Assert.IsTrue(success);
            Assert.AreEqual<string>("3", writer.ToString().Trim());
        }

        [TestMethod]
        public void Program_GiveInvalidExpression_CalculateResult()
        {
            Program program = new();
            StringWriter writer = new();
            StringReader reader = new("1 ) 2");
            System.Console.SetOut(writer);
            System.Console.SetIn(reader);

            string? input = program.ReadLine();
            bool success = program.Calc.TryCalculate(input!, out int result);
            program.WriteLine(result.ToString());

            Assert.IsFalse(success);
            Assert.AreEqual<string>("0", writer.ToString().Trim());
        }
    }
}