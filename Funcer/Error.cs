namespace Funcer;

public class Error
{
    public string Type { get; }
    public string Message { get; }

    public Error(string type, string message)
    {
        Type = type;
        Message = message;
    }
}