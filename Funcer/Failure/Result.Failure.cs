using Funcer.Messages;

namespace Funcer;

public partial class Result
{
    public static Result Failure(Error error)
    {
        return new Result(error);
    }
    
    public static Result Failure(IEnumerable<Error> errors)
    {
        return new Result(errors);
    }
    
    public static Result<TValue> Failure<TValue>(Error error)
    {
        return Result<TValue>.Failure(error);
    }
    
    public static Result<TValue> Failure<TValue>(IEnumerable<Error> errors)
    {
        return Result<TValue>.Failure(errors);
    }
}