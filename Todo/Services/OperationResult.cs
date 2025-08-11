namespace Todo.Services;

public class OperationResult(bool isSuccess = false, string message = "")
{
    public bool IsSuccess { get; } = isSuccess;
    public string Message { get; } = message;
}