using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
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
    
    public static async Task<Result> HandleError(this Task<Result> resultTask, string errorType, Func<IEnumerable<ErrorMessage>, Result> onError)
    {
        var result = await resultTask;

        return result.HandleError(errorType, onError);
    }
    
    public static async Task<Result> HandleError(this Task<Result> resultTask, string errorType, Func<Result> onError)
    {
        var result = await resultTask;

        return result.HandleError(errorType, onError);
    }
}