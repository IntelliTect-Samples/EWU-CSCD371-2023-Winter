using System.Data;
using GenericsHomework;
using NUnit.Framework;

namespace GenericsHomeworkTests;

public class GenericsHomework
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CanCreateNode()
    {
        string item = "test";
        var node = new Node<string>(item);
        Assert.AreEqual(item, node.Item);
    }

    [Test]
    public void ExistsFindsObjects()
    {
        string item = "test";
        var node = new Node<string>(item);
        Assert.True(node.Exists(item));
    }

    [Test]
    public void ThrowsOnDuplicateItemAppended()
    {
        string item = "test";
        string dupe = "test";
        var node = new Node<string>(item);
        Assert.Throws<DuplicateNameException>(() => node.Append(dupe));
    }

    [Test]
    public void AppendAddsItem()
    {
        string itemB = "item_b";
        var node = new Node<string>("item_a");
        node.Append(itemB);
        Assert.AreEqual(node.Next.Item, itemB);
    }

    [Test]
    public void ToStringReturnsItemToString()
    {
        string item = "test";
        var node = new Node<string>(item);
        Assert.AreEqual(item, node.ToString());
    }

    [Test]
    public void NextReturnsThisIfNoNext()
    {
        var node = new Node<string>("test");
        Assert.AreEqual(node, node.Next);
    }

    [Test]
    public void ClearRemovesExtraNodes()
    {
        var node = new Node<string>("item_a");
        node.Append("item_b");
        node.Clear();
        Assert.AreEqual(node, node.Next);
    }
}