using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GenericsHomework.Tests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void ToString_NodeToStringMethodUsesStoredDataTypeToStringMethod_ReturnsTrue()
    {
        //Arrange
        CircularSinglyLinkedList<int> list = new();

        //Act
        list.Append(5);

        //Assert
        Assert.AreEqual<string>("5", list.GetNode(0).ToString());
    }


    // ICollection-specific tests
    [TestMethod]
    public void Add_AddsNewValue()
    {
        //Arrange
        Node<int> head = new(1, true);

        //Act
        head.Add(42);

        //Assert
        Assert.AreEqual<int>(2, head.Count);
        Assert.IsFalse(head.Next.IsHead);
        Assert.AreEqual<int>(42, head.Next.Data);
    }


    [TestMethod]
    public void CopyTo_CorrectlyCopiesData()
    {
        //Arrange
        int[] ints = {0, 0, 0, 0, 0};
        Node<int> head = new(1, true);

        //Act
        head.Add(2);
        head.Add(3);
        head.Add(4);
        head.CopyTo(ints, 1);

        //Assert
        Assert.AreEqual<int>(4, head.Count);
        for (int i = 0; i < ints.Length; i++)
        {
            Assert.AreEqual<int>(i, ints[i]);
        }
    }
}
