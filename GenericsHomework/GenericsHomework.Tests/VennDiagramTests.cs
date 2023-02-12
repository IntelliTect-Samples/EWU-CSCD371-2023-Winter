using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GenericsHomework.Tests;
[TestClass]
public class VennDiagramTests
{
    VennDiagram<Circle<string>> venn = new("Animals");
    [TestMethod]
    public void InitializeTest()
    {
        Assert.AreEqual<string>("Animals", venn.Title);
        Assert.IsNotNull(venn.Circles);
    }

    [TestMethod]
    public void AddTest_VennDiagram()
    {
        Circle<string> circle1 = new("Can Fly");
        Circle<string> circle2 = new("Can Swim");
        Circle<string> circle3 = new("Can Walk");
        venn.Circles.Add(circle1);
        venn.Circles.Add(circle2);
        venn.Circles.Add(circle3);
        Assert.IsTrue(venn.Circles.Contains(circle1));
        Assert.IsTrue(venn.Circles.Contains(circle2));
        Assert.IsTrue(venn.Circles.Contains(circle3));
        venn.Circles.Remove(circle1);
        venn.Circles.Remove(circle2);
        venn.Circles.Remove(circle3);
    }

    [TestMethod]
    public void AddTest_Circle()
    {
        Circle<string> circle = new("Is supernatural");
        venn.Circles.Add(circle);
        venn.Circles[0].Items.Add("Ghost");
        venn.Circles[0].Items.Add("Vampire");
        venn.Circles[0].Items.Add("Werewolf");
        Assert.IsTrue(venn.Circles[0].Items.Contains("Ghost"));
        Assert.IsTrue(venn.Circles[0].Items.Contains("Vampire"));
        Assert.IsTrue(venn.Circles[0].Items.Contains("Werewolf"));
        venn.Circles.Remove(circle);
    }

    [TestMethod]
    public void ToStringTest()
    {
        Circle<string> circle1 = new("Can Fly");
        Circle<string> circle2 = new("Can Swim");
        Circle<string> circle3 = new("Can Walk");
        venn.Circles.Add(circle1);
        venn.Circles.Add(circle2);
        venn.Circles.Add(circle3);
        venn.Circles[0].Items.Add("Crow");
        venn.Circles[0].Items.Add("Duck");
        venn.Circles[1].Items.Add("Salmon");
        venn.Circles[1].Items.Add("Duck");
        venn.Circles[2].Items.Add("Crow");
        venn.Circles[2].Items.Add("Duck");
        string test = "Animals\nCan Fly // Crow // Duck\nCan Swim // Salmon // Duck\nCan Walk // Crow // Duck";
        Assert.AreEqual<string>(test, venn.ToString()!);
    }
}
