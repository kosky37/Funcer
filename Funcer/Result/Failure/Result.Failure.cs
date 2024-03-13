using Funcer.Messages;

namespace Funcer;

public readonly partial struct Result
{
    public static Result Failure(ErrorMessage error)
    {
        return new Result(error);
    }
    
    public static Result Failure(IEnumerable<ErrorMessage> errors)
    {
        return new Result(errors);
    }
    
    public static Result<TValue> Failure<TValue>(ErrorMessage error)
    {
        return Result<TValue>.Failure(error);
    }
    
    public static Result<TValue> Failure<TValue>(IEnumerable<ErrorMessage> errors)
    {
        return Result<TValue>.Failure(errors);
    }
}