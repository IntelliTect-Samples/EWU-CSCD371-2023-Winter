using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_WithNullJokeService_ThrowsException()
        {
            //Arrange
            Exception? expectedException = null;

            //Act
            try
            {
                Jester jester = new(null, new JokeOutputter());
            }
            catch (ArgumentNullException e)
            {
                expectedException = e;
                throw e;
            }

            //Assert
            Assert.AreEqual(typeof(ArgumentNullException), expectedException);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_WithNullJokeOutput_ThrowsException()
        {
            //Arrange
            Exception? expectedException = null;

            //Act
            try
            {
                Jester jester = new(new JokeService(), null);
            }
            catch (ArgumentNullException e)
            {
                expectedException = e;
                throw e;
            }

            //Assert
            Assert.AreEqual(typeof(ArgumentNullException), expectedException);
        }


        [TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void TellJoke_DoesNotContainChuckNorris()
        {
            //Arrange
            TestJokeOutputter testJokeOutputter = new();
            Jester jester = new Jester(new JokeService(), testJokeOutputter);

            //Act
            jester.TellJoke();

            //Assert
            Assert.IsFalse(testJokeOutputter.joke.Contains("Chuck Norris"));
        }


        public class TestJokeOutputter : IJokeOutputter
        {
            public string joke = "";
            public TestJokeOutputter() { }

            public void OutputJoke(string joke)
            {
                this.joke = joke;
            }
        }
    }
}
