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
        CircularSinglyLinkedList<int> list = new();
        Node<int> head;

        //Act
        list.Append(1);
        head = list.Head!;
        head.Add(2);

        //Assert
        Assert.AreEqual<int>(2, head.Count);
        Assert.AreEqual<int>(2, head.Next.Data);
    }


    [TestMethod]
    public void CopyTo_CorrectlyCopiesData()
    {
        //Arrange
        int[] ints = {0, 0, 0, 0, 0};
        CircularSinglyLinkedList<int> list = new();
        Node<int> head;

        //Act
        list.Append(1);
        head = list.Head!;
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

    [TestMethod]
    public void TestEnumerator_Enumerable()
    {
        //Arrange
        CircularSinglyLinkedList<string> list = new();
        Node<string> head;
        IEnumerator<string> headEnumerator;
        string[] iteratorComparison = { "one", "two", "three", "four" };
        int index = 0;

        //Act
        list.Append("one");
        head = list.Head!;
        headEnumerator = head.GetEnumerator();
        head.Add("two");
        head.Add("three");
        head.Add("four");

        //Assert
        Assert.IsTrue(headEnumerator.MoveNext());
        Assert.AreEqual<string>("one", headEnumerator.Current);
        Assert.IsTrue(headEnumerator.MoveNext());
        Assert.AreEqual<string>("two", headEnumerator.Current);
        Assert.IsTrue(headEnumerator.MoveNext());
        Assert.AreEqual<string>("three", headEnumerator.Current);
        Assert.IsTrue(headEnumerator.MoveNext());
        Assert.AreEqual<string>("four", headEnumerator.Current);
        Assert.IsFalse(headEnumerator.MoveNext());
        headEnumerator.Reset();

        foreach (string item in head)
        {
            Assert.AreEqual(iteratorComparison[index++], item);
        }
    }
}
