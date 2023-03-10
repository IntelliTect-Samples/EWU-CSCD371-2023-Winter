using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests;
[TestClass]
public class NodeTests
{
    Node<int> node = new(1, null!);

    [TestMethod]
    public void CreateNode_ReturnsNode()
    {
        // Assert
        Assert.AreEqual<Node<int>>(node, node.Next);
        Assert.AreEqual<int>(node.Value, 1);
    }

    [TestMethod]
    public void ToString_ReturnsString()
    {
        // Act
        string expected = "1";

        // Assert
        Assert.AreEqual<string>(expected, node.ToString());
    }

    [TestMethod]
    public void Append_Success()
    {
        node.Append(2);
        Assert.AreEqual<Node<int>>(node, node.Next.Next);
        Assert.AreEqual<int>(node.Next.Value, 2);
    }

    [TestMethod]
    public void Clear_CutsAllLinks()
    {
        // Act
        node.Append(2);
        node.Append(3);
        node.Clear();

        // Assert
        Assert.AreEqual<Node<int>>(node, node.Next);
    }

    [TestMethod]
    public void Exists_ReturnsTrue()
    {
        node.Append(2);
        Assert.IsTrue(node.Exists(2));
    }

    [TestMethod]
    public void Exists_ReturnsFalse()
    {
        node.Append(2);
        Assert.IsFalse(node.Exists(3));
    }

    [TestMethod]
    public void TestCircleValues()
    {
        ////Arrange
        //Node<IEnumerable<int>> nodeT = new(new int[] {1}, null!);
        ////Assert
        //Assert.AreEqual<Node<T>>(node, node.Next);
        //Assert.AreEqual<T>(node.Value, 1);

        //Arrange
        node.Append(2);
        node.Append(3);

        //Act
        List<int> nodes = node.ToList();

        //Assert
        Assert.AreEqual<int>(3, nodes.Count);


    }

    [TestMethod]
    public void TestChildItems()
    { 
        //Arrange
        node.Append(2);
        node.Append(3);
        IEnumerable<int> actual = node.ChildItems(2);

        //Assert
        Assert.AreEqual<int>(2, actual.Count());

    }

}