namespace Funcer.Messages;

public class Warning : IResultMessage
{
    public Warning(IResultMessage error)
    {
        Type = error.Type;
        Message = error.Message;
    }
    
    public string Type { get; }
    public string Message { get; }

    public Warning(string type, string message)
    {
        Type = type;
        Message = message;
    }
}