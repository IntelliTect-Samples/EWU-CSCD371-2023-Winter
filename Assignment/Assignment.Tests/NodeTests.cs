using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests;

[TestClass]
public class TestNode
{
    //ChildItems
    [TestMethod]
    public void Node_ChildItems5_Max10_Equals5()
    {
        var node = new Node<int>(1);
        node.Append(2).Append(3).Append(4).Append(5).Append(6);

        int expected = 5;
        int actual = node.ChildItems(10).Count();

        Assert.AreEqual<int>(expected, actual);
    }

    [TestMethod]
    public void Node_ChildItems5_Max0_Equals0()
    {
        var node = new Node<int>(1);
        node.Append(2).Append(3).Append(4).Append(5).Append(6);

        int expected = 0;
        int actual = node.ChildItems(expected).Count();

        Assert.AreEqual<int>(expected, actual);
    }

    [TestMethod]
    public void Node_ChildItems5_Max2_Equals2()
    {
        var node = new Node<int>(1);
        node.Append(2).Append(3).Append(4).Append(5).Append(6);

        int expected = 2;
        int actual = node.ChildItems(expected).Count();

        Assert.AreEqual<int>(expected, actual);
    }

    [TestMethod]
    public void Node_ExistsAmongstMany_False()
    {
        var node = new Node<int>(10);
        node.Append(11).Append(12).Append(13);
        Assert.IsFalse(node.Exists(14));
    }

    [TestMethod]
    public void Node_ExistsAmongstMany_True()
    {
        var node = new Node<int>(10);
        node.Append(11).Append(12).Append(13);
        Assert.IsTrue(node.Exists(12));
    }

    [TestMethod]
    public void Node_ExistsInSingular_True()
    {
        var node = new Node<int>(11);
        Assert.IsTrue(node.Exists(11));
    }

    [TestMethod]
    public void Node_OnlySelf_NextEqualsSelf()
    {
        var node = new Node<int>(5);
        Assert.AreEqual(node, node.Next);
    }

    [TestMethod]
    public void Node_Clears()
    {
        var node0 = new Node<int>(0);
        var node1 = node0.Append(1);
        var node2 = node1.Append(2);
        var node3 = node2.Append(3);
        Assert.IsTrue(node1.Exists(2));
        node0.Clear();
        Assert.IsFalse(node1.Exists(2));
        Assert.AreEqual(node1, node1.Next);
    }

    [TestMethod]
    public void Node_NotNullValue_ToString()
    {
        var node = new Node<int>(7);
        Assert.AreEqual(node.ToString(), "7");
    }

    [TestMethod]
    public void Node_NullValue_ToString()
    {
        var node = new Node<object>(null!);
        Assert.AreEqual(node.ToString(), null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Node_AppendDuplicate_ThrowsException()
    {
        var node = new Node<int>(0);
        node.Append(1).Append(2).Append(0);
    }

    //ICollection

    [TestMethod]
    public void Node_Count()
    {
        var node = new Node<int>(0);
        node.Append(1).Append(2).Append(3).Append(4);
        Assert.AreEqual(node.Count, 5);
    }

    [TestMethod]
    public void Node_Contains()
    {
        var node = new Node<int>(0);
        node.Append(1).Append(2).Append(3).Append(4);

        Assert.IsTrue(node.Contains(3));
    }

    [TestMethod]
    public void Node_AddItem()
    {
        var node0 = new Node<int>(0);
        var node1 = node0.Append(1);
        ICollection<int> node2 = node1.Append(2);
        var node3 = node2.Append(3);
        var node4 = node3.Append(4);
        node2.Add(8);
        Assert.IsTrue(node0.Contains(8));
        Assert.IsTrue(node4.Contains(8));
    }

    [TestMethod]
    public void Node_RemoveValidItem()
    {
        var node = new Node<int>(0);
        node.Append(1).Append(2).Append(3).Append(4);

        Assert.IsTrue(node.Remove(3));
    }

    [TestMethod]
    public void Node_RemoveInValidItem()
    {
        var node = new Node<int>(0);
        node.Append(1).Append(2).Append(3).Append(4);

        Assert.IsFalse(node.Remove(5));
    }

    [TestMethod]
    public void Node_Enumerable()
    {
        var node = new Node<int>(1);
        node.Append(2).Append(3).Append(4).Append(5);

        var count = node.Sum();
        Assert.AreEqual(15, count);
    }

    [TestMethod]
    public void Node_CopyToArray()
    {
        var array = new int[20];

        var node = new Node<int>(1);
        node.Append(2).Append(3).Append(4).Append(5);

        node.CopyTo(array, 15);
        Assert.AreEqual(array.Sum(), node.Sum());
    }

    [TestMethod]
    public void Node_IsReadonly_False()
    {
        var node = new Node<int>(1);
        Assert.IsFalse(node.IsReadOnly);
    }
}