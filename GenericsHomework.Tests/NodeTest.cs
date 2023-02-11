using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GenericsHomework.Tests;

[TestClass]
public class NodeTest
{
    [TestMethod]
    public void CreateNode_ContructorTakesMultipleTypes_ReturnsNotNull()
    {
        //Assemble
        Node<int> node1 = new(30);
        Node<string> node2 = new("Some Value");
        Node<double> node3 = new(3.14);

        //Act

        //Assert
        Assert.IsNotNull(node1);
        Assert.IsNotNull(node2);
        Assert.IsNotNull(node3);
    }

    [TestMethod]
    public void ToString_OverridesToStringResults_ReturnsNodeToString()
    {
        //Assemble
        Node<int> node1 = new(30);
        Node<string> node2 = new("Some Value");
        Node<double> node3 = new(3.14);

        //Act

        //Assert
        Assert.AreEqual("Node Value: 30", node1.ToString());
        Assert.AreEqual("Node Value: Some Value", node2.ToString());
        Assert.AreEqual("Node Value: 3.14", node3.ToString());
    }

    [TestMethod]
    public void CreateNode_NodeNextPointsToSelf_ReturnsItself()
    {
        //Assemble
        Node<int> node = new(30);

        //Act

        //Assert
        Assert.AreEqual(node, node.Next);
    }
}