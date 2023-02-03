using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanHazFunny.Tests;

[TestClass]
public class JesterTests
{
    [TestMethod]
    public void JesterErrorOnNullOutput()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new Jester(null, new JokeService()));
    }

    [TestMethod]
    public void JesterErrorOnNullJokeService()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new Jester(new Output(), null));
    }

    [TestMethod]
    public void JesterErrorOnNullParameters()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new Jester(null, null));
    }

    [TestMethod]
    public void JesterReturnsJoke()
    {
        string[] jokes = { "this is a test joke" };
        DummyOutput dummyOutput = new();
        DummyJokeService dummyJokeService = new(jokes);
        new Jester(dummyOutput, dummyJokeService).TellJoke();
        Assert.AreEqual<String>(dummyOutput.GetLastJoke(), jokes[0]);
    }

    [TestMethod]
    public void JesterIgnoresChuckNorris()
    {
        string[] jokes =
        {
            "this is a chuck norris joke",
            "this is a test joke",
            "this is a chuck norris joke"
        };
        DummyOutput dummyOutput = new();
        DummyJokeService dummyJokeService = new(jokes);
        new Jester(dummyOutput, dummyJokeService).TellJoke();
        Assert.AreEqual<String>(dummyOutput.GetLastJoke(), jokes[1]);
    }

    private class DummyJokeService : IJokeService
    {
        private readonly Queue<string> _jokes;

        public DummyJokeService(IEnumerable<string> jokes)
        {
            _jokes = new Queue<string>(jokes);
        }

        public string GetJoke()
        {
            return _jokes.Dequeue();
        }
    }

    private class DummyOutput : IOutput
    {
        private string _joke = "";

        public void Write(string joke)
        {
            _joke = joke;
        }

        public string GetLastJoke()
        {
            return _joke;
        }
    }
}