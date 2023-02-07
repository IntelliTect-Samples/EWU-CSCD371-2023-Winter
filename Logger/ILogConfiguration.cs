namespace Logger;
//TODO: Is this really necessary as it's own file? Or even at all?
public interface ILoggerConfiguration
{
    string LogSource { get; }
    
}