using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GenericsHomework.Tests;

[TestClass]
public class CircularSinglyLinkedListTests
{
    [TestMethod]
    public void AppendData_GetSameData()
    {
        // Arrange
        CircularSinglyLinkedList<string> list = new();

        // Act
        list.Append("zero");
        list.Append("one");
        list.Append("two");
        list.Append("three");

        // Assert
        Assert.AreEqual("zero", list.Get(0));
        Assert.AreEqual("one", list.Get(1));
        Assert.AreEqual("two", list.Get(2));
        Assert.AreEqual("three", list.Get(3));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Append_IfElementAlreadyExists_ThrowsError()
    {
        //Arrange
        CircularSinglyLinkedList<string> list = new();

        //Act
        list.Append("zero");
        list.Append("zero");

        //Assert
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void UninstantiatedHead_Get_ThrowsException()
    {
        // Arrange
        CircularSinglyLinkedList<int> list = new();

        // Act
        _ = list.Get(0);
        // Assert

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Get_OutOfRange_ThrowsException()
    {
        // Arrange
        CircularSinglyLinkedList<int> list = new();

        // Act
        list.Append(32);
        list.Append(33);

        // Assert
        _ = list.Get(2);
    }

    [TestMethod]
    public void Exists_IfHeadIsNull_ReturnFalse()
    {
        //Arrange
        CircularSinglyLinkedList<string> list = new();

        //Act

        //Assert
        Assert.IsFalse(list.Exists("Pizza"));
    }

    [TestMethod]
    public void Exists_DataExistsInList_ReturnTrue()
    {
        //Arrange
        CircularSinglyLinkedList<string> list = new();

        //Act
        list.Append("Pizza");
        list.Append("Pie");
        list.Append("Cake");

        //Assert
        Assert.IsTrue(list.Exists("Pizza"));
    }

    [TestMethod]
    public void Clear_GivenNodeData_ClearsAllButSpecifiedNode()
    {
        //Arrange
        CircularSinglyLinkedList<string> list = new();

        //Act
        list.Append("One");
        list.Append("Two");
        list.Append("Three");

        list.Clear("One");

        //Assert
        Assert.IsTrue(list.Exists("One"));
        Assert.IsFalse(list.Exists("Two"));
        Assert.IsFalse(list.Exists("Three"));
    }

    [TestMethod]
    public void Size_IsEqualToTheNumberOfElementsInList_IsEqualTo3()
    {
        //Arrange
        CircularSinglyLinkedList<string> list = new();

        //Act
        list.Append("One");
        list.Append("Two");
        list.Append("Three");

        //Assert
        Assert.AreEqual<int>(3, list.Size);
    }

    [TestMethod]
    public void Size_IsSetToOneIfListIsCleared_IsEqualTo1()
    {
        //Arrange
        CircularSinglyLinkedList<string> list = new();

        //Act
        list.Append("One");
        list.Append("Two");
        list.Append("Three");

        list.Clear("One");

        //Assert
        Assert.AreEqual<int>(1, list.Size);
    }

}