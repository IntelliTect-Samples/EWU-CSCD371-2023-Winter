using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace CanHazFunny.Tests;

[TestClass]
public class JesterTests
{
    [TestMethod]
    public void TellJoke_GivenJoke_ReturnJoke()
    {
        // Arrange
        var jokeServiceMock = new Mock<IJoke>();
        JokeService jokeService = new();
        jokeServiceMock.SetupSequence(jokeService => jokeService.GetJoke()).Returns("Test joke");
        Jester testJester = new(jokeServiceMock.Object, new ConsoleOutput());

        // Act
        string joke = testJester.TellJoke();

        // Assert
        Assert.AreEqual<string>("Test joke", joke);
    }

    [TestMethod]
    public void TellJoke_GivenChuckNorris_SkipJoke()
    {
        // Arrange
        var jokeServiceMock = new Mock<IJoke>();
        JokeService jokeService = new();
        jokeServiceMock.SetupSequence(jokeService => jokeService.GetJoke())
            .Returns("Chuck Norris")
            .Returns("Test joke");
        Jester testJester = new(jokeServiceMock.Object, new ConsoleOutput());

        // Act
        string joke = testJester.TellJoke();

        // Assert
        Assert.AreEqual<string>("Test joke", joke);
    }

    [TestMethod]
    public void ConsoleOutput_Write_WritesLine()
    {
        // Arrange
        string text = "test string";
        ConsoleOutput consoleOutput = new();
        StringWriter writer = new();
        Console.SetOut(writer);

        // Act
        consoleOutput.Write(text);
        string result = writer.ToString().Trim();

        // Assert
        Assert.AreEqual<string>(text, result);
    }
}
