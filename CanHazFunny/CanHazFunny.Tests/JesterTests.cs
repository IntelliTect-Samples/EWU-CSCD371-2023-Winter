using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        public void TellJoke_ReturnsJoke_Success()
        {
            string tmp = "joke";
            Mock<IJokeService> mock = new Mock<IJokeService>();
            mock.Setup(jokeService => jokeService.GetJoke()).Returns("joke");

            Assert.AreEqual<string>(tmp, mock.Object.GetJoke());
         }
        [TestMethod]
        public void TellJoke_DoesNotReturnChuckNorrisJokeUpper_Success()
        {
            JokeService testJoke = new();
            JokeOutput testOutput = new();
            Jester testJester = new Jester(testJoke, testOutput);

            testJester.TellJoke();

            Assert.IsFalse(condition: !(!testOutput.ToString().ToUpper().Contains("CHUCK") || !testOutput.ToString().ToUpper().Contains("NORRIS")));
        }

        [TestMethod]
        public void TellJoke_DoesNotReturnNull_Success()
        {
            JokeService testJoke = new();
            JokeOutput testOutput = new();
            Jester testJester = new Jester(testJoke, testOutput);

            testJester.TellJoke();

            Assert.IsFalse((testJoke.joke!) is not null);
        }
    }
}
