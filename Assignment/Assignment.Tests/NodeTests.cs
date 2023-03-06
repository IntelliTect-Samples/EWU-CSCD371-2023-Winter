using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void GetEnumerator_GivenMultipleNode_IteratesNodeCollection()
    {
        // Assemble
        Node<int> node = new(1);
        node.Append(2);

        int[] expected = new int[3];

        // Act
        var enumerator = node.GetEnumerator();
        enumerator.MoveNext();
        expected[0] = enumerator.Current;
        enumerator.MoveNext();
        expected[1] = enumerator.Current;


        // Assert
        Assert.AreEqual(1, expected[0]);
        Assert.AreEqual(2, expected[1]);
    }

    [TestMethod]
    public void ChildItems_GivenNode_ReturnsNodesLessThanMaximum()
    {
        // Assemble
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        node.Append(4);

        int[] expected = new int[4];

        // Act
        List<int> list = node.ChildItems(2).ToList();

        var enumerator = list.GetEnumerator();
        enumerator.MoveNext();
        expected[0] = enumerator.Current;
        enumerator.MoveNext();
        expected[1] = enumerator.Current;



        // Assert
        Assert.AreEqual(2, expected[0]);
        Assert.AreEqual(3, expected[0]);
    }
}