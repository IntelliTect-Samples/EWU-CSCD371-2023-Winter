using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests;
[TestClass]
public class NodeTests
{
    [TestMethod]
    public void GetEnumerator_MainTest()
    {
        Node<int> node = new(1, null!);
        node.Append(2);
        node.Append(3);
        node.Append(4);
        node.Append(5);
        Assert.AreEqual<int>(5, node.Count());
    }
    [TestMethod]
    public void ChildItems_MainTest()
    {
        //TODO: Figure out what's going wrong here
        Node<int> node = new(1, null!);
        node.Append(2);
        node.Append(3);
        node.Append(4);
        node.Append(5);
        List<int> act = (List<int>)node.ChildItems(3);
        List<int> exp = new()
        {
            1,2,3
        };
        Assert.AreEqual<List<int>>(exp, act);
    }
}
