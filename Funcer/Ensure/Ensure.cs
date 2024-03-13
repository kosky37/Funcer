using Funcer.Messages;

namespace Funcer;

public static class Ensure
{
    public static Result<TValue> HasValue<TValue>(TValue? @object, ErrorMessage error)
    {
        return @object is not null ? Result.Success(@object!) : Result<TValue>.Failure(error);
    }
}