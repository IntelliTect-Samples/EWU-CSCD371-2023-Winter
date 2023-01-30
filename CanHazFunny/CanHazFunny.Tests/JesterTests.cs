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
            string tmp = "Joke";
            Mock<IJokeService> mock = new Mock<IJokeService>();
            mock.Setup(jokeService => jokeService.GetJoke()).Returns("joke");

            Assert.AreEqual<string>(tmp, mock.Object.GetJoke());
         }
        [TestMethod]
        public void TellJoke_DoesNotReturnChuckNorrisJoke_Success()
        {
            JokeService testJoke = new();
            JokeWriter testWriter = new();
            Jester testJester = new Jester(testJoke, testWriter);

            testJester.TellJoke();

            Assert.IsFalse((testJoke.Joke!).Contains("Chuck Norris"));
        }
    }
}
