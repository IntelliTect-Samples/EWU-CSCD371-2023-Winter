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
        public void Jester_GetJoke_ReturnsNotNull()
        {
            //Arrange
            Jester jester = new Jester();

            //Act
            string joke = jester.GetJoke();

            //Assert
            Assert.IsNotNull(joke);
        }

        [TestMethod]
        public void Jester_TellJoke_Returns()
        {
            //Arrange
            Jester jester = new Jester();

            //Act
            jester.Joke = "This is a funny Joke!";

            //Assert
            Assert.AreEqual("This is a funny Joke!", jester.TellJoke());
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
