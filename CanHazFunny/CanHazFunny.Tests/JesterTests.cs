using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

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

        [TestMethod]
        public void JesterJokes_TestPrint()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            new Jester(new JokePrinter(), new JokeService()).TellJoke();
            StreamWriter reset = new(Console.OpenStandardOutput());
            reset.AutoFlush = true;
            Console.SetOut(reset);

            Assert.IsNotNull(sw);
        }
    }
}
