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
    [TestMethod]
    public void NodeAppendAndNextPass()
    {
        string value = "jim";
        string value1 = "pam";

        Node<string> test = new(value);
        Node<string> test1 = test.Append(value1);

        Assert.AreEqual(test.Next, test1);
    }
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
    [TestMethod]
    public void NodeClearPass()
    {
        string value = "jim";
        string value1 = "pam";
        string value2 = "kelly";

        Node<string> test = new(value);
        test.Append(value1);
        test.Append(value2);
        test.Clear();

        Assert.AreEqual(test, test.Next);
    }
    [TestMethod]
    public void NodeExistsPass()
    {
        string value = "jim";
        string value1 = "pam";
        string value2 = "kelly";

        Node<string> test = new(value);
        test.Append(value1);
        test.Append(value2);
        test.Clear();

        Assert.IsTrue(test.Exists("jim"));
    }
}
