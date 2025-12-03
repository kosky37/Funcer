using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> OnError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<IEnumerable<ErrorMessage>, Task<TValue>> onError)
    {
        var result = await resultTask;
        return await result.OnError(errorType, onError);
    }
    
    public static async Task<Result<TValue>> OnError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<Task<TValue>> onError)
    {
        var result = await resultTask;
        return await result.OnError(errorType, onError);
    }
    
    public static async Task<Result<TValue>> OnError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<IEnumerable<ErrorMessage>, Task<Result<TValue>>> onError)
    {
        var result = await resultTask;
        return await result.OnError(errorType, onError);
    }
    
    public static async Task<Result<TValue>> OnError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<Task<Result<TValue>>> onError)
    {
        var result = await resultTask;
        return await result.OnError(errorType, onError);
    }
}

