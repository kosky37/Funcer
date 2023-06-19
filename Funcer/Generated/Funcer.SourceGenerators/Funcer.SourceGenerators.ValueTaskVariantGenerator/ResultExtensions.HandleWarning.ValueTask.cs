using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_HandleWarning_ValueTask
{
    public static async ValueTask<Result> HandleWarning(this ValueTask<Result> resultValueTask, string errorType, Func<IEnumerable<WarningMessage>, ValueTask> onWarning)
    {
        var result = await resultValueTask;

        return await result.HandleWarning(errorType, onWarning);
    }
    
    public static async ValueTask<Result> HandleWarning(this ValueTask<Result> resultValueTask, string errorType, Func<ValueTask> onWarning)
    {
        var result = await resultValueTask;

        return await result.HandleWarning(errorType, onWarning);
    }
}