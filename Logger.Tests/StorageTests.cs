using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;

[TestClass]
public class StorageTests
{
    protected Storage? _Storage;

    [TestInitialize]
    public void Initialize()
    {
        _Storage = new Storage();
    }

    [TestMethod]
    public void Add_AnyEntity_Success()
    {
        // Arrange
        Student student = new(new FullName("Jordan", "Peterson"));
        Employee employee = new(new FullName("Jordan", "Peterson"));
        Book book = new("Beyond Order", "Jordan Peterson", "2222");

        // Act
        _Storage!.Add(student);
        _Storage.Add(employee);
        _Storage.Add(book);


        // Assert
        Assert.IsTrue(_Storage.Contains(student));
        Assert.IsTrue(_Storage.Contains(employee));
        Assert.IsTrue(_Storage.Contains(book));
    }

    [TestMethod]
    public void AddAndRemove_AnyEntity_Success()
    {
        // Arrange
        Student student = new(new FullName("Jordan", "Peterson"));
        Employee employee = new(new FullName("Jordan", "Peterson"));
        Book book = new("Beyond Order", "Jordan Peterson", "2222");

        // Act
        _Storage!.Add(student);
        _Storage.Add(employee);
        _Storage.Add(book);
        _Storage.Remove(student);
        _Storage.Remove(employee);
        _Storage.Remove(book);

        // Assert
        Assert.IsFalse(_Storage.Contains(student));
        Assert.IsFalse(_Storage.Contains(employee));
        Assert.IsFalse(_Storage.Contains(book));
    }

    [TestMethod]
    public void Get_ReturnsFirstEntity()
    {
        // Arrange
        Student student = new(new FullName("Jordan", "Peterson"));
        Employee employee = new(new FullName("Jordan", "Peterson"));
        Book book = new("Beyond Order", "Jordan Peterson", "2222");

        // Act
        _Storage!.Add(student);
        _Storage.Add(employee);
        _Storage.Add(book);

        // Arrange
        Assert.IsTrue((Book)_Storage.Get(book.Id)! == book);
    }

}
