using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> HandleWarning<TValue>(this Task<Result<TValue>> resultTask, string errorType, Action onWarning)
    {
        var result = await resultTask;

        return result.HandleWarning(errorType, onWarning);
    }
    
    public static async Task<Result<TValue>> HandleWarning<TValue>(this Task<Result<TValue>> resultTask, string errorType, Action<IEnumerable<WarningMessage>> onWarning)
    {
        var result = await resultTask;

        return result.HandleWarning(errorType, onWarning);
    }
    
    public static async Task<Result<TValue>> HandleWarning<TValue>(this Task<Result<TValue>> resultTask, string errorType, Action<IEnumerable<WarningMessage>, TValue> onWarning)
    {
        var result = await resultTask;

        return result.HandleWarning(errorType, onWarning);
    }
}