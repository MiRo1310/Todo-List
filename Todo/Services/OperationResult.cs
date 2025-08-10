namespace Todo.Services;

public class OperationResult(bool isSuccess = false, string message = "")
{
    public bool IsSuccess { get; set; } = isSuccess;
    public string Message { get; set; } = message;
}