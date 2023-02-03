using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        protected Mock<IJokeOutputter> MockJokeOutputter { get; set; } = new Mock<IJokeOutputter>();
        protected Mock<IJokeService> MockJokeService { get; set; } = new Mock<IJokeService>();

        [TestInitialize]
        public void CreateMocks()
        {
            MockJokeOutputter = new();
            MockJokeService = new();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_WithNullJokeService_ThrowsException()
        {
            new Jester(null, MockJokeOutputter.Object);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_WithNullJokeOutputter_ThrowsException()
        {
            //Arrange
            Exception? expectedException = null;

            //Act
            try
            {
                Jester jester = new(MockJokeService.Object, null);
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
        public void TellJoke_DoesNotContainChuckNorris()
        {
            // Arrange
            Jester jester = new(MockJokeService.Object, MockJokeOutputter.Object);
            MockJokeService.SetupSequence(x => x.GetJoke())
                .Returns("Chuck Norris is the only person to ever win a staring contest against Ray Charles and Stevie Wonder.")
                .Returns("What does a subatomic duck say? Quark.");

            // Act
            jester.TellJoke();

            // Assert
            MockJokeOutputter.Verify(x => x.OutputJoke("Chuck Norris is the only person to ever win a staring contest against Ray Charles and Stevie Wonder."), Times.Never);
            MockJokeOutputter.Verify(x => x.OutputJoke("What does a subatomic duck say? Quark."), Times.Once);
        }
    }
}
