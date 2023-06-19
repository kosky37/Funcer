using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_HandleWarning_ValueTask_Left
{
    public static async ValueTask<Result<TValue>> HandleWarning<TValue>(this ValueTask<Result<TValue>> resultValueTask, string errorType, Func<IEnumerable<WarningMessage>, TValue> onWarning)
    {
        var result = await resultValueTask;

        return result.HandleWarning(errorType, onWarning);
    }
    
    public static async ValueTask<Result<TValue>> HandleWarning<TValue>(this ValueTask<Result<TValue>> resultValueTask, string errorType, Func<TValue> onWarning)
    {
        var result = await resultValueTask;

        return result.HandleWarning(errorType, onWarning);
    }
}