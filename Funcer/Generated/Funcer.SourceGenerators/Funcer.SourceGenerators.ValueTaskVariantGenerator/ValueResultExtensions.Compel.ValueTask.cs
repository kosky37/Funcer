using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Compel_ValueTask
{
    public static async ValueTask<TValue> Compel<TValue>(this ValueTask<Result<TValue>> resultValueTask)
    {
        var result = await resultValueTask;
        if (result.IsFailure) throw new FailureResultException(result.Errors);

        return result.Value!;
    }
    
    public static async ValueTask<TValue> Compel<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<IReadOnlyCollection<ErrorMessage>, ValueTask<Exception>> exception)
    {
        var result = await resultValueTask;
        if (result.IsFailure) throw await exception(result.Errors);

        return result.Value!;
    }
}