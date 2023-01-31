using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_JokeOutput_Throws_Null_Exception_For_JokeOutput()
        {
            //Arrange
            IJokeOutput? jokeOutput = null;
            //Act
            new Jester(new JokeService(), jokeOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
          public void Jester_IJokeService_ThrowsNullException_For_Joke_Service()
        {
            //Arrange
            IJokeService? jokeService = null;
            //Act
            Jester jester = new Jester((JokeService?)jokeService, new JokeOutput());
          
        }

        [TestMethod]
        public void TellJoke_TestsValidity()
        {
            //Arrange
            string temp = "Test Joke";
            Mock<IJokeService> mock = new();
            //Act
            mock.Setup(jokeService => jokeService.GetJoke()).Returns("Test Joke");
            //Assert
            Assert.AreEqual<string>(temp, mock.Object.GetJoke());

        }

        [TestMethod]
        public void TellJoke_Checks_For_ChuckNorris()
        {
            //Arrange
            Jester jester = new(new JokeService(), new JokeOutput());
            StringWriter output = new();
            //Act
            Console.SetOut(output);
            jester.TellJoke();
            //Assert
            Assert.IsFalse(output.ToString().ToLower().Contains("chuck norris")| 
                output.ToString().ToLower().Contains("chuck")| 
                output.ToString().ToLower().Contains("norris"));

        }
    }
}