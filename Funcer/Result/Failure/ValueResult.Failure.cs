using Funcer.Messages;

namespace Funcer;

public readonly partial struct Result<TValue>
{
    public static Result<TValue> Failure(params IEnumerable<ErrorMessage> errors)
    {
        return new Result<TValue>(errors);
    }
}