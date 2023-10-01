using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_HandleWarning_Task_Left
{
    public static async Task<Result> HandleWarning(this Task<Result> resultTask, string errorType, Action<IEnumerable<WarningMessage>> onWarning)
    {
        var result = await resultTask;

        return result.HandleWarning(errorType, onWarning);
    }
    
    public static async Task<Result> HandleWarning(this Task<Result> resultTask, string errorType, Action onWarning)
    {
        var result = await resultTask;

        return result.HandleWarning(errorType, onWarning);
    }
}