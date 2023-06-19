using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_HandleWarning_ValueTask_Left
{
    public static async ValueTask<Result> HandleWarning(this ValueTask<Result> resultValueTask, string errorType, Action<IEnumerable<WarningMessage>> onWarning)
    {
        var result = await resultValueTask;

        return result.HandleWarning(errorType, onWarning);
    }
    
    public static async ValueTask<Result> HandleWarning(this ValueTask<Result> resultValueTask, string errorType, Action onWarning)
    {
        var result = await resultValueTask;

        return result.HandleWarning(errorType, onWarning);
    }
}