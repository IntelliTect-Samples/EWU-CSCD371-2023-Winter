using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CanHazFunny.Tests
{
    [TestClass]
    public class JokeServiceTests
    {
        [TestMethod]
        public void JokerService_JokeIsNotEmpty()
        {
            // Arrange
            JokeService service = new();

            // Act
            string joke = service.GetJoke();

            // Assert
            Assert.AreNotEqual<string>("", joke);
        }
    }
}
