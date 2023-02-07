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
}