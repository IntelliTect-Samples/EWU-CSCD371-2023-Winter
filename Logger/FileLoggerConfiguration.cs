namespace Logger;

public class FileLoggerConfiguration : ILoggerConfiguration
{
    public FileLoggerConfiguration(string filePath, string logSource)
    {
        FilePath = string.IsNullOrWhiteSpace(filePath)
                ? throw new ArgumentException($"'{nameof(filePath)}' cannot be null or whitespace.", nameof(filePath))
                : filePath;
        LogSource = string.IsNullOrWhiteSpace(logSource)
                ? throw new ArgumentException($"'{nameof(logSource)}' cannot be null or whitespace.", nameof(logSource))
                : logSource;

    }
    
    public string FilePath { get;  }
    public string LogSource { get; }
}
