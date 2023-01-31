using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void JesterInitialize_TestNullPrintService()
        {
            new Jester(null!, new JokeService());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void JesterInitialize_TestNullJokeService()
        {
            new Jester(new JokePrinter(), null!);
        }

        [TestMethod]
        public void JesterInitialize_TestInputPrintService()
        {
            JokePrinter printz = new JokePrinter();
            JokeService jokez = new JokeService();
            Jester jesty = new(printz, jokez);

            Assert.AreEqual(printz, jesty.PrintService);
        }

        [TestMethod]
        public void JesterInitialize_TestInputJokeService()
        {
            JokePrinter printz = new JokePrinter();
            JokeService jokez = new JokeService();
            Jester jesty = new(printz, jokez);

            Assert.AreEqual(jokez, jesty.JokeService);
        }
    }
}
