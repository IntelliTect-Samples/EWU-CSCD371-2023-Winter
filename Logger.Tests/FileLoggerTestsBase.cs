namespace Logger.Tests;

[TestClass]
public class FileLoggerTestsBase
{
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected string FilePath { get; set; }
    protected FileLogger Logger { get; set; }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    [TestInitialize]
    public virtual void TestInitialize()
    {
        FilePath = Path.GetTempFileName();
        Logger = new FileLogger(nameof(FileLoggerTests), FilePath);
    }

    [TestCleanup]
    public virtual void TestCleanup()
    {
        if (File.Exists(FilePath)) File.Delete(FilePath);
    }
}
