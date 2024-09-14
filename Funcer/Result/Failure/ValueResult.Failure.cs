using Funcer.Messages;

namespace Funcer;

public readonly partial struct Result<TValue>
{
#if NET9_0_OR_GREATER
    public static Result<TValue> Failure(params IEnumerable<ErrorMessage> errors)
    {
        return new Result<TValue>(errors);
    }
#else
    public static Result<TValue> Failure(params ErrorMessage[] errors)
    {
        return new Result<TValue>(errors);
    }
    
    public static Result<TValue> Failure(IEnumerable<ErrorMessage> errors)
    {
        return new Result<TValue>(errors);
    }
#endif
}