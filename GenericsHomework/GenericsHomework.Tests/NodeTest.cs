using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GenericsHomework.Tests;

[TestClass]
public class NodeTest
{
    Node<int> node = new(5, null!);
    [TestMethod]
    public void InitializeTest()
    {
        Assert.AreEqual<Node<int>>(node, node.Next);
        Assert.AreEqual<int>(5, node.Item);
    }

    [TestMethod]
    public void ToStringTest()
    {
        Assert.AreEqual<string>("5", node.ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AppendTest_Error()
    {
        node.Append(5);
    }

    [TestMethod]
    public void AppendTest_Success()
    {
        node.Append(3);
        Assert.AreEqual<Node<int>>(node, node.Next.Next);
        Assert.AreEqual<int>(3, node.Next.Item);
    }

    [TestMethod]
    public void ExistsTest()
    {
        node.Append(7);
        Assert.IsTrue(node.Exists(5));
        Assert.IsTrue(node.Exists(7));
        Assert.IsFalse(node.Exists(9));
    }

    [TestMethod]
    public void ClearTest()
    {
        node.Clear();
        Assert.AreEqual<Node<int>>(node, node.Next);
        Assert.AreEqual<int>(5, node.Item);
    }
}