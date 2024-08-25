namespace service;

public class Result<T>
{
  public T? Data { get; set; }
  public bool IsSuccess { get; }
  public string Message { get; set; } = default!;

  private Result(T? data, bool isSuccess, string message)
  {
    Data = data;
    IsSuccess = isSuccess;
    Message = message;
  }

  public static Result<T> Success(T data) => new(data, true, string.Empty);
  public static Result<T> Failed(string message, string Name = "")
  {
    Log(message, Name);
    return new(default, false, message);
  }

  public static Result<T> NotFound() => new(default, false, "Not Found");

  public static Result<T> Log(string message, string Name = "")
  {
    var logger = LoggerBuilder.Instance;
    logger
      .DivLine(Name)
      .LogLine(message)
      .NewLine();

    return new(default, false, message);
  }

  public void Deconstruct(out T? data, out bool isSuccess, out string message)
  {
    data = Data;
    isSuccess = IsSuccess;
    message = Message;
  }
}
