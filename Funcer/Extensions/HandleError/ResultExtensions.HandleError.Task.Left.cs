using Funcer.Messages;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_HandleError_Task_Left
{
    public static async Task<Result> HandleError(this Task<Result> resultTask, string errorType, Action<IEnumerable<ErrorMessage>> onError)
    {
        var result = await resultTask;

        return result.HandleError(errorType, onError);
    }
    
    public static async Task<Result> HandleError(this Task<Result> resultTask, string errorType, Action onError)
    {
        var result = await resultTask;

        return result.HandleError(errorType, onError);
    }
}