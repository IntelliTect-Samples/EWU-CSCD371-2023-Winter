using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleDataTest;

[TestClass]
public class sNodeTest
{
    [TestMethod]
    public void TestChildItems()
    {
        // Arrange
        var node = new Node<int>(1);
        node.Append(2);
        node.Append(3);
        node.Append(4);
        node.Append(5);

        // Act
        var result = node.ChildItems(3);

        // Assert
        CollectionAssert.AreEqual(new int[] { 2, 3, 4 }, result.ToArray());
    }

    [TestMethod]
    public void TestGetAllItems()
    {
        // Arrange
        var node = new Node<int>(1);
        node.Append(2);
        node.Append(3);
        node.Append(4);
        node.Append(5);
        int i = 0;

        // Act
        var result = new List<int>();
        foreach (var item in node)
        {
            result.Add(item);
            i ++;
            if (i == 5){
                break;
            }
        }

        // Assert
        CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, result.ToArray());
    }
}