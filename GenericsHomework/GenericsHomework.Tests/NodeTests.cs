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
}
