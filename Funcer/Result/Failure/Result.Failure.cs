using Funcer.Messages;

namespace Funcer;

public readonly partial struct Result
{
    public static Result Failure(params IEnumerable<ErrorMessage> errors)
    {
        return new Result(errors);
    }
    
    public static Result<TValue> Failure<TValue>(params IEnumerable<ErrorMessage> errors)
    {
        return Result<TValue>.Failure(errors);
    }
}