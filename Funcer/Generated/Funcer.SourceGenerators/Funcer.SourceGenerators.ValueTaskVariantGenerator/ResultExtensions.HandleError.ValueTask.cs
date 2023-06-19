using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_HandleError_ValueTask
{
    public static async ValueTask<Result> HandleError(this ValueTask<Result> resultValueTask, string errorType, Func<IEnumerable<ErrorMessage>, ValueTask> onError)
    {
        var result = await resultValueTask;

        return await result.HandleError(errorType, onError);
    }
    
    public static async ValueTask<Result> HandleError(this ValueTask<Result> resultValueTask, string errorType, Func<ValueTask> onError)
    {
        var result = await resultValueTask;

        return await result.HandleError(errorType, onError);
    }
}