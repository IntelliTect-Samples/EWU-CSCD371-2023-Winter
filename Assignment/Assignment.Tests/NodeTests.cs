using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Assignment.Tests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void GetEnumerator_ReturnsNodeValues()
    {
        Node<int> newNode = new(1);
        newNode.Append(2).Append(3).Append(4).Append(5).Append(6);

        foreach(int value in newNode)
        {
            Console.WriteLine(value);
        }

        Assert.AreEqual<int>(6, newNode.Count());

    }

    [TestMethod]
    public void ChildItems_GivenMaximumOfThree_ReturnThreeValues()
    {
        Node<int> newNode = new(1);
        newNode.Append(2).Append(3).Append(4).Append(5).Append(6);

        Assert.AreEqual<int>(3, newNode.ChildItems(3).Count());
    }
}