using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
        public void TellJoke_PrintsJoke()
        {
            //Suggestion from peer PR review
            Mock<IJokeService> MockJokeService = new();
            Mock<IPrintJoke> MockJokePrinter = new();
            Jester jester = new(MockJokePrinter.Object, MockJokeService.Object);
            MockJokeService.Setup(x => x.GetJoke()).Returns("incredible joke here");
            jester.TellJoke();
            MockJokePrinter.Verify(x => x.PrintJoke("incredible joke here"), Times.Once);
        }

        //How are we supposed to test the Chuck Norris filter??? Help...
    }
}
