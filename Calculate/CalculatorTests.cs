using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculate.Tests
{
    [TestClass]
        public class CalculatorTests
        {
            Calculator calc = new();

            [TestMethod]
            public void TestAdditionCorrect()
                {
                    string testInput = "1 + 2";
                    int testOutput;
                    int testExpect = 3;
                    bool testBool = Calculator.TryCalculate(testInput, out testOutput);
                    Assert.IsTrue(testBool);
                    Assert.AreEqual<int>(testExpect, testOutput);
                }

            [TestMethod]
                public void TestSubtractionCorrect()
                    {
                        string testInput = "3 - 2";
                        int testOutput;
                        int testExpect = 1;
                        bool testBool = Calculator.TryCalculate(testInput, out testOutput);
                        Assert.IsTrue(testBool);
                        Assert.AreEqual<int>(testExpect, testOutput);
                    }

        [TestMethod]
                public void TestMultiplicationCorrect()
                    {
                        string testInput = "1 * 2";
                        int testOutput;
                        int testExpect = 2;
                        bool testBool = Calculator.TryCalculate(testInput, out testOutput);
                        Assert.IsTrue(testBool);
                        Assert.AreEqual<int>(testExpect, testOutput);
                    }

        [TestMethod]
                public void TestDivisionCorrect()
                    {
                        string testInput = "6 / 2";
                        int testOutput;
                        int testExpect = 3;
                        bool testBool = Calculator.TryCalculate(testInput, out testOutput);
                        Assert.IsTrue(testBool);
                        Assert.AreEqual<int>(testExpect, testOutput);
                    }

        [TestMethod]
                public void TestAdditionIncorrect()
                    {
                        string testInput = "1 + 2";
                        int testOutput;
                        int testExpect = 4;
                        bool testBool = Calculator.TryCalculate(testInput, out testOutput);
                        Assert.IsTrue(testBool);
                        Assert.AreNotEqual<int>(testExpect, testOutput);
                    }

        [TestMethod]
                public void TestSubtractionIncorrect()
                    {
                        string testInput = "3 - 2";
                        int testOutput;
                        int testExpect = 5;
                        bool testBool = Calculator.TryCalculate(testInput, out testOutput);
                        Assert.IsTrue(testBool);
                        Assert.AreNotEqual<int>(testExpect, testOutput);
                    }

        [TestMethod]
                public void TestMultiplicationIncorrect()
                    {
                        string testInput = "1 * 2";
                        int testOutput;
                        int testExpect = 1;
                        bool testBool = Calculator.TryCalculate(testInput, out testOutput);
                        Assert.IsTrue(testBool);
                        Assert.AreNotEqual<int>(testExpect, testOutput);
                    }

        [TestMethod]
                public void TestDivisionIncorrect()
                    {
                        string testInput = "6 / 2";
                        int testOutput;
                        int testExpect = 4;
                        bool testBool = Calculator.TryCalculate(testInput, out testOutput);
                        Assert.IsTrue(testBool);
                        Assert.AreNotEqual<int>(testExpect, testOutput);
                    }

        [TestMethod]
            public void TestInvalidInputNoSpace()
                {
                    string testInput = "1+2";
                    int testOutput;
                    int testExpect = 3;
                    bool testBool = Calculator.TryCalculate(testInput, out testOutput);
                    Assert.IsTrue(testBool);
                    Assert.AreNotEqual<int>(testExpect, testOutput);
                }

        [TestMethod]
            public void TestInvalidInputNull()
                {
                    string testInput = "";
                    int testOutput;
                    int testExpect = 0;
                    bool testBool = Calculator.TryCalculate(testInput, out testOutput);
                    Assert.IsTrue(testBool);
                    Assert.AreNotEqual<int>(testExpect, testOutput);
                }
    }
}
