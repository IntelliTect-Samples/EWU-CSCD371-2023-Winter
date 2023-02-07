namespace Logger.Tests;

[TestClass]
public class FileLoggerTests : FileLoggerTestsBase
{    
    [TestMethod]
    public void Create_GivenClassAndValidFileName_Success()
    {
        Assert.AreEqual(nameof(FileLoggerTests), Logger.LogSource);
        Assert.AreEqual(FilePath, Logger.FilePath);
    }

    [TestMethod]
    public async Task Log_Message_FileAppended()
    {
        Logger.Log(LogLevel.Error, "Message1");
        Logger.Log(LogLevel.Error, "Message2");

        string[] lines = await File.ReadAllLinesAsync(FilePath);
        Assert.IsTrue(lines is [..] and { Length: 2 });
        foreach (string[] line in lines.Select(line => line.Split(',', 4)))
        {
            if (line is [string dateTime, string source, string levelText, string message])
            {
                Assert.IsTrue(DateTime.TryParse(dateTime, out _));
                Assert.AreEqual(nameof(FileLoggerTests), source);
                Assert.IsTrue(Enum.TryParse(typeof(LogLevel), levelText, out object? level) ?
                    level is LogLevel.Error : false,"Level was not parsed successfully.");
            }
        }
    }
}
