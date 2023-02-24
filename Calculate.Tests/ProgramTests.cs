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
        public void Program_ReadLine_ReturnsValue()
        {
            Program program = new()
            {
                ReadLine = () => "Test string"
            };

            Assert.AreEqual<string>("Test string", program.ReadLine()!);
        }

        [TestMethod]
        public void Program_WriteLine_WritesValues()
        {
            string actual = "";
            Program program = new()
            {
                WriteLine = (text) => actual = text
            };

            program.WriteLine("Test string");

            Assert.AreEqual<string>("Test string", actual);
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
            bool success = program.Calc.TryCalculate(input!, out double result);
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
            bool success = program.Calc.TryCalculate(input!, out double result);
            program.WriteLine(result.ToString());

            Assert.IsFalse(success);
            Assert.AreEqual<string>("0", writer.ToString().Trim());
        }
    }
}