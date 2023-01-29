using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

         [TestMethod]
        public void DisplaysJoke_JokeDisplayToConsole()
        {
            // Assemble
            JokeService service = new JokeService();
            StreamWriter streamWriter = new("./outputFile.txt");
            // StreamReader streamReader = new("./outputFile.txt");

            // Act
            string joke = service.GetJoke();
            Console.SetOut(streamWriter);
            service.Display(joke);
            streamWriter.Close();
            
            string output = File.ReadLines("./outputFile.txt").First();

            // Assert
            Assert.AreEqual(joke, output + "\n"); 
        }
    }
}
