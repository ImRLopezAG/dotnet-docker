namespace service;

public class LoggerBuilder
{
  public static LoggerBuilder Instance { get; } = new LoggerBuilder();

  private LoggerBuilder() { }
  public LoggerBuilder NewLine()
  {
    File.AppendAllText("log.txt", Environment.NewLine);

    return this;
  }
  public LoggerBuilder LogLine(string message)
  {
    File.AppendAllText("log.txt", $"[{DateTime.Now}] - {message}" + Environment.NewLine);

    return this;
  }

  public LoggerBuilder DivLine(string serviceName)
  {
    File.AppendAllText("log.txt", "==> " + serviceName + Environment.NewLine);
    return this;
  }
}
