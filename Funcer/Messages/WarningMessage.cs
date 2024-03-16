namespace Funcer.Messages;

public struct WarningMessage : IResultMessage
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
        MessageType = ResultMessageType.Basic;
    }
    
    public WarningMessage(string type, string message, string field)
    {
        Type = type;
        Message = message;
        Field = field;
        MessageType = ResultMessageType.Validation;
    }
    
    public string Type { get; }
    public string Message { get; }
    public ResultMessageType MessageType { get; }
    public string? Field { get; } = default;
}