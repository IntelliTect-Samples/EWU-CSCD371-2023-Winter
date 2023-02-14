using System.Data;
using GenericsHomework;
using NUnit.Framework;

#pragma warning disable NUnit2005
namespace GenericsHomeworkTests;

public class GenericsHomeworkICollection
{
    [Test]
    public void NotReadOnly() => Assert.False(new Node<string>("test").IsReadOnly);

    [Test]
    public void CountsSizeOne() => Assert.AreEqual(1, new Node<string>("test").Count);
    
    [Test]
    public void CountGreaterThanOne()
    {
        var node = new Node<string>("1");
        node.Add("2");
        Assert.AreEqual(2, node.Count);
    }

    [Test]
    public void AddAddsItem()
    {
        string itemB = "item_b";
        var node = new Node<string>("item_a");
        node.Add(itemB);
        Assert.AreEqual(node.Next.Item, itemB);
    }

    [Test]
    public void ContainsFindsObjects()
    {
        string item = "test";
        var node = new Node<string>(item);
        Assert.True(node.Contains(item));
    }
    
    [Test]
    public void ContainsDoesntFindMissingItem()
    {
        string item = "test";
        var node = new Node<string>(item);
        Assert.False(node.Contains("not_item"));
    }

    [Test]
    public void RemoveDeletesItem()
    {
        string itemA = "item_a";
        string itemB = "item_b";
        var node = new Node<string>(itemA);
        node.Add(itemB);
        node.Remove(itemB);
        Assert.False(node.Contains(itemB));
    }
}