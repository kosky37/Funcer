namespace Funcer.Messages;

public class Error : IResultMessage
{
    public string Type { get; }
    public string Message { get; }

    public Error(string type, string message)
    {
        Type = type;
        Message = message;
    }
}