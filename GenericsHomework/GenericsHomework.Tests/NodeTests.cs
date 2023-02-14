using System;
namespace GenericsHomework.Tests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void ToStringValuePass()
    {
        int value = 60;
        Node<int> test = new(value);

        Assert.AreEqual<string>(value.ToString(), test.ToString());

    }
    /*
    [TestMethod]
    public void NodeAppendPass()
    {
        Node<string> TestNode = new("new string");
        Assert.IsNotNull(TestNode);
        TestNode.Append("test node");
        Assert.IsTrue(TestNode.Exists("test node"));
    }
    */
    [TestMethod]
    public void NodeStringPass()
    {
        string value = "node";
        Node<string> test = new(value);

        Assert.AreEqual<string>(value, test.ToString());

    }
    [TestMethod]
    public void NodeDoublePass()
    {
        double value = 2.33;
        Node<double> test = new(value);

        Assert.AreEqual<string>(value.ToString(), test.ToString());

    }
    [TestMethod]
    public void NodeCharPass()
    {
        char value = 'a';
        Node<char> test = new(value);

        Assert.AreEqual<string>(value.ToString(), test.ToString());

    }
}
