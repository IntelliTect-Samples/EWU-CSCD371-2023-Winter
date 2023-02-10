namespace Logger.Tests;

public class TestLogger : BaseLogger, ILogger<TestLogger, TestLoggerConfiguration>
{
    public TestLogger(string logSource) : base(logSource) { }


    public static TestLogger CreateLogger(TestLoggerConfiguration configuration)
    {
        return new(configuration.LogSource);
    }

    public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

    public override void Log(LogLevel logLevel, string message) => LoggedMessages.Add((logLevel, message));
}

public class TestLoggerConfiguration : BaseLoggerConfiguration, ILoggerConfiguration
{
    public TestLoggerConfiguration(string logSource) : base(logSource) { }

}
