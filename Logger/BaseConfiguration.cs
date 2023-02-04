namespace Logger;

public class BaseLoggerConfiguration : ILoggerConfiguration
{
    public BaseLoggerConfiguration(string logSource) => LogSource = string.IsNullOrWhiteSpace(logSource)
            ? throw new ArgumentException($"'{nameof(logSource)}' cannot be null or whitespace.", nameof(logSource))
            : logSource;
    
    public string LogSource { get; }
    
}