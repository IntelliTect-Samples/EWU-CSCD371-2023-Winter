using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JokeServiceTests
    {
        [TestMethod]
        public void CreateJokeService_ReturnsJokeService()
        {
            // Assemble
            JokeService service = new JokeService();

            // Assert
            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void CreateJokeService_SuccessfullyGetJoke()
        {
            // Assemble
            JokeService service = new JokeService();

            // Act
            string joke = service.GetJoke();

            // Assert
            Assert.IsNotNull(joke);
            Assert.AreNotEqual(joke, "");
        }
    }
}
