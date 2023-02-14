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
    public void NodeStringPass()
    {
        string value = "node";
        Node<string> test = new(value);

        Assert.AreEqual<string>(value, test.ToString());

    }
}
