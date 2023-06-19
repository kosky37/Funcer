namespace Funcer.Messages;

public struct WarningMessage
{
    public WarningMessage(ErrorMessage error)
    {
        Type = error.Type;
        Message = error.Message;
        MessageType = error.MessageType;
        Field = error.Field;
    }

    public WarningMessage(string type, string message)
    {
        Type = type;
        Message = message;
        MessageType = MessageType.Basic;
    }
    
    public WarningMessage(string type, string message, string field)
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