using Funcer.Messages;

namespace Funcer;

public readonly partial struct Result<TValue>
{
    public static Result<TValue> Failure(ErrorMessage error)
    {
        return new Result<TValue>(error);
    }
    
    public static Result<TValue> Failure(IEnumerable<ErrorMessage> errors)
    {
        return new Result<TValue>(errors);
    }
}