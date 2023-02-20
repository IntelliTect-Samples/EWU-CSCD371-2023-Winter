using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculate.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        Calculator calc = new();
        [TestMethod]
        public void TestDictionaryContents()
        {
            Func<int, int, double> addition = Calculator.Add;
            Func<int, int, double> subtraction = Calculator.Subtract;
            Func<int, int, double> multiplication = Calculator.Multiply;
            Func<int, int, double> division = Calculator.Divide;
            Assert.AreEqual<Func<int, int, double>>(addition, calc.MathematicalOperators['+']);
            Assert.AreEqual<Func<int, int, double>>(subtraction, calc.MathematicalOperators['-']);
            Assert.AreEqual<Func<int, int, double>>(multiplication, calc.MathematicalOperators['*']);
            Assert.AreEqual<Func<int, int, double>>(division, calc.MathematicalOperators['/']);
        }

        [TestMethod]
        public void TestAdd()
        {
            double testAddAct = Calculator.Add(1, 2);
            double testAddExp = 3;
            Assert.AreEqual<double>(testAddExp, testAddAct);
        }

        [TestMethod]
        public void TestSubtract()
        {
            double testSubtractAct = Calculator.Subtract(1, 2);
            double testSubtractExp = -1;
            Assert.AreEqual<double>(testSubtractExp, testSubtractAct);
        }

        [TestMethod]
        public void TestMultiply()
        {
            double testMultiplyAct = Calculator.Multiply(3, 5);
            double testMultiplyExp = 15;
            Assert.AreEqual<double>(testMultiplyExp, testMultiplyAct);
        }

        [TestMethod]
        public void TestDivide()
        {
            double testDivideAct = Calculator.Divide(5, 2);
            double testDivideExp = 2.5;
            Assert.AreEqual<double>(testDivideExp, testDivideAct);
        }

        [TestMethod]
        public void TestTryCalculateAddSuccess()
        {
            string testCalcInput = "3 + 5";
            double testCalcOutput;
            double testCalcExp = 8;
            bool testCalcBool = Calculator.TryCalculate(testCalcInput, out testCalcOutput);
            Assert.IsTrue(testCalcBool);
            Assert.AreEqual<double>(testCalcExp, testCalcOutput);
        }

        [TestMethod]
        public void TestTryCalculateSubtractSuccess()
        {
            string testCalcInput = "5 - 2";
            double testCalcOutput;
            double testCalcExp = 3;
            bool testCalcBool = Calculator.TryCalculate(testCalcInput, out testCalcOutput);
            Assert.IsTrue(testCalcBool);
            Assert.AreEqual<double>(testCalcExp, testCalcOutput);
        }

        [TestMethod]
        public void TestTryCalculateMultiplySuccess()
        {
            string testCalcInput = "3 * 5";
            double testCalcOutput;
            double testCalcExp = 15;
            bool testCalcBool = Calculator.TryCalculate(testCalcInput, out testCalcOutput);
            Assert.IsTrue(testCalcBool);
            Assert.AreEqual<double>(testCalcExp, testCalcOutput);
        }

        [TestMethod]
        public void TestTryCalculateDivideSuccess()
        {
            string testCalcInput = "5 / 2";
            double testCalcOutput;
            double testCalcExp = 2.5;
            bool testCalcBool = Calculator.TryCalculate(testCalcInput, out testCalcOutput);
            Assert.IsTrue(testCalcBool);
            Assert.AreEqual<double>(testCalcExp, testCalcOutput);
        }

        [TestMethod]
        public void TestTryCalculateFailNoSpace()
        {
            string testCalcInput = "3+5";
            double testCalcOutput;
            double testCalcExp = 0;
            bool testCalcBool = Calculator.TryCalculate(testCalcInput, out testCalcOutput);
            Assert.IsFalse(testCalcBool);
            Assert.AreEqual<double>(testCalcExp, testCalcOutput);
        }

        [TestMethod]
        public void TestTryCalculateFailBadOp()
        {
            string testCalcInput = "3 > 5";
            double testCalcOutput;
            double testCalcExp = 0;
            bool testCalcBool = Calculator.TryCalculate(testCalcInput, out testCalcOutput);
            Assert.IsFalse(testCalcBool);
            Assert.AreEqual<double>(testCalcExp, testCalcOutput);
        }

        [TestMethod]
        public void TestTryCalculateFailNonInt()
        {
            string testCalcInput = "3.4325 + 5.2";
            double testCalcOutput;
            double testCalcExp = 0;
            bool testCalcBool = Calculator.TryCalculate(testCalcInput, out testCalcOutput);
            Assert.IsFalse(testCalcBool);
            Assert.AreEqual<double>(testCalcExp, testCalcOutput);
        }
    }
}
