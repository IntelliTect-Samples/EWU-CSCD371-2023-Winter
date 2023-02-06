﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests : FileLoggerTestsBase
{    
    [TestMethod]
    public void CreateGivenClassAndValidFileNameSuccess()
    {
        Assert.AreEqual(nameof(FileLoggerTests), Logger.LogSource);
        Assert.AreEqual(FilePath, Logger.FilePath);
    }

    [TestMethod]
    public async Task LogMessageFileAppended()
    {
        Logger.Log(LogLevel.Error, "Message1");
        Logger.Log(LogLevel.Error, "Message2");

        string[] lines = await File.ReadAllLinesAsync(FilePath).ConfigureAwait(false);
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
