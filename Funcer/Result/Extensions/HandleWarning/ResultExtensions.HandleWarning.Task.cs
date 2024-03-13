using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task<Result> HandleWarning(this Task<Result> resultTask, string errorType, Func<IEnumerable<WarningMessage>, Task> onWarning)
    {
        var result = await resultTask;

        return await result.HandleWarning(errorType, onWarning);
    }
    
    public static async Task<Result> HandleWarning(this Task<Result> resultTask, string errorType, Func<Task> onWarning)
    {
        var result = await resultTask;

        return await result.HandleWarning(errorType, onWarning);
    }
}