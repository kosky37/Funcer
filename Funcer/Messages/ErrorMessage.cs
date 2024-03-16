namespace Funcer.Messages;

public struct ErrorMessage : IResultMessage
{
    public ErrorMessage(string type, string message)
    {
        Type = type;
        Message = message;
        MessageType = ResultMessageType.Basic;
    }
    
    public ErrorMessage(string type, string message, string field)
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