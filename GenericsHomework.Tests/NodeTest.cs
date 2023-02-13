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

    [TestMethod]
    public void GivenData_AppendsNodeToExistingNode()
    {
        // Assemble
        Node<int> node1 = new(12);
        Node<int> node2 = new(88);

        // Act
        node1.Append(88);

        // Assert
        Assert.AreEqual(node1.Next.Data, node2.Data);
    }

    [TestMethod]
    public void GivenNode_AppendsNodeToExistingNode()
    {
        // Assemble
        Node<int> node1 = new(12);
        Node<int> node2 = new(88);

        // Act
        node1.Append(node2);

        // Assert
        Assert.AreEqual(node1.Next, node2);
    }

    [TestMethod]
    public void Exists_IfNodeAlreadyExists_ReturnTrue()
    {
        // Assemble
        Node<int> node1 = new(100);
        Node<int> node2 = new(200);
        Node<int> node3= new(200);
        Node<int> node4 = new(300);

        // Act
        node1.Append(node2);

        // Assert
        Assert.IsTrue(node1.Exists(node3.Data));
        Assert.IsFalse(node1.Exists(node4.Data));
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidDataException))]
    public void Append_IfDataExists_ThrowError()
    {
        // Asseble
        Node<string> node1 = new("Hello!");

        // Act
        node1.Append("Hello!");
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidDataException))]
    public void Append_IfNodeExists_ThrowError()
    {
        // Asseble
        Node<string> node1 = new("Hello!");
        Node<string> node2 = new("Hello!");

        // Act
        node1.Append(node2);
    }

    [TestMethod]
    public void Clear_AfterListIsCleared_NextPointsToSelf()
    {
        // Assemble
        Node<double> node1 = new(1.00);
        Node<double> node2 = new(2.00);
        Node<double> node3 = new(3.00);

        // Act
        node1.Append(node2);
        node1.Append(node3);
        node1.Clear();

        // Assert
        Assert.IsTrue(node1.Next == node1);
    }
}