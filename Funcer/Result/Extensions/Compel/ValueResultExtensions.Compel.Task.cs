using Funcer.Exceptions;
using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<TValue> Compel<TValue>(this Task<Result<TValue>> resultTask)
    {
        var result = await resultTask;
        if (result.IsFailure) throw new FailureResultException(result.Errors);

        return result.Value!;
    }
    
    public static async Task<TValue> Compel<TValue>(this Task<Result<TValue>> resultTask, Func<IReadOnlyCollection<ErrorMessage>, Task<Exception>> exception)
    {
        var result = await resultTask;
        if (result.IsFailure) throw await exception(result.Errors);

        return result.Value!;
    }
}