using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CanHazFunny.Tests
{
    [TestClass]
    public class JokeOutputTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void JokeOutput_NullOutput_ThrowsException()
        {
            // Arrange
            JokeOutput output = new JokeOutput();

            // Act
            output.Stream = null;
        }

        [TestMethod]
        public void JokeOutput_NonNullStream()
        {
            // Arrange
            JokeOutput output = new JokeOutput();
            using MemoryStream stream = new MemoryStream();
            string joke = "joke";

            // Act
            output.Stream = new StreamWriter(stream);
            output.TellJoke(joke);

            // Assert
            Assert.AreEqual<long>(joke.Length + 2, stream.Length);
        }

        [TestMethod]
        public void JokeOutput_StreamNotSet()
        {
            // Arrange
            JokeOutput output = new JokeOutput();

            // Act
            output.TellJoke("joke");

            // Assert
            Assert.IsNull(output.Stream);
        }
    }
}
