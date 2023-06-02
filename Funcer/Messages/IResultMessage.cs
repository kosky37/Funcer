namespace Funcer.Messages;

public interface IResultMessage
{
    string Type { get; }
    string Message { get; }
}