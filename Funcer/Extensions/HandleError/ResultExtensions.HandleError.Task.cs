using Funcer.Messages;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_HandleError_Task
{
    public static async Task<Result> HandleError(this Task<Result> resultTask, string errorType, Func<IEnumerable<ErrorMessage>, Task> onError)
    {
        var result = await resultTask;

        return await result.HandleError(errorType, onError);
    }
    
    public static async Task<Result> HandleError(this Task<Result> resultTask, string errorType, Func<Task> onError)
    {
        var result = await resultTask;

        return await result.HandleError(errorType, onError);
    }
}