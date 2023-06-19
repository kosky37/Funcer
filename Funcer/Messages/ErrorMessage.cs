namespace Funcer.Messages;

public struct ErrorMessage
{
    public ErrorMessage(string type, string message)
    {
        Type = type;
        Message = message;
        MessageType = MessageType.Basic;
    }
    
    public ErrorMessage(string type, string message, string field)
    {
        Type = type;
        Message = message;
        Field = field;
        MessageType = MessageType.Validation;
    }
    
    public string Type { get; }
    public string Message { get; }
    public MessageType MessageType { get; }
    public string? Field { get; }
}