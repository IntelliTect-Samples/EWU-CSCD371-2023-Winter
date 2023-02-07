namespace Logger.Tests;

public class TestLoggers : BaseLogger, ILogger
{
    public TestLoggers(string logSource) : base(logSource) { }
    
    public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

    public override string LogSource => throw new NotImplementedException();

    public static ILogger CreateLogger(in TestLoggerConfiguration configuration) => 
        new TestLoggers(configuration.LogSource);

    static ILogger ILogger.CreateLogger(in ILoggerConfiguration configuration) => 
        configuration is TestLoggerConfiguration testLoggerConfiguration
            ? CreateLogger(testLoggerConfiguration)
            : throw new ArgumentException("Invalid configuration type", nameof(configuration));

    public override void Log(LogLevel logLevel, string message) => LoggedMessages.Add((logLevel, message));
}

public class TestLoggerConfiguration : BaseLoggerConfiguration, ILoggerConfiguration
{
    public TestLoggerConfiguration(string logSource) : base(logSource) { }

}
