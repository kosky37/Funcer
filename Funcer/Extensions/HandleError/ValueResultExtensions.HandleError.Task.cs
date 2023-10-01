using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_HandleError_Task
{
    public static async Task<Result<TValue>> HandleError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<IEnumerable<ErrorMessage>, Task<TValue>> onError)
    {
        var result = await resultTask;

        return await result.HandleError(errorType, onError);
    }
    
    public static async Task<Result<TValue>> HandleError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<Task<TValue>> onError)
    {
        var result = await resultTask;

        return await result.HandleError(errorType, onError);
    }
    
    public static async Task<Result> HandleError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<IEnumerable<ErrorMessage>, Task> onError)
    {
        var result = await resultTask;

        return await result.HandleError(errorType, onError);
    }
    
    public static async Task<Result> HandleError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<Task> onError)
    {
        var result = await resultTask;

        return await result.HandleError(errorType, onError);
    }
}