using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_HandleWarning_ValueTask
{
    public static async ValueTask<Result<TValue>> HandleWarning<TValue>(this ValueTask<Result<TValue>> resultValueTask, string errorType, Func<IEnumerable<WarningMessage>, ValueTask<TValue>> onWarning)
    {
        var result = await resultValueTask;

        return await result.HandleWarning(errorType, onWarning);
    }
    
    public static async ValueTask<Result<TValue>> HandleWarning<TValue>(this ValueTask<Result<TValue>> resultValueTask, string errorType, Func<ValueTask<TValue>> onWarning)
    {
        var result = await resultValueTask;

        return await result.HandleWarning(errorType, onWarning);
    }
}