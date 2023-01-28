using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        public void CreateJester_ReturnsJester()
        {
            // Assemble
            JokeService service = new JokeService();
            Jester jester = new Jester(service);

            // Assert
            Assert.IsNotNull(jester);
        }

        [TestMethod]
        public void CreateJester_SuccessfullyGetJoke()
        {
            // Assemble
            Jester jester = new Jester(new JokeService());

            // Act
            string joke = jester.Service.GetJoke();

            // Assert
            Assert.IsNotNull(joke);
            Assert.AreNotEqual(joke, "");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void Create_GivenNullService_ThrowsException()
        {
            // Assemble - Act
            Jester jester = new Jester(null);
        }

        [TestMethod]
        public void GivenJokeWithChuckNorris_ReturnsFalse()
        {
            // Asseble
            MockJokeService mockService = new MockJokeService();

            // Act
            string joke = mockService.GetJoke();
            bool result = Jester.JokeFilter(joke);

            // Assert
            Assert.IsFalse(result);
        }


        public class MockJokeService : JokeService
        {
            public override string GetJoke()
            {
                return "This joke contains ChuCk NORriS";
            }
        }
    }
}
