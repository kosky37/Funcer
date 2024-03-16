namespace Funcer.Messages;

public interface IResultMessage
{
    string Type { get; }
    string Message { get; }
    ResultMessageType MessageType { get; }
    string? Field { get; }
}