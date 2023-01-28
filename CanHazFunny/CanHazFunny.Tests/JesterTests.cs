using CanHazFunny;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        private Jester TestingJester;
        [TestInitialize] 
        public void Initialize() 
        {
            TestingJester = new Jester(new MockJokeOutput(), new MockJokeService());
        }

        [TestMethod]
        public void Jester_CreateSuccessfully()
        {   
            //Act

            //Assert
            Assert.IsNotNull(TestingJester);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_NullOutput_ThrowsArgumentNullException()
        {
            // Arrange

            // Act
            TestingJester.Output = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_NullService_ThrowsArgumentNullException()
        {
            // Arrange

            // Act
            TestingJester.Service = null;
        }

        [TestMethod]
        public void Jester_GetJoke_ReturnsJoke()
        {
            //Arrange

            //Act
            string joke = TestingJester.GetJoke();

            //Assert
            Assert.AreNotEqual<string>("", joke);
        }

        [TestMethod]
        public void Jester_TellJoke_Returns()
        {
            //Arrange

            //Act
            TestingJester.TellJoke();

            //Assert
            Assert.IsTrue(((MockJokeOutput)TestingJester.Output).ToldJoke);
        }

        [TestMethod]
        public void Jester_NewJokeDoesNotContainChuckNorris_ReturnsFalse()
        {
            //Arrange

            //Act
            string joke = TestingJester.TellJoke();

            //Assert
            Assert.IsFalse(joke.Contains("Chuck Norris"));
        }
    }
}

class MockJokeService : IJokeService
{
    private int NumRequests;
    public string GetJoke()
    {
        string joke = NumRequests switch
        {
            0 => "Chuck Norris",
            1 => "haha Chuck Norris xD",
            2 => "Something something Chuck Norris",
            3 => "yet another Chuck Norris joke",
            _ => "joke",
        };
        NumRequests++;
        return joke;
    }
}

class MockJokeOutput : IJokeOutput
{
    public bool ToldJoke;
    public void TellJoke(string joke)
    {
        ToldJoke = true;
    }
}