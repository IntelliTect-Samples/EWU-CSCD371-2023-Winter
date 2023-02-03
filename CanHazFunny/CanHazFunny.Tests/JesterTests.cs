using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CanHazFunny.Tests;

[TestClass]
public class JesterTests
{
    [TestMethod]
    public void CreateJester_ReturnsJester()
    {
        // Assemble
        Jester jester = new(new JokeService(), new JokeDisplayer());

        // Assert
        Assert.IsNotNull(jester);
    }

    [TestMethod]
    public void CreateJester_SuccessfullyGetJoke()
    {
        // Assemble
        Jester jester = new(new JokeService(), new JokeDisplayer());

        // Act
        string joke = jester.JokeRetriever.GetJoke();

        // Assert
        Assert.IsNotNull(joke);
        Assert.AreNotEqual(joke, "");
    }

    [TestMethod]
    [ExpectedException(typeof(System.ArgumentNullException))]
    public void Create_GivenNullJokeService_ThrowsException()
    {
        // Assemble - Act
        Jester jester = new(null, new JokeDisplayer());
    }

    [TestMethod]
    [ExpectedException(typeof(System.ArgumentNullException))]
    public void Create_GivenNullJokeDisplayer_ThrowsException()
    {
        // Assemble - Act
        Jester jester = new(new JokeService(), null);
    }

    [TestMethod]
    public void JokeFilter_GivenJokeWithChuckNorris_ReturnsFalse()
    {
        // Asseble
        MockJokeService mockService = new MockJokeService();

        // Act
        string joke = mockService.GetJokeWithChuckNorris();
        bool result = Jester.JokeFilter(joke);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void JokeFilter_GivenJokeWithoutChuckNorris_ReturnsTrue()
    {
        // Asseble
        MockJokeService mockService = new MockJokeService();

        // Act
        string joke = mockService.GetJokeWithoutChuckNorris();
        bool result = Jester.JokeFilter(joke);

        // Assert
        Assert.IsTrue(result);
    }


    public class MockJokeService
    {
        public string GetJokeWithChuckNorris()
        {
            return "This joke contains ChuCk NORriS";
        }
        public string GetJokeWithoutChuckNorris()
        {
            return "This joke doesn't have he-who-shall-not-be-named.";
        }
    }
}
