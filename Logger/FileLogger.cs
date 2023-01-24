using Logger;
using System;
using System.IO;

public class FileLogger : BaseLogger
{
    private string filePath;
    public override string ClassName { get; set; }

    public string getFilePath()
    {
        return filePath;
    }
	public FileLogger(string filePath)
	{
        this.filePath = filePath;
        this.ClassName = "";
	}

    public override void Log(LogLevel logLevel, string message)
    {
        StreamWriter file = new StreamWriter(this.filePath, true);
        file.WriteLineAsync(DateTime.Now + " " + this.ClassName + " " + logLevel + ": " + message);
    }
}
