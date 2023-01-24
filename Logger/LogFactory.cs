namespace Logger;

public class LogFactory
{
    private string? _path;
    public BaseLogger? CreateLogger(string className)
    {
        if (_path is null)
        {
            return null;
        }
        return new FileLogger(_path) { ClassName = className };
    }
    public void ConfigureFileLogger(string path)
    {
        _path = path;
    }
}
