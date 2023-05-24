namespace Funcer;

public interface IResult
{
    bool IsFailure { get; }
    bool IsSuccess { get; }
    IList<Error> Errors { get; }
}