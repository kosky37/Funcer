using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_HandleWarning_Task_Left
{
    public static async Task<Result<TValue>> HandleWarning<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<IEnumerable<WarningMessage>, TValue> onWarning)
    {
        var result = await resultTask;

        return result.HandleWarning(errorType, onWarning);
    }
    
    public static async Task<Result<TValue>> HandleWarning<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<TValue> onWarning)
    {
        var result = await resultTask;

        return result.HandleWarning(errorType, onWarning);
    }
}