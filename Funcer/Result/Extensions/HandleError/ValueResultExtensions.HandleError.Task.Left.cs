using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> HandleError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<IEnumerable<ErrorMessage>, TValue> onError)
    {
        var result = await resultTask;

        return result.HandleError(errorType, onError);
    }
    
    public static async Task<Result<TValue>> HandleError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<TValue> onError)
    {
        var result = await resultTask;

        return result.HandleError(errorType, onError);
    }
    
    public static async Task<Result<TValue>> HandleError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<IEnumerable<ErrorMessage>, Result<TValue>> onError)
    {
        var result = await resultTask;

        return result.HandleError(errorType, onError);
    }
    
    public static async Task<Result<TValue>> HandleError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<Result<TValue>> onError)
    {
        var result = await resultTask;

        return result.HandleError(errorType, onError);
    }
    
    public static async Task<Result> HandleError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Action<IEnumerable<ErrorMessage>> onError)
    {
        var result = await resultTask;

        return result.HandleError(errorType, onError);
    }
    
    public static async Task<Result> HandleError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Action onError)
    {
        var result = await resultTask;

        return result.HandleError(errorType, onError);
    }
    
    public static async Task<Result> HandleError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<IEnumerable<ErrorMessage>, Result> onError)
    {
        var result = await resultTask;

        return result.HandleError(errorType, onError);
    }
    
    public static async Task<Result> HandleError<TValue>(this Task<Result<TValue>> resultTask, string errorType, Func<Result> onError)
    {
        var result = await resultTask;

        return result.HandleError(errorType, onError);
    }
}