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

        // Act
        // Assert
        var enumerator = node.GetEnumerator();
        enumerator.MoveNext();
        int nodeValue1 = enumerator.Current;
        Assert.AreEqual(1, nodeValue1);
        enumerator.MoveNext();
        int nodeValue2 = enumerator.Current;
        Assert.AreEqual(2, nodeValue2);
    }
}