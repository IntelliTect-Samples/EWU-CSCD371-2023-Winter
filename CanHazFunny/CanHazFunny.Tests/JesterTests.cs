using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestInitialize] 
        public void Initialize() 
        {
            
        }

        [TestMethod]
        public void Jester_CreateSuccessfully()
        {   
            //Arrange
            Jester jester = new Jester();

            //Act

            //Assert
            Assert.IsNotNull(jester);
        }

        [TestMethod]
        public void Jester_ReadsJokeFromSource()
        {
            //Arrange
            Jester jester = new Jester();

            //Act
            jester.Joke = "This is a funny joke!";

            //Assert
            Assert.AreEqual("This is a funny joke!", jester.Joke);
        }

        [TestMethod]
        public void Jester_TellsJoke()
        {
            //Arrange
            Jester jester = new Jester();

            //Act
            jester.Joke = "This is a funny joke!";

            //Assert
            Assert.AreEqual("This is a funny joke!", jester.TellJoke());
        }

        [TestMethod]
        public void Jester_IfChuckNorrisJoke_GetNewJoke()
        {
            //Arrange
            Jester jester = new Jester();

            //Act
            jester.Joke = "Super funny Chuck Norris joke.";

            //Assert
            Assert.AreNotEqual("Super funny Chuck Norris joke.", jester.TellJoke());
        }

        [TestMethod]
        public void Jester_NewJokeDoesNotContainChuckNorris_ReturnsFalse()
        {
            //Arrange
            Jester jester = new Jester();

            //Act
            jester.Joke = "Super funny Chuck Norris joke.";

            //Assert
            Assert.IsFalse(jester.TellJoke().Contains("Chuck Norris"));
        }
    }
}
