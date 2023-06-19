using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_HandleError_ValueTask
{
    public static async ValueTask<Result<TValue>> HandleError<TValue>(this ValueTask<Result<TValue>> resultValueTask, string errorType, Func<IEnumerable<ErrorMessage>, ValueTask<TValue>> onError)
    {
        var result = await resultValueTask;

        return await result.HandleError(errorType, onError);
    }
    
    public static async ValueTask<Result<TValue>> HandleError<TValue>(this ValueTask<Result<TValue>> resultValueTask, string errorType, Func<ValueTask<TValue>> onError)
    {
        var result = await resultValueTask;

        return await result.HandleError(errorType, onError);
    }
    
    public static async ValueTask<Result> HandleError<TValue>(this ValueTask<Result<TValue>> resultValueTask, string errorType, Func<IEnumerable<ErrorMessage>, ValueTask> onError)
    {
        var result = await resultValueTask;

        return await result.HandleError(errorType, onError);
    }
    
    public static async ValueTask<Result> HandleError<TValue>(this ValueTask<Result<TValue>> resultValueTask, string errorType, Func<ValueTask> onError)
    {
        var result = await resultValueTask;

        return await result.HandleError(errorType, onError);
    }
}