namespace Logger;

public static class BaseLoggerMixins
{
    //TODO: Explain tiny arrows and why they are here
    public static void Error(this BaseLogger logger, string message) =>
        (logger??throw new ArgumentNullException(nameof(logger))).Log(LogLevel.Error, message);
    public static void Warning(this BaseLogger logger, string message) =>
        (logger??throw new ArgumentNullException(nameof(logger))).Log(LogLevel.Warning, message);
    public static void Information(this BaseLogger logger, string message) =>
        (logger??throw new ArgumentNullException(nameof(logger))).Log(LogLevel.Information, message);
    public static void Debug(this BaseLogger logger, string message) =>
        (logger??throw new ArgumentNullException(nameof(logger))).Log(LogLevel.Debug, message);
}
