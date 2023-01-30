using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        public void Jester_Has_JokeService()
        {
            //Arrange
            IJokeService jokeService = new JokeService();
            IJokeOutput jokeOut = new JokeOutput();
            //Act
            Jester jester = new(jokeService, jokeOut);
            //Assert
            Assert.AreEqual<IJokeService>(jester.JokeService, jokeService);
        }
    }
}
