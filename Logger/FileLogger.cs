using Logger;
using System;
using System.IO;

public class FileLogger : BaseLogger
{
    private string FilePath;
    public override string ClassName { get; set; }

    public string getFilePath()
    {
        return FilePath;
    }
	public FileLogger(string filePath)
	{
        FilePath = filePath;
        ClassName = "";
	}

    public override void Log(LogLevel logLevel, string message)
    {
        StreamWriter file = new StreamWriter(FilePath, true);
        file.WriteLineAsync(DateTime.Now + " " + ClassName + " " + logLevel + ": " + message);
    }
}
