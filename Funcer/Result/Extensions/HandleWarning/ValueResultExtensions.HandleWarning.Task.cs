using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> HandleWarning<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<IEnumerable<WarningMessage>, Task<TValue>> onWarning)
    {
        var result = await resultTask;

        return await result.HandleWarning(errorType, onWarning);
    }
    
    public static async Task<Result<TValue>> HandleWarning<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<Task<TValue>> onWarning)
    {
        var result = await resultTask;

        return await result.HandleWarning(errorType, onWarning);
    }
}