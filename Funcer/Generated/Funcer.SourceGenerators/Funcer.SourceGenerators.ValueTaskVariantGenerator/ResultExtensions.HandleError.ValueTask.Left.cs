using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_HandleError_ValueTask_Left
{
    public static async ValueTask<Result> HandleError(this ValueTask<Result> resultValueTask, string errorType, Action<IEnumerable<ErrorMessage>> onError)
    {
        var result = await resultValueTask;

        return result.HandleError(errorType, onError);
    }
    
    public static async ValueTask<Result> HandleError(this ValueTask<Result> resultValueTask, string errorType, Action onError)
    {
        var result = await resultValueTask;

        return result.HandleError(errorType, onError);
    }
}