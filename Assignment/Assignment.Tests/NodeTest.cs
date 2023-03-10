using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests;

[TestClass]
public class NodeTest
{
    [ExpectedException(typeof(ArgumentNullException))]
    [TestMethod]
    public void Node_Constructor_NullValue_ThrowsArgumentNullException()
    {
        _ = new Node<string>(null !);
    }

    [TestMethod]
    public void Node_Constructor_ValidValue_SetsValue()
    {
        Node<string> node = new Node<string>("Test");
        Assert.AreEqual("Test", node.ToString());
    }

    [TestMethod]
    public void Node_Constructor_ValidValue_SetsNextToSelf()
    {
        Node<string> node = new Node<string>("Test");
        Assert.AreEqual(node, node.Next);
    }

    [TestMethod]
    public void Node_Append_ValidValue_SetsNextToNewNode()
    {
        Node<string> node = new Node<string>("Test");
        node.Append("Test2");
        Assert.AreEqual("Test2", node.Next.ToString());
    }

    [TestMethod]
    public void Nodes_AreCircular_IsTrue()
    {
        Node<string> node = new Node<string>("Test");
        node.Append("Test2");
        node.Append("Test3");
        Assert.AreEqual("Test", node.ToString());
        Assert.AreEqual("Test2", node.Next.ToString());
        Assert.AreEqual("Test3", node.Next.Next.ToString());
        Assert.AreEqual("Test", node.Next.Next.Next.ToString());
        Assert.AreEqual("Test2", node.Next.Next.Next.Next.ToString());
    }

    [ExpectedException(typeof(ArgumentException))]
    [TestMethod]
    public void Node_Append_DuplicateValue_ThrowsArgumentException()
    {
        Node<string> node = new Node<string>("Test");
        node.Append("Test2");
        node.Append("Test2");
    }

    [TestMethod]
    public void Node_AllChildItems_ReturnsCorrectNumberOfItems()
    {
        Node<string> node = new Node<string>("Test");
        node.Append("Test2");
        node.Append("Test3");
        node.Append("Test4");
        node.Append("Test5");
        node.Append("Test6");
        Assert.AreEqual(6, node.AllChildItems().Count());
    }

    [TestMethod]
    public void Node_ChildItems_ReturnsCorrectNumberOfItems()
    {
        Node<string> node = new Node<string>("Test");
        node.Append("Test2");
        node.Append("Test3");
        node.Append("Test4");
        node.Append("Test5");
        node.Append("Test6");
        IEnumerable<string> childItems = node.ChildItems(3);
        Assert.AreEqual(3, childItems.Count());
    }
}
