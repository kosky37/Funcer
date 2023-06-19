using Funcer.Messages;

namespace Funcer;

public interface IResult
{
    bool IsFailure { get; }
    bool IsSuccess { get; }
    IReadOnlyCollection<ErrorMessage> Errors { get; }
    IReadOnlyCollection<WarningMessage> Warnings { get; }
}