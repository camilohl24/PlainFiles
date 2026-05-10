namespace Core;

public class LogWriter : IDisposable
{
    private readonly StreamWriter _writer;

    public LogWriter(string path)
    {
        _writer = new StreamWriter(path, append: true)
        {
            AutoFlush = true
        };
    }

    public void WriteLog(string level, string message)
    {
        var timeStamp = DateTime.Now.ToString("s");
        var logEntry = $"{timeStamp} [{level}] {message}";
        _writer.WriteLine(logEntry);
    }
    public void Dispose()
    {
        _writer.Dispose();
    }


}
