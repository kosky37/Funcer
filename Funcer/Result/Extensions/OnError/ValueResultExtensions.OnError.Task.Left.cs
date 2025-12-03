using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> OnError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<IEnumerable<ErrorMessage>, TValue> onError)
    {
        var result = await resultTask;
        return result.OnError(errorType, onError);
    }
    
    public static async Task<Result<TValue>> OnError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<TValue> onError)
    {
        var result = await resultTask;
        return result.OnError(errorType, onError);
    }
    
    public static async Task<Result<TValue>> OnError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<IEnumerable<ErrorMessage>, Result<TValue>> onError)
    {
        var result = await resultTask;
        return result.OnError(errorType, onError);
    }
    
    public static async Task<Result<TValue>> OnError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<Result<TValue>> onError)
    {
        var result = await resultTask;
        return result.OnError(errorType, onError);
    }
}

