using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_HandleError_ValueTask_Left
{
    public static async ValueTask<Result<TValue>> HandleError<TValue>(this ValueTask<Result<TValue>> resultValueTask, string errorType, Func<IEnumerable<ErrorMessage>, TValue> onError)
    {
        var result = await resultValueTask;

        return result.HandleError(errorType, onError);
    }
    
    public static async ValueTask<Result<TValue>> HandleError<TValue>(this ValueTask<Result<TValue>> resultValueTask, string errorType, Func<TValue> onError)
    {
        var result = await resultValueTask;

        return result.HandleError(errorType, onError);
    }
    
    public static async ValueTask<Result> HandleError<TValue>(this ValueTask<Result<TValue>> resultValueTask, string errorType, Action<IEnumerable<ErrorMessage>> onError)
    {
        var result = await resultValueTask;

        return result.HandleError(errorType, onError);
    }
    
    public static async ValueTask<Result> HandleError<TValue>(this ValueTask<Result<TValue>> resultValueTask, string errorType, Action onError)
    {
        var result = await resultValueTask;

        return result.HandleError(errorType, onError);
    }
}