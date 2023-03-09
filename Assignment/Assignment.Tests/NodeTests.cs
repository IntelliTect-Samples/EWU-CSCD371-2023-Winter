using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Assignment.Tests;
[TestClass]
public class NodeTests
{
    [TestMethod]
    public void GetEnumerator_MainTest()
    {
        Node<int> n = new(1, null!);
        n.Append(2);
        n.Append(3);
        n.Append(4);
        n.Append(5);
        int[] exp = new int[] { 5, 4, 3, 2, 1 };
        int[] act = new int[5];
        IEnumerator<int> e = n.GetEnumerator();
        e.MoveNext();
        act[0] = e.Current;
        e.MoveNext();
        act[1] = e.Current;
        e.MoveNext();
        act[2] = e.Current;
        e.MoveNext();
        act[3] = e.Current;
        e.MoveNext();
        act[4] = e.Current;
        int j = 0;
        foreach (int i in exp)
        {
            Assert.AreEqual(i, act[j]);
            j++;
        }
    }
    [TestMethod]
    public void ChildItems_AllTest()
    {
        Node<int> n = new(1, null!);
        n.Append(2);
        n.Append(3);
        n.Append(4);
        n.Append(5);
        List<int> act = (List<int>)n.ChildItems(5);
        List<int> exp = new List<int>();
        exp.Add(5);
        exp.Add(4);
        exp.Add(3);
        exp.Add(2);
        exp.Add(1);
        int j = 0;
        foreach (int i in exp)
        {
            Assert.AreEqual(i, act[j]);
            j++;
        }
    }
    [TestMethod]
    public void ChildItems_PartialTest()
    {
        Node<int> n = new(1, null!);
        n.Append(2);
        n.Append(3);
        n.Append(4);
        n.Append(5);
        List<int> act = (List<int>)n.ChildItems(3);
        List<int> exp = new List<int>();
        exp.Add(5);
        exp.Add(4);
        exp.Add(3);
        int j = 0;
        foreach (int i in exp)
        {
            Assert.AreEqual(i, act[j]);
            j++;
        }
    }
}
